using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using Antlr.Runtime;
using Antlr4.StringTemplate;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace Farhang2
{
    public partial class MobileDBExporter : Form
    {
        MongoClient client;
        MongoServer server;
        MongoDatabase farhang_database;
        MongoGridFS gridFS;
        MongoCollection<Headword> collection;
        MongoCursor<Headword> collection_data;
        Headword currentHeadword;
        BinaryWriter outputMobileDB;
        #region SpecialCharacters
        public static Dictionary<String, String> special_characters = new Dictionary<string, string>
        {
            {"ɐ̯", "\\hill{\\textturna{}}"},
            {"ã", "\\~{a}"},
            {"a͜i", "\\textbottomtiebar{ai}"},
            {"a͜u", "\\textbottomtiebar{ai}"},
            {"d͜ʒ", "\\textbottomtiebar{\\textdyoghlig{}}"},
            {"ɛ̃", "\\~{\\textepsilon{}}"},
            {"i̯", "\\hill{i}"},
            {"l̩", "\\textsyllabic{l}"},
            {"m̩", "\\textsyllabic{m}"},
            {"n̩", "\\textsyllabic{n}"},
            {"o̯", "\\hill{o}"},
            {"õ", "\\~{o}"},
            {"œ̃", "\\~{\\oe{}}"},
            {"o͜u", "\\textbottomtiebar{ou}"},
            {"ɔ͜y", "\\textbottomtiebar{\\textopeno{}y}"},
            {"t͜s", "\\textbottomtiebar{ts}"},
            {"t͜ʃ", "\\textbottomtiebar{t\\esh{}}"},
            {"u̯", "\\hill{u}"},
            {"y̆", "\\breve{y}"},
            {"à", "\\`{a}"},
            {"é", "\\'{e}"},
            {"ː", "\\textlengthmark{}"},
            {"ɐ", "\\textturna{}"},
            {"ɪ", "\\textsci{}"},
            {"ʊ", "\\textupsilon{}"},
            {"ç", "\\c{c}"},
            {"ɛ", "\\textepsilon{}"},
            {"ǝ", "\\textschwa{}"},
            {"ŋ", "\\engma{}"},
            {"ɔ", "\\textopeno{}"},
            {"ø", "\\o{}"},
            {"œ", "\\oe{}"},
            {"ʃ", "\\esh{}"},
            {"θ", "\\texttheta{}"},
            {"ʏ", "\\textscy{}"},
            {"ʒ", "\\textyogh{}"},
            {"ʌ", "\\textturnv{}"},
            {"ӕ", "\\ae{}"},
            {"ð", "\\eth{}"},
            {"∥", "\\textdoublepipe{}"},
            //{"→", "\\rightarrow{}"},
            //{"↑", "\\uparrow{}"},
            //{"↔", "\\leftrightarrow{}"},
            //{"·", "\\textperiodcentered{}"},
            {"̣", "\\d{$letter$}"},
            {"|", "\\textpipe{}"},
            //{"'", "\\textprimstress{}"},
            {"ˌ", "\\textsecstress{}"},
            {"®", "\\textregistered{}"},
            {"©", "\\textcopyright{}"},
            //{"‣", "\\blacktriangleright{}"},
            // single character underline
            {"̲", "\\underline{$letter$}"},
            // double character underline
            {"͟", "\\underline{$letter$}"},
            //{"≈", "\\approx{}"},
            {"⌘", "\\manstar{}"},
            {"⁰", "\\textsuperscript{0}"},
            {"¹", "\\textsuperscript{1}"},
            {"²", "\\textsuperscript{2}"},
            {"³", "\\textsuperscript{3}"},
            {"⁴", "\\textsuperscript{4}"},
            {"⁵", "\\textsuperscript{5}"},
            {"⁶", "\\textsuperscript{6}"},
            {"⁷", "\\textsuperscript{7}"},
            {"⁸", "\\textsuperscript{8}"},
            {"⁹", "\\textsuperscript{9}"},
            {"\"", "\'\'"},
            {"%", "\\%"}
        };
        #endregion
        #region TEXDOCUMENTTEMPLATE
        String texDocString = @"% !TEX TS-program = xelatex
% !TEX encoding = UTF-8

\documentclass{farhang} % use larger type; default would be 10pt

\settextfont[Scale=0.9]{XB Zar}
\defpersianfont\Roya[Scale=0.8]{XB Roya}
\setlength{\oddsidemargin}{-5mm}
\setlength{\evensidemargin}{-5mm}
\setlength{\textheight}{21.5cm}
\setlength{\textwidth}{13.5cm}
\setlength{\topmargin}{-14mm}
%\setlength{\footskip}{8mm}
\setlength{\headsep}{3mm}
\setlength{\parindent}{-2.5mm}
\setlength{\parskip}{0pt}
\setlength{\columnsep}{5mm}
\setlength{\headheight}{5mm}
% set unit length to 1cm for textblock*
\setlength{\unitlength}{1cm}
\renewcommand{\headrulewidth}{0pt}
\renewcommand{\footrulewidth}{0pt}
%\cfoot{\hspace{1cm}\lr{\arialnormal{\thepage}}}
\renewcommand{\tabcolsep}{0pt}
%\renewcommand{\baselinestretch}{0.85}
%\textblockorigin{0mm}{0mm}
%\setcounter{page}{$lastpage$}
\setlength{\TPHorizModule}{1cm}
\setlength{\TPVertModule}{1cm}
\thumbindexcharacter{$letter$}
\pagestyle{fancy}
\fancyhf{}
\fancyhead[LO]{\lr{\DejaVuSansExtraLight{\thepage}}}
\fancyhead[RE]{\lr{\DejaVuSansExtraLight{\thepage}}}

\begin{document}
\pagenumbering{arabic}
\begin{latin}
\thispagestyle{empty}
\alphahead{$letter$}
\begin{multicols*}{2}
$items$
\end{multicols*}
\end{latin}
\end{document}";
        #endregion

        public MobileDBExporter()
        {
            InitializeComponent();
        }
        private void Initialize()
        {
            if (server != null)
                server.Disconnect();

            client = new MongoClient();
            server = client.GetServer();
            farhang_database = server.GetDatabase("farhang");
            gridFS = new MongoGridFS(farhang_database);

            try
            {
                server.Instance.Ping();
            }
            catch (Exception)
            {
                MessageBox.Show("Server is not available or not responding!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnGenerateMobileDB_Click(object sender, EventArgs e)
        {
            List<string> special_characters = new List<string>() { "·", "̣", "|", "'", "ˌ", "̲", "͟", "͠", ";" };
            string selectedLetter = (cmbBoxLetter.SelectedItem == null) ? null : cmbBoxLetter.SelectedItem.ToString().ToUpper();

            if (cmbBoxLetter.SelectedItem != null)
            {
                try
                {
                    if (!cmbBoxLetter.Items.Contains(selectedLetter))
                    {
                        MessageBox.Show("No item is selected or the selected item does not exist!", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No item is selected or the selected item does not exist!", "Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                Initialize(); // initialize database variables
                if (!farhang_database.CollectionExists(selectedLetter))
                {
                    MessageBox.Show("Collection does not exist!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                Initialize(); // initialize database variables
            }

            string outputDirectory = Application.StartupPath + "\\Output\\" + selectedLetter;
            DirectoryInfo dirInfo = Directory.CreateDirectory(outputDirectory);
            if (dirInfo.Exists)
            {
                FileStream fileStream;
                List<Headword> headwordsList = new List<Headword>();

                try
                {
                    if (selectedLetter != null)
                    {
                        collection = farhang_database.GetCollection<Headword>(selectedLetter);
                        collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");
                        fileStream = new FileStream(outputDirectory + "\\" + selectedLetter + ".db", FileMode.Create, FileAccess.Write);

                        progressBar1.Value = 0;
                        listBox1.Items.Clear();

                        progressBar1.Maximum = Int32.Parse(collection_data.Count().ToString());

                        using (outputMobileDB = new BinaryWriter(fileStream))
                        {
                            using (BsonWriter writer = new BsonWriter(outputMobileDB))
                            {
                                headwordsList = new List<Headword>();
                                JsonSerializer serializer = new JsonSerializer();
                                foreach (var item in collection_data)
                                {
                                    currentHeadword = item;
                                    currentHeadword._id = null;
                                    currentHeadword.Attachment = null;
                                    string word = currentHeadword.Lemma;
                                    foreach (var character in special_characters)
                                    {
                                        word = word.Replace(character, "");
                                    }
                                    currentHeadword.Word = word;
                                    headwordsList.Add(currentHeadword);
                                    listBox1.Items.Add("Processing lemma: " + currentHeadword.Lemma);
                                    progressBar1.Value++;
                                }
                                serializer.Serialize(writer, headwordsList);
                            }
                        }
                    }
                    else
                    {
                        outputDirectory = Application.StartupPath + "\\Output\\Database";
                        dirInfo = Directory.CreateDirectory(outputDirectory);
                        fileStream = new FileStream(outputDirectory + "\\database.db", FileMode.Create, FileAccess.Write);

                        progressBar1.Value = 0;
                        listBox1.Items.Clear();

                        int count = 0;
                        foreach (var letter in cmbBoxLetter.Items)
                        {
                            collection = farhang_database.GetCollection<Headword>(letter.ToString());
                            collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

                            foreach (var headword in collection_data)
                            {
                                count++;
                            }
                        }

                        progressBar1.Maximum = count;

                        using (outputMobileDB = new BinaryWriter(fileStream))
                        {
                            using (BsonWriter writer = new BsonWriter(outputMobileDB))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                foreach (var letter in cmbBoxLetter.Items)
                                {
                                    collection = farhang_database.GetCollection<Headword>(letter.ToString());
                                    collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

                                    foreach (var headword in collection_data)
                                    {
                                        currentHeadword = headword;
                                        currentHeadword._id = null;
                                        currentHeadword.Attachment = null;
                                        string word = currentHeadword.Lemma;
                                        foreach (var character in special_characters)
                                        {
                                            word = word.Replace(character, "");
                                        }
                                        currentHeadword.Word = word;
                                        headwordsList.Add(currentHeadword);
                                        listBox1.Items.Add("Processing lemma: " + currentHeadword.Lemma);
                                        progressBar1.Value++;
                                    }
                                }
                                serializer.Serialize(writer, headwordsList);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    outputMobileDB.Close();
                    MessageBox.Show("An unknown error occurred!", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Can not create directory!", "Directory Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
