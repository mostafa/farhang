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

namespace Farhang2
{
    public partial class PDFBuilder : Form
    {
        MongoClient client;
        MongoServer server;
        MongoDatabase farhang_database;
        MongoGridFS gridFS;
        MongoCollection<Headword> collection;
        MongoCursor<Headword> collection_data;
        Headword currentHeadword;
        TextWriter outputTEXDocumentClass;
        TextReader inputTEXDocumentClass;
        StreamWriter outputTEXDocument;
        #region SpecialCharacters
        public static Dictionary<String, String> special_characters = new Dictionary<string,string>
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

        public PDFBuilder()
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

        private void btnGenerateTEXFile_Click(object sender, EventArgs e)
        {
            string selectedLetter = cmbBoxLetter.SelectedItem.ToString().ToUpper();

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

            string outputDirectory = Application.StartupPath + "\\Output\\" + selectedLetter;
            DirectoryInfo dirInfo = Directory.CreateDirectory(outputDirectory);
            if (dirInfo.Exists)
            {
                collection = farhang_database.GetCollection<Headword>(selectedLetter);
                collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");
                outputTEXDocument = new StreamWriter(dirInfo.FullName + "\\" + selectedLetter + ".tex", false);
                outputTEXDocument.AutoFlush = true;

                string documentElements = "";
                try
                {
                    progressBar1.Value = 0;
                    listBox1.Items.Clear();

                    progressBar1.Maximum = Int32.Parse(collection_data.Count().ToString());
                    foreach (var item in collection_data)
                    {
                        currentHeadword = item;
                        listBox1.Items.Add("Processing lemma: " + currentHeadword.Lemma);
                        documentElements += makeTEXDocument();
                        if (chkOutputPictures.Checked)
                        {
                            if (currentHeadword.Attachment != null)
                            {
                                var picturefile = gridFS.FindOne(Query.EQ("_id", (BsonObjectId)currentHeadword.Attachment._AttachmentId));

                                using (var stream = picturefile.OpenRead())
                                {
                                    var bytes = new byte[stream.Length];
                                    stream.Read(bytes, 0, (int)stream.Length);
                                    var filesDirectory = Directory.CreateDirectory(outputDirectory + "\\files\\");
                                    using (var outputFile = new FileStream(filesDirectory.FullName + "\\" + currentHeadword.Attachment.FileName, FileMode.Create))
                                    {
                                        outputFile.Write(bytes, 0, bytes.Length);
                                    }
                                }

                                listBox1.Items.Add("Processing file: " + currentHeadword.Attachment.FileName.ToString());
                            }
                        }
                        progressBar1.Value += 1;
                    }
                }
                catch (Exception)
                {
                    outputTEXDocument.Close();
                    MessageBox.Show("Server is not available or not responding!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                string documentContents = texDocString.Replace("$letter$", selectedLetter);
                documentContents = documentContents.Replace("$items$", documentElements);

                outputTEXDocument.WriteLine(documentContents);
                outputTEXDocument.Close();

                using (outputTEXDocumentClass = new StreamWriter(outputDirectory + "\\farhang.cls", false))
                {
                    using (inputTEXDocumentClass = new StreamReader(Application.StartupPath + "\\farhang.cls"))
                    {
                        outputTEXDocumentClass.Write(inputTEXDocumentClass.ReadToEnd());
                        listBox1.Items.Add("farhang.cls successfully added.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Can not create directory!", "Directory Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private string makeTEXDocument()
        {
            var headword = new { Lemma = "Lemma", Pronunciation = "[pronunciation]", Description = "description..." };
            String entries = "";

            Template headwordTemplate = new Template("\\headword{$Lemma$}{$Pronunciation$}{$Description$}{$Word$}\n", '$', '$');
            headwordTemplate.Add("Lemma", formatTEXString(currentHeadword.Lemma));
            headwordTemplate.Add("Pronunciation", String.IsNullOrWhiteSpace(currentHeadword.Pronunciation) ? "" : "[" + formatTEXString(currentHeadword.Pronunciation) + "]");
            headwordTemplate.Add("Description", String.IsNullOrWhiteSpace(currentHeadword.Description) ? "" : formatTEXString(currentHeadword.Description));
            headwordTemplate.Add("Word", currentHeadword.Word);

            entries += headwordTemplate.Render();

            if (currentHeadword.Entries != null)
            {
                if (currentHeadword.Entries.Count > 0)
                {
                    for (int i = 0; i < currentHeadword.Entries.Count; i++)
                    {
                        Template entryTemplate = new Template("\\entry{$number$}{$sourcetext$}{$translation$}\n", '$', '$');
                        Template subentryTemplate = new Template("\\subentry{$sourcetext$}{$translation$}\n", '$', '$');
                        int entryCount = 0;

                        foreach (var entry in currentHeadword.Entries)
                        {
                            if (entry.EntryType == "Entry")
                            {
                                entryCount++;
                            }
                        }

                        if (currentHeadword.Entries[i].EntryType == "Entry")
                        {
                            if (entryCount == 1)
                            {
                                if (currentHeadword.Entries[i].SourceText != null)
                                {
                                    entryTemplate.Add("sourcetext", String.IsNullOrWhiteSpace(currentHeadword.Entries[i].SourceText) ? "" : formatTEXString(currentHeadword.Entries[i].SourceText));
                                }

                                if (currentHeadword.Entries[i].Translation != null)
                                {
                                    entryTemplate.Add("translation", String.IsNullOrWhiteSpace(currentHeadword.Entries[i].Translation) ? "" : formatTEXString(currentHeadword.Entries[i].Translation));
                                }
                            }
                            else
                            {
                                if (currentHeadword.Entries[i].SourceText != null)
                                {
                                    entryTemplate.Add("number", currentHeadword.Entries[i].Number + ".");
                                    entryTemplate.Add("sourcetext", String.IsNullOrWhiteSpace(currentHeadword.Entries[i].SourceText) ? "" : formatTEXString(currentHeadword.Entries[i].SourceText));
                                }
                                else
                                {
                                    entryTemplate.Add("number", currentHeadword.Entries[i].Number + ".");
                                }

                                if (currentHeadword.Entries[i].Translation != null)
                                {
                                    entryTemplate.Add("translation", String.IsNullOrWhiteSpace(currentHeadword.Entries[i].Translation) ? "" : formatTEXString(currentHeadword.Entries[i].Translation));
                                }
                            }
                            entries += entryTemplate.Render();
                        }
                        else
                        {
                            if (currentHeadword.Entries[i].SourceText != null)
                            {
                                subentryTemplate.Add("sourcetext", String.IsNullOrWhiteSpace(currentHeadword.Entries[i].SourceText) ? "" : formatTEXString(currentHeadword.Entries[i].SourceText));
                            }

                            if (currentHeadword.Entries[i].Translation != null)
                            {
                                subentryTemplate.Add("translation", String.IsNullOrWhiteSpace(currentHeadword.Entries[i].Translation) ? "" : formatTEXString(currentHeadword.Entries[i].Translation));
                            }
                            entries += subentryTemplate.Render();
                        }
                    }
                }
            }
            else
            {
                entries += "\\newline";
            }

            if (currentHeadword.Attachment != null)
            {
                Template attachmentTemplate = new Template("\\picture{$Filename$}{$Title$}{$Translation$}{$Column$}\n", '$', '$');
                attachmentTemplate.Add("Filename", "files/" + currentHeadword.Attachment.FileName);
                attachmentTemplate.Add("Title", currentHeadword.Attachment.Title);
                attachmentTemplate.Add("Translation", currentHeadword.Attachment.Translation);
                attachmentTemplate.Add("Column", currentHeadword.Attachment.Column);

                entries += attachmentTemplate.Render();
            }

            return entries;
        }

        private string formatTEXString(string input)
        {
            string output = input;
            Int32 SpecialCharacterIndex = 0;
            string PreviousCharacter = "";
            string NextCharacter = "";

            foreach (var item in special_characters.Keys)
            {
                if (output.Contains(item))
                {
                    switch (item)
                    {
                        case "̣":
                            // single character underline
                            // get index of the character in string
                            SpecialCharacterIndex = output.IndexOf(item);
                            // select previous character from input string
                            PreviousCharacter = output[SpecialCharacterIndex - 1].ToString();
                            // add \\d{PreviousCharacter} to output string
                            output = output.Replace(PreviousCharacter + item, special_characters[item].Replace("$letter$", PreviousCharacter));
                            break;
                        case "̲":
                            // single character underline
                            // get index of the character in string
                            SpecialCharacterIndex = output.IndexOf(item);
                            // select previous character from input string
                            PreviousCharacter = output[SpecialCharacterIndex - 1].ToString();
                            // add \\underline{PreviousCharacter} to output string
                            output = output.Replace(PreviousCharacter + item, special_characters[item].Replace("$letter$", PreviousCharacter));
                            break;
                        case "͟":
                            // double character underline
                            // get index of the character in string
                            SpecialCharacterIndex = output.IndexOf(item);
                            // select previous character from input string
                            PreviousCharacter = output[SpecialCharacterIndex - 1].ToString();
                            // select next character from input string
                            NextCharacter = output[SpecialCharacterIndex + 1].ToString();
                            // add \\underline{PreviousCharacter + NextCharacter} to output string
                            output = output.Replace(PreviousCharacter + item + NextCharacter, special_characters[item].Replace("$letter$", PreviousCharacter + NextCharacter));
                            /*
                            // multi character underline
                            bool multiChar = false;
                            // check if there is more than one double line character (multiline)
                            // character exists in the string
                            int count = input.Count(c => c == '͟');
                            if (count > 1)
                            {
                                multiChar = true;
                            }

                            if (multiChar)
                            {
                                //FIXME: add multiple character support to underline character
                            }
                            else
                            {
                            }
                            */
                            break;
                        default:
                            output = output.Replace(item, special_characters[item]);
                            break;
                    }
                }
            }

            return output;
        }
    }
}
