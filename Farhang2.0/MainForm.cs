/*
 * Developer: Mostafa Moradian
 * Date: 2/12/2013
 * Time: 2:29 PM
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Antlr.Runtime;
using Antlr4.StringTemplate;

namespace Farhang2
{
    /// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        // FIXME: improve Init functions to initialize attributes/properties.
        Form ipaForm;
        MongoClient client;
        MongoServer server;
        MongoDatabase farhang_database;
        MongoCollection<Headword> collection;
        MongoCursor<Headword> collection_data;
        Headword currentHeadword;
        BsonObjectId currentHeadwordObjectID;
        Entry currentEntry;
        DataSet priorityDataSet;
        DataTable newTableForUpdatingPriorities;
        List<String> special_characters;
        #region HTMLCSS
        string htmlDocString = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01//EN' 'http://www.w3.org/TR/html4/strict.dtd'>
                                 <html>
	                                <head>
                                        <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
                                        <style type='text/css'>
                                            #default
                                            {
                                                max-width: 500px;
                                                width: 100%;
                                            }

                                            .inline 
                                            {
                                                display: inline;
                                            }

                                            #headword 
                                            {
                                                color: blue;
                                                font-family: DejaVu Sans;
                                                font-weight: bold;
                                                font-size: 12pt;
                                            }

                                            #pronunciation
                                            {
                                                font-family: DejaVu Sans;
                                                font-size: 10pt;
                                            }

                                            #description
                                            {
                                                font-family: Ubuntu;
                                                font-size: 10pt;
                                                font-style: italic;
                                            }

                                            #deutschEntry
                                            {
                                                font-family: DejaVu Serif;
                                                font-size: 11pt;
                                                font-weight: bold;
                                                direction: ltr;
                                                text-align: left;
                                                float: left;
                                                height: 17px;
                                                padding-bottom: 1px;
                                            }

                                            #persianEntry
                                            {
                                                font-family: XB Yagut;
                                                font-size: 12pt;
                                                font-weight: bold;
                                                direction: rtl;
                                                text-align: right;
                                                float: right;
                                                height: 17px;
                                                white-space: nowrap;
                                                padding-bottom: 1px;
                                            }

                                            #deutschSubentry
                                            {
                                                font-family: DejaVu Sans;
                                                direction: ltr;
                                                text-align: left;
                                                float: left;
                                                font-size: 10pt;
                                                height: 14px;
                                                padding-bottom: 1px;
                                            }

                                            #persianSubentry
                                            {
                                                font-family: XB Roya;
                                                direction: rtl;
                                                text-align: right;
                                                float: right;
                                                font-size: 11pt;
                                                height: 14px;
                                                padding-bottom: 1px;
                                                white-space: nowrap;
                                            }
                                        </style>
		                                <title>Output Preview</title>
	                                </head>
	                                <body>
                                        <div id='default'>
                                            $entries$    
                                        </div>
	                                </body>
                                </html>";
        #endregion

        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = "Output Preview";
            editDictionaryToolStripMenuItem.PerformClick();
        }

        private void Initialize()
        {
            client = new MongoClient();
            server = client.GetServer();
            farhang_database = server.GetDatabase("farhang");

            special_characters = new List<string>() { "·", "̣", "|", "'", "ˌ", "̲", "͠" };

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

        void cmbBoxLetterSelectedIndexChanged(object sender, EventArgs e)
		{
            Initialize();

            this.Enabled = false;
            headwordsListBox.Items.Clear();
            txtSelectedLetter.Text = cmbBoxLetter.SelectedItem.ToString();
            txtHeadwordsCount.Text = "0";

            headwordsListBox.SuspendLayout();

            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString().ToUpper());
            collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

            foreach (var item in collection_data)
            {
                headwordsListBox.Items.Add(item.Lemma);
                txtHeadwordsCount.Text = (Convert.ToInt32(txtHeadwordsCount.Text) + 1).ToString();
            }

            //headwordsListBox.Sorted = true;
            headwordsListBox.ResumeLayout();

            btnNewHeadword.Enabled = false;
            btnDeleteHeadword.Enabled = false;
            btnSaveHeadword.Enabled = false;
            btnSaveEntry.Enabled = false;

            headwordsListBox.SelectedIndex = 0;
            cmbBoxEntryType.SelectedIndex = 0;
            txtNumber.Text = "0";
            txtSourceText.Text = null;
            cmbBoxTranslationLanguage.SelectedIndex = 0;
            txtTranslation.Text = null;

            toolStripResult.Text = "Letter " + cmbBoxLetter.SelectedItem.ToString() + "'s Headword Count = " + collection.Count().ToString();

            this.Enabled = true;
		}

        void headwordsListBoxSelectedIndexChanged(object sender, EventArgs e)
		{
            cmbBoxEntryType.SelectedIndex = 0;
            txtNumber.Text = "0";
            txtSourceText.Text = "";
            cmbBoxTranslationLanguage.SelectedIndex = 0;
            txtTranslation.Text = "";

            currentHeadword = collection.FindOneAs<Headword>(Query.EQ("Lemma", headwordsListBox.SelectedItem.ToString()));
            currentEntry = null;

            currentHeadwordObjectID = currentHeadword._id;
            txtLemma.Text = currentHeadword.Lemma;
            txtPronunciation.Text = currentHeadword.Pronunciation;
            txtDescription.Text = currentHeadword.Description;
            chkIncomplete.Checked = currentHeadword.Incomplete == true ? true : false;

            entriesTreeView.Nodes.Clear();

            // construct headword structure
            entriesTreeView.Nodes.Add("Headword");
            entriesTreeView.Nodes[0].Nodes.Add("Lemma: " + txtLemma.Text);
            entriesTreeView.Nodes[0].Nodes[0].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Bold);
            entriesTreeView.Nodes[0].Nodes.Add(String.IsNullOrWhiteSpace(txtPronunciation.Text) ? "Pronunciation: " : "Pronuncation: [" + txtPronunciation.Text + "]");
            entriesTreeView.Nodes[0].Nodes[1].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Regular);
            entriesTreeView.Nodes[0].Nodes.Add(String.IsNullOrWhiteSpace(txtDescription.Text) ? "Description: " : "Description: " + txtDescription.Text);
            entriesTreeView.Nodes[0].Nodes[2].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Italic);

            if (currentHeadword.Entries != null)
            {
                if (currentHeadword.Entries.Count > 0)
                {
                    // construct entry structure
                    entriesTreeView.Nodes[0].Nodes.Add("Entries");

                    for (int i = 0; i < currentHeadword.Entries.Count; i++)
                    {
                        if (currentHeadword.Entries[i].Number.Contains(".") == false)
                        {
                            entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Entry: " + currentHeadword.Entries[i].Number);
                        }
                        else
                        {
                            entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Subentry: " + currentHeadword.Entries[i].Number);
                        }

                        entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Number: " + currentHeadword.Entries[i].Number);
                        entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Source: " + currentHeadword.Entries[i].SourceText);
                        entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Translation: " + currentHeadword.Entries[i].Translation);
                    }

                    for (int j = 0; j < entriesTreeView.Nodes[0].Nodes[3].Nodes.Count; j++)
                    {
                        if (entriesTreeView.Nodes[0].Nodes[3].Nodes[j].Text.Contains("Entry: "))
                        {
                            entriesTreeView.Nodes[0].Nodes[3].Nodes[j].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Bold);
                        }
                    }
                }
            }

            entriesTreeView.TopNode.ExpandAll();
            entriesTreeView.TopNode = entriesTreeView.Nodes[0];

            btnNewHeadword.Enabled = true;
            //btnDeleteHeadword.Enabled = true;
            btnDeleteEntry.Enabled = false;
            btnSaveHeadword.Enabled = false;
            btnSaveEntry.Enabled = false;
            btnAddEntry.Enabled = false;

            toolStripResult.Text = "Selected Headword " + currentHeadword.Lemma;

            webBrowser1.DocumentText = makeHtmlDocument();
            entriesTreeView.AfterSelect += new TreeViewEventHandler(entriesTreeView_AfterSelect);
		}

        private string makeHtmlDocument()
        {
            var headword = new { Headword = "Headword", Pronunciation = "[pronunciation]", Description = "description..." };
            String entries = "";

            Template headwordTemplate = new Template("<div class='inline'><span id='headword'>$Headword$</span> <span id='pronunciation'>$Pronunciation$</span> <span id='description'>$Description$</span></div><br />", '$', '$');
            headwordTemplate.Add("Headword", currentHeadword.Lemma);
            headwordTemplate.Add("Pronunciation", String.IsNullOrWhiteSpace(currentHeadword.Pronunciation) ? "" : "[" + currentHeadword.Pronunciation + "]");
            headwordTemplate.Add("Description", currentHeadword.Description);

            entries += headwordTemplate.Render();

            if (currentHeadword.Entries != null)
            {
                if (currentHeadword.Entries.Count > 0)
                {
                    for (int i = 0; i < currentHeadword.Entries.Count; i++)
                    {
                        Template entryTemplate = new Template("<div class='inline'><span><p id='deutschEntry'>$deutschEntry$</p><wbr /><p id='persianEntry'>$persianEntry$</p></span></div><br />", '$', '$');
                        Template subentryTemplate = new Template("<div class='inline'><span><p id='deutschSubentry'>$deutschSubentry$</p><wbr /><p id='persianSubentry'>$persianSubentry$</p></span></div><br />", '$', '$');
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
                                entryTemplate.Add("deutschEntry", currentHeadword.Entries[i].SourceText);
                                entryTemplate.Add("persianEntry", currentHeadword.Entries[i].Translation);
                            }
                            else
                            {
                                entryTemplate.Add("deutschEntry", currentHeadword.Entries[i].Number + ". " + currentHeadword.Entries[i].SourceText);
                                entryTemplate.Add("persianEntry", currentHeadword.Entries[i].Number + ". " + currentHeadword.Entries[i].Translation);
                            }
                            entries += entryTemplate.Render();
                        }
                        else
                        {
                            subentryTemplate.Add("deutschSubentry", currentHeadword.Entries[i].SourceText);
                            subentryTemplate.Add("persianSubentry", currentHeadword.Entries[i].Translation);
                            entries += subentryTemplate.Render();
                        }
                    }
                }
            }

            return htmlDocString.Replace("$entries$", entries);
        }

        void entriesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (currentHeadword.Entries != null)
            {
                if (currentHeadword.Entries.Count > 0)
                {
                    foreach (var item in currentHeadword.Entries)
                    {
                        if ((item.Number == entriesTreeView.SelectedNode.Text.Replace("Entry: ", "").Replace("Subentry: ", "")) | item.Number == entriesTreeView.SelectedNode.Parent.Text.Replace("Entry: ", "").Replace("Subentry: ", ""))
                        {
                            cmbBoxEntryType.Text = item.EntryType;

                            txtNumber.Text = item.Number;

                            txtSourceText.Text = item.SourceText;

                            if (item.TranslationLanguage == "FA")
                            {
                                //persisch
                                cmbBoxTranslationLanguage.SelectedIndex = 0;
                            }
                            else
                            {
                                //deutsch
                                cmbBoxTranslationLanguage.SelectedIndex = 1;
                            }

                            if (item.TranslationLanguage == "FA")
                            {
                                txtTranslation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                            }
                            txtTranslation.Text = item.Translation;

                            currentEntry = item;
                            btnSaveEntry.Enabled = false;
                            btnDeleteEntry.Enabled = true;
                            btnAddEntry.Enabled = true;
                            toolStripResult.Text = "Selected entry " + currentEntry.Number.ToString();

                            break;
                        }
                    }
                }
            }
        }

        private void editDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            headwordsListGroupBox.Visible = true;
            entriesGroupBox.Visible = true;
            headwordGroupBox.Visible = true;
            attributesGroupBox.Visible = true;
            previewGroupBox.Visible = true;
            previewGroupBox.Height = entriesGroupBox.Height + headwordGroupBox.Height + attributesGroupBox.Height + 12;
            //statisticsGroupBox.Visible = true;
            manualHeadwordSorterGrpBox.Visible = false;
        }

        private void finishEditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            headwordsListGroupBox.Visible = false;
            entriesGroupBox.Visible = false;
            headwordGroupBox.Visible = false;
            attributesGroupBox.Visible = false;
            previewGroupBox.Visible = false;
            //statisticsGroupBox.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (headwordsListGroupBox.Visible == true)
            {
                switch (MessageBox.Show("آیا پیش از خروج از نرم افزار، تغییرات را ذخیره کرده اید؟", "اخطار خروج", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading))
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        Application.Exit();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int position = -1;

            position = headwordsListBox.FindString(txtSearch.Text, position);

            if (position != -1)
            {
                if (headwordsListBox.SelectedIndices.Count > 0)
                {
                    if (position == headwordsListBox.SelectedIndices[0])
                    {
                        return;
                    }
                }

                headwordsListBox.SetSelected(position, true);
            }
            //headwordsListBox.SelectedItem = txtSearch.Text;
        }

        void ipa_FormClosed(object sender, FormClosedEventArgs e)
        {
            ipaForm = null;
        }

        private void btnIPAKeyboard4IPAButtons_Click(object sender, EventArgs e)
        {
            Button ipaBtn = (Button)sender;
            switch (ipaBtn.Name)
            {
                case "btnIPAKeyboard4Search":
                    runIPAKeyboard(txtSearch);
                    break;
                case "btnIPAKeyboard4Lemma":
                    runIPAKeyboard(txtLemma);
                    break;
                case "btnIPAKeyboard4Pronunciation":
                    runIPAKeyboard(txtPronunciation);
                    break;
                case "btnIPAKeyboard4Description":
                    runIPAKeyboard(txtDescription);
                    break;
                case "btnIPAKeyboard4SourceText":
                    runIPAKeyboard(txtSourceText);
                    break;
                case "btnIPAKeyboard4Translation":
                    runIPAKeyboard(txtTranslation);
                    break;
                case "btnIPAKeyboard4MHSSearch":
                    runIPAKeyboard(txtMHSSearch);
                    break;
                default:
                    break;
            }
        }

        private void runIPAKeyboard(TextBox textview)
        {
            if (ipaForm != null)
            {
                ipaForm.BringToFront();
            }
            else
            {
                ipaForm = new IPAKeyboard(this, textview);
                ipaForm.FormClosed += new FormClosedEventHandler(ipa_FormClosed);
                ipaForm.Show();
            }
        }

        private void manualHeadwordSorterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            finishEditingToolStripMenuItem.PerformClick();
            manualHeadwordSorterGrpBox.Show();
        }

        private void cmbBoxLetter4Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initialize();

            this.Enabled = false;

            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter4Sort.SelectedItem.ToString().ToUpper());
            collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

            priorityDataSet = new DataSet();
            priorityDataSet.Tables.Add("Headwords");
            priorityDataSet.Tables[0].Columns.Add("Lemma");
            priorityDataSet.Tables[0].Columns.Add("Priority", typeof(int));

            foreach (var item in collection_data)
            {
                priorityDataSet.Tables[0].Rows.Add(item.Lemma, item.Priority);
            }

            dataGridView4Sort.DataSource = priorityDataSet;
            dataGridView4Sort.DataMember = priorityDataSet.Tables[0].TableName;
            dataGridView4Sort.Sort(dataGridView4Sort.Columns[1], System.ComponentModel.ListSortDirection.Ascending);

            DataSet OriginalDataSet = priorityDataSet.Copy();

            dataGridViewOriginal.DataSource = OriginalDataSet;
            dataGridViewOriginal.DataMember = OriginalDataSet.Tables[0].TableName;
            dataGridViewOriginal.Sort(dataGridViewOriginal.Columns[1], System.ComponentModel.ListSortDirection.Ascending);

            txtTotal4MHS.Text = collection_data.Count().ToString();

            toolStripResult.Text = "Letter " + cmbBoxLetter.SelectedItem.ToString() + "'s Headword Count = " + collection.Count().ToString();

            this.Enabled = true;
        }

        private void dataGridView4Sort_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            priorityDataSet.Tables[0].AcceptChanges();
            priorityDataSet.Tables[0].DefaultView.Sort = "Priority ASC";

            newTableForUpdatingPriorities = priorityDataSet.Tables[0].DefaultView.ToTable("Headwords");

            btnSavePriorityList.Enabled = true;
        }

        private void btnSavePriorityList_Click(object sender, EventArgs e)
        {
            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter4Sort.SelectedItem.ToString());
            for (int i = 0; i < newTableForUpdatingPriorities.Rows.Count; i++)
			{
                WriteConcernResult result = collection.Update(Query.EQ("Lemma", newTableForUpdatingPriorities.Rows[i].ItemArray[0].ToString()), MongoDB.Driver.Builders.Update.Set("Priority", (i + 1)));
                if (result.DocumentsAffected > 0)
                {
                    txtStatus.Text = "Saved " + result.DocumentsAffected.ToString() + " records successfully!";
                }
                else
                {
                    txtStatus.Text = "No record has been saved!";
                }
			}
        }

        private void txtMHSSearch_TextChanged(object sender, EventArgs e)
        {
            int position = -1;

            foreach (DataGridViewRow item in dataGridView4Sort.Rows)
            {
                if (item.Cells[0].Value.ToString().StartsWith(txtMHSSearch.Text))
                {
                    position = item.Index;
                    dataGridView4Sort.CurrentCell = dataGridView4Sort.Rows[position].Cells[0];
                    break;
                }
            }
        }

        private void dataGridView4Sort_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4Sort.SelectedRows.Count > 0)
            {
                txtStatus.Text = "[" + dataGridView4Sort.SelectedRows[0].Cells[1].Value.ToString() + "]: " + dataGridView4Sort.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            var obj = (TextBox)sender;

            if (currentHeadword != null)
            {
                switch (obj.Name)
                {
                    case "txtLemma":
                        btnSaveHeadword.Enabled = (obj.Text != currentHeadword.Lemma) ? true : false;
                        break;
                    case "txtPronunciation":
                        btnSaveHeadword.Enabled = (obj.Text != currentHeadword.Pronunciation) ? true : false;
                        break;
                    case "txtDescription":
                        btnSaveHeadword.Enabled = (obj.Text != currentHeadword.Description) ? true : false;
                        break;
                    default:
                        btnSaveHeadword.Enabled = false;
                        break;
                }
            }

            if (currentEntry != null)
            {
                switch (obj.Name)
                {
                    case "txtNumber":
                        btnSaveEntry.Enabled = (obj.Text != currentEntry.Number) ? true : false;
                        break;
                    case "txtSourceText":
                        string SourceTextValue = String.IsNullOrEmpty(obj.Text) | String.IsNullOrWhiteSpace(obj.Text) ? null : obj.Text;
                        btnSaveEntry.Enabled = (SourceTextValue != currentEntry.SourceText) ? true : false;
                        break;
                    case "txtTranslation":
                        btnSaveEntry.Enabled = (obj.Text != currentEntry.Translation) ? true : false;
                        break;
                    default:
                        btnSaveEntry.Enabled = false;
                        break;
                }
            }
        }

        private void chkIncomplete_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            if (currentHeadword != null)
            {
                btnSaveHeadword.Enabled = (obj.Checked != currentHeadword.Incomplete) ? true : false;
            }
        }

        private void cmbBoxField_TextChanged(object sender, EventArgs e)
        {
            var obj = (ComboBox)sender;

            if (currentEntry != null)
            {
                switch (obj.Name)
                {
                    case "cmbBoxEntryType":
                        btnSaveEntry.Enabled = (obj.Text != currentEntry.EntryType) ? true : false;
                        break;
                    case "cmbBoxTranslationLanguage":
                        String Language = (obj.Text == "Persisch") ? "FA" : "DE";
                        btnSaveEntry.Enabled = (Language != currentEntry.TranslationLanguage) ? true : false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnSaveHeadword_Click(object sender, EventArgs e)
        {
            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString());

            List<UpdateBuilder> updateHeadword = new List<UpdateBuilder>();

            if (!String.IsNullOrWhiteSpace(txtLemma.Text))
            {
                if (txtLemma.Text != currentHeadword.Lemma)
                {
                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Lemma", txtLemma.Text.ToString()));

                    string word = txtLemma.Text;

                    foreach (var item in special_characters)
                    {
                        word = word.Replace(item, "");
                    }

                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Word", word));
                }
            }

            if (!String.IsNullOrWhiteSpace(txtPronunciation.Text))
            {
                if (txtPronunciation.Text != currentHeadword.Pronunciation)
                {
                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Pronunciation", txtPronunciation.Text.ToString()));
                }
            }
            else
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Pronunciation", BsonNull.Value));
            }

            if (!String.IsNullOrWhiteSpace(txtDescription.Text))
            {
                if (txtDescription.Text != currentHeadword.Description)
                {
                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Description", txtDescription.Text.ToString()));
                }
            }
            else
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Description", BsonNull.Value));
            }

            if (chkIncomplete.Checked != currentHeadword.Incomplete)
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Incomplete", txtLemma.Text.ToString()));
            }

            if (DateTime.Now != currentHeadword.ModificationDateTime)
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("ModificationDateTime", new BsonDateTime(DateTime.Now)));
            }

            UpdateBuilder update = MongoDB.Driver.Builders.Update.Combine(updateHeadword);

            WriteConcernResult result = collection.Update(Query.EQ("_id", currentHeadwordObjectID), update);
            if (result.DocumentsAffected == 1)
            {
                toolStripResult.Text = "Result: Headword saved successfully!";
                btnSaveHeadword.Enabled = false;
                headwordsListBox.SelectedItem = txtLemma.Text;
            }
            else
            {
                toolStripResult.Text = "Result: Error saving headword!";
                btnSaveHeadword.Enabled = false;
            }
        }

        private void btnSaveEntry_Click(object sender, EventArgs e)
        {
            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString());

            List<UpdateBuilder> updateEntry = new List<UpdateBuilder>();

            if (!String.IsNullOrWhiteSpace(cmbBoxEntryType.SelectedItem.ToString()))
            {
                if (cmbBoxEntryType.Items.Contains(cmbBoxEntryType.SelectedItem.ToString()))
                {
                    if (cmbBoxEntryType.SelectedItem.ToString() != currentEntry.EntryType)
                    {
                        updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.EntryType", cmbBoxEntryType.SelectedItem.ToString()));
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(txtNumber.Text))
            {
                if (txtNumber.Text != currentEntry.Number)
                {
                    updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.Number", txtNumber.Text.Trim()));
                }
            }

            if (!String.IsNullOrWhiteSpace(txtSourceText.Text))
            {
                if (txtSourceText.Text != currentEntry.SourceText)
                {
                    updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.SourceText", txtSourceText.Text.Trim()));
                }
            }
            else
            {
                updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.SourceText", BsonNull.Value));
            }

            if (!String.IsNullOrWhiteSpace(cmbBoxTranslationLanguage.SelectedItem.ToString()))
            {
                if (cmbBoxTranslationLanguage.Items.Contains(cmbBoxTranslationLanguage.SelectedItem.ToString()))
                {
                    string translang = (cmbBoxTranslationLanguage.SelectedItem.ToString() == "Persisch") ? "FA" : "DE";
                    if (translang != currentEntry.TranslationLanguage)
                    {
                        updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.TranslationLanguage", translang));
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(txtTranslation.Text))
            {
                if (txtTranslation.Text != currentEntry.Translation)
                {
                    updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.Translation", txtTranslation.Text.Trim()));
                }
            }
            else
            {
                updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Translation", BsonNull.Value));
            }

            UpdateBuilder update = MongoDB.Driver.Builders.Update.Combine(updateEntry);

            WriteConcernResult result = collection.Update(Query.And(Query.EQ("_id", currentHeadwordObjectID), Query.EQ("Entries.Number", currentEntry.Number)), update);
            if (result.DocumentsAffected == 1)
            {
                toolStripResult.Text = "Result: Entry saved successfully!";
                btnSaveEntry.Enabled = false;
                headwordsListBox.SelectedItem = txtLemma.Text;
                headwordsListBoxSelectedIndexChanged(sender, e);
            }
            else
            {
                toolStripResult.Text = "Result: Error saving entry!";
                btnSaveEntry.Enabled = false;
            }
        }

        private void btnDeleteHeadword_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove headword '" + currentHeadword.Lemma + "' and its entries?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString());

                WriteConcernResult result = collection.Remove(Query.EQ("_id", currentHeadwordObjectID), RemoveFlags.Single);
                if (result.DocumentsAffected == 1)
                {
                    toolStripResult.Text = "Result: Headword removed permenantly!";
                    cmbBoxLetterSelectedIndexChanged(sender, e);
                }
                else
                {
                    toolStripResult.Text = "Result: Error removing headword!";
                }
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove entry '" + currentEntry.Number + "' and its contents?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString());

                UpdateBuilder update = MongoDB.Driver.Builders.Update.Pull("Entries", currentEntry.ToBsonDocument());

                WriteConcernResult result = collection.Update(Query.And(Query.EQ("_id", currentHeadwordObjectID), Query.EQ("Entries.Number", currentEntry.Number)), update);
                if (result.DocumentsAffected == 1)
                {
                    toolStripResult.Text = "Result: Entry removed permenantly!";
                    headwordsListBoxSelectedIndexChanged(sender, e);
                    btnDeleteHeadword.Enabled = false;
                }
                else
                {
                    toolStripResult.Text = "Result: Error removing entry!";
                    btnDeleteHeadword.Enabled = false;
                }
            }
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString());

            string sourcelang = String.IsNullOrWhiteSpace(txtSourceText.Text) ? null : "DE";

            string source = String.IsNullOrWhiteSpace(txtSourceText.Text) ? null : txtSourceText.Text;

            string lang = cmbBoxTranslationLanguage.SelectedItem.ToString() == "Persisch" ? "FA" : "DE";
            string translang = String.IsNullOrWhiteSpace(txtTranslation.Text) ? null : lang;

            string trans = String.IsNullOrWhiteSpace(txtTranslation.Text) ? null : txtTranslation.Text;

            var entry = new Entry(cmbBoxEntryType.SelectedItem.ToString(), txtNumber.Text, sourcelang, source, translang, trans);

            var update = MongoDB.Driver.Builders.Update.Push("Entries", entry.ToBsonDocument());

            WriteConcernResult result = collection.Update(Query.EQ("_id", currentHeadwordObjectID), update, UpdateFlags.Upsert);
            if (result.DocumentsAffected == 1)
            {
                toolStripResult.Text = "Result: Entry created successfully!";
                headwordsListBoxSelectedIndexChanged(sender, e);
            }
            else
            {
                toolStripResult.Text = "Result: Error creating entry!";
            }
        }
	}
}
