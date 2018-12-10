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
using SQLite;

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
        DBHeadword currentHeadword;
        //BinaryWriter outputMobileDB;
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

            Initialize();

            string outputDirectory = Application.StartupPath + "\\Output\\Database";
            DirectoryInfo dirInfo = Directory.CreateDirectory(outputDirectory);
            if (dirInfo.Exists)
            {
                var database = new SQLiteConnection(outputDirectory + "\\database.db");
                // create database tables
                database.CreateTable<DBHeadword>();
                database.CreateTable<DBEntry>();

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

                foreach (var letter in cmbBoxLetter.Items)
                {
                    collection = farhang_database.GetCollection<Headword>(letter.ToString());
                    collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

                    foreach (var headword in collection_data)
                    {
                        DBHeadword currentHeadword = new DBHeadword(
                            headword.Lemma,
                            headword.Word,
                            headword.Pronunciation,
                            headword.Description,
                            headword.Priority,
                            headword.Incomplete,
                            headword.CreationDateTime,
                            headword.ModificationDateTime
                            );
                        string word = currentHeadword.Lemma;
                        foreach (var character in special_characters)
                        {
                            word = word.Replace(character, "");
                        }
                        currentHeadword.Word = word;
                        DBHeadword.InsertHeadword(database, currentHeadword);

                        if (headword.Entries != null)
                        { 
                            foreach (var entry in headword.Entries)
                            {
                                DBEntry dbEntry = new DBEntry(
                                    currentHeadword.Id,
                                    entry.EntryType,
                                    entry.Number,
                                    entry.SourceLanguage,
                                    entry.SourceText,
                                    entry.TranslationLanguage,
                                    entry.Translation
                                    );

                                database.Insert(dbEntry);
                            }
                        }
                        listBox1.Items.Add("Processing lemma: " + currentHeadword.Lemma);
                        progressBar1.Value++;
                    }
                }
                //FileStream fileStream;
                //List<Headword> headwordsList = new List<Headword>();

                //try
                //{
                //    if (selectedLetter != null)
                //    {
                //        collection = farhang_database.GetCollection<Headword>(selectedLetter);
                //        collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");
                //        fileStream = new FileStream(outputDirectory + "\\" + selectedLetter + ".db", FileMode.Create, FileAccess.Write);

                //        progressBar1.Value = 0;
                //        listBox1.Items.Clear();

                //        progressBar1.Maximum = Int32.Parse(collection_data.Count().ToString());

                //        using (outputMobileDB = new BinaryWriter(fileStream))
                //        {
                //            using (BsonWriter writer = new BsonWriter(outputMobileDB))
                //            {
                //                headwordsList = new List<Headword>();
                //                JsonSerializer serializer = new JsonSerializer();
                //                foreach (var item in collection_data)
                //                {
                //                    currentHeadword = item;
                //                    currentHeadword._id = null;
                //                    currentHeadword.Attachment = null;
                //                    string word = currentHeadword.Lemma;
                //                    foreach (var character in special_characters)
                //                    {
                //                        word = word.Replace(character, "");
                //                    }
                //                    currentHeadword.Word = word;
                //                    headwordsList.Add(currentHeadword);
                //                    listBox1.Items.Add("Processing lemma: " + currentHeadword.Lemma);
                //                    progressBar1.Value++;
                //                }
                //                serializer.Serialize(writer, headwordsList);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        outputDirectory = Application.StartupPath + "\\Output\\Database";
                //        dirInfo = Directory.CreateDirectory(outputDirectory);
                //        fileStream = new FileStream(outputDirectory + "\\database.db", FileMode.Create, FileAccess.Write);

                //        progressBar1.Value = 0;
                //        listBox1.Items.Clear();

                //        int count = 0;
                //        foreach (var letter in cmbBoxLetter.Items)
                //        {
                //            collection = farhang_database.GetCollection<Headword>(letter.ToString());
                //            collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

                //            foreach (var headword in collection_data)
                //            {
                //                count++;
                //            }
                //        }

                //        progressBar1.Maximum = count;

                //        using (outputMobileDB = new BinaryWriter(fileStream))
                //        {
                //            using (BsonWriter writer = new BsonWriter(outputMobileDB))
                //            {
                //                JsonSerializer serializer = new JsonSerializer();
                //                foreach (var letter in cmbBoxLetter.Items)
                //                {
                //                    collection = farhang_database.GetCollection<Headword>(letter.ToString());
                //                    collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

                //                    foreach (var headword in collection_data)
                //                    {
                //                        currentHeadword = headword;
                //                        currentHeadword._id = null;
                //                        currentHeadword.Attachment = null;
                //                        string word = currentHeadword.Lemma;
                //                        foreach (var character in special_characters)
                //                        {
                //                            word = word.Replace(character, "");
                //                        }
                //                        currentHeadword.Word = word;
                //                        headwordsList.Add(currentHeadword);
                //                        listBox1.Items.Add("Processing lemma: " + currentHeadword.Lemma);
                //                        progressBar1.Value++;
                //                    }
                //                }
                //                serializer.Serialize(writer, headwordsList);
                //            }
                //        }
                //    }
                //}
                //catch (Exception)
                //{
                //    outputMobileDB.Close();
                //    MessageBox.Show("An unknown error occurred!", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //    return;
                //}
            }
            else
            {
                MessageBox.Show("Can not create directory!", "Directory Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
