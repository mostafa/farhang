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
using System.Linq;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
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
        MongoGridFS gridFS;
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
            gridFS = new MongoGridFS(farhang_database);

            special_characters = new List<string>() { "·", "̣", "|", "'", "ˌ", "̲", "͠", "¹", "²", "³", "⁴", "⁵" };

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

            headwordsListBox.SuspendLayout();

            try
            {
                collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString().ToUpper());
                collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

                var x = collection_data.ToList();

                foreach (var item in collection_data)
                {
                    headwordsListBox.Items.Add(item.Lemma);
                }

                toolStripResult.Text = "Letter " + cmbBoxLetter.SelectedItem.ToString() + "'s Headword Count = " + collection.Count().ToString();

                btnAddHeadword.Enabled = false;
                btnDeleteHeadword.Enabled = false;
                btnSaveHeadword.Enabled = false;
                btnSaveEntry.Enabled = false;

                headwordsListBox.SelectedIndex = 0;
                cmbBoxEntryType.SelectedIndex = 0;
                txtNumber.Text = "0";
                txtSourceText.Text = null;
                cmbBoxTranslationLanguage.SelectedIndex = 0;
                txtTranslation.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Server is not available or not responding!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            //headwordsListBox.Sorted = true
            headwordsListBox.ResumeLayout();

            this.Enabled = true;
        }

        void headwordsListBoxSelectedIndexChanged(object sender, EventArgs e)
		{
            cmbBoxEntryType.SelectedIndex = 0;
            txtNumber.Text = "0";
            txtSourceText.Text = "";
            cmbBoxTranslationLanguage.SelectedIndex = 0;
            txtTranslation.Text = "";
            txtAttachmentTitle.Text = "";
            txtAttachmentTranslation.Text = "";

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

                    // sort entries by their number
                    currentHeadword.Entries.OrderBy(x => x.Number).ThenBy(x => x.EntryType);

                    for (int i = 0; i < currentHeadword.Entries.Count; i++)
                    {
                        switch (currentHeadword.Entries[i].EntryType)
	                    {
                            case "Entry":
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Entry: " + currentHeadword.Entries[i].Number);
                                break;
                            case "Subentry":
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Subentry: " + currentHeadword.Entries[i].Number);
                                break;
                            case "Reference":
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Reference: " + currentHeadword.Entries[i].Number);
                                break;
                            case "Combination":
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Combination: " + currentHeadword.Entries[i].Number);
                                break;
                            default:
                                 break;
	                    }
                            

                        entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Number: " + currentHeadword.Entries[i].Number);
                        entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Source: " + currentHeadword.Entries[i].SourceText);
                        entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Translation: " + currentHeadword.Entries[i].Translation);
                    }

                    for (int j = 0; j < entriesTreeView.Nodes[0].Nodes[3].Nodes.Count; j++)
                    {
                        if (entriesTreeView.Nodes[0].Nodes[3].Nodes[j].Text.Contains("Entry: ") | entriesTreeView.Nodes[0].Nodes[3].Nodes[j].Text.Contains("Reference: ") | entriesTreeView.Nodes[0].Nodes[3].Nodes[j].Text.Contains("Combination: "))
                        {
                            entriesTreeView.Nodes[0].Nodes[3].Nodes[j].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Bold);
                        }
                    }
                }
            }

            entriesTreeView.TopNode.ExpandAll();
            entriesTreeView.TopNode = entriesTreeView.Nodes[0];

            if (currentHeadword.Attachment != null)
            {
                txtAttachment.Text = currentHeadword.Attachment.FileName;
                txtAttachmentColumns.Text = currentHeadword.Attachment.Column.ToString();
                txtAttachmentTitle.Text = String.IsNullOrWhiteSpace(currentHeadword.Attachment.Title) ? "" : currentHeadword.Attachment.Title;
                txtAttachmentTranslation.Text = String.IsNullOrWhiteSpace(currentHeadword.Attachment.Translation) ? "" : currentHeadword.Attachment.Translation;
            }
            else
            {
                txtAttachment.Text = String.Empty;
                txtAttachmentColumns.Text = String.Empty;
                txtAttachmentTitle.Text = String.Empty;
                txtAttachmentTranslation.Text = String.Empty;
            }

            btnAddHeadword.Enabled = true;
            btnDeleteHeadword.Enabled = true;
            btnDeleteEntry.Enabled = false;
            btnSaveHeadword.Enabled = false;
            btnSaveEntry.Enabled = false;
            btnAddEntry.Enabled = true;
            //btnAddEntry.Enabled = (currentHeadword.Entries == null) ? true : false;
            btnAddUpdateAttachment.Enabled = true;
            btnRemoveAttachment.Enabled = (currentHeadword.Attachment == null) ? false : true;

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
                                if (currentHeadword.Entries[i].SourceText != null)
                                {
                                    entryTemplate.Add("deutschEntry", currentHeadword.Entries[i].SourceText.Replace("<", "&lt;").Replace(">", "&gt;")); //.Replace("⌘", "&#8984;"));
                                }

                                if (currentHeadword.Entries[i].Translation != null)
                                {
                                    entryTemplate.Add("persianEntry", currentHeadword.Entries[i].Translation.Replace("<", "&lt;").Replace(">", "&gt;")); //.Replace("⌘", "&#8984;"));
                                }
                            }
                            else
                            {
                                if (currentHeadword.Entries[i].SourceText != null)
                                {
                                    entryTemplate.Add("deutschEntry", currentHeadword.Entries[i].Number + ". " + currentHeadword.Entries[i].SourceText.Replace("<", "&lt;").Replace(">", "&gt;")); //.Replace("⌘", "&#8984;"));
                                }
                                else
                                {
                                    entryTemplate.Add("deutschEntry", currentHeadword.Entries[i].Number + "."); //.Replace("⌘", "&#8984;"));
                                }

                                if (currentHeadword.Entries[i].Translation != null)
                                {
                                    entryTemplate.Add("persianEntry", currentHeadword.Entries[i].Translation.Replace("<", "&lt;").Replace(">", "&gt;")); //.Replace("⌘", "&#8984;")
                                }
                            }
                            entries += entryTemplate.Render();
                        }
                        else
                        {
                            if (currentHeadword.Entries[i].SourceText != null)
                            {
                                subentryTemplate.Add("deutschSubentry", currentHeadword.Entries[i].SourceText.Replace("<", "&lt;").Replace(">", "&gt;")); //.Replace("⌘", "&#8984;"));
                            }

                            if (currentHeadword.Entries[i].Translation != null)
                            {
                                subentryTemplate.Add("persianSubentry", currentHeadword.Entries[i].Translation.Replace("<", "&lt;").Replace(">", "&gt;")); //.Replace("⌘", "&#8984;"));
                            }
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
                    char[] separator = new char[] {':'};
                    foreach (var item in currentHeadword.Entries)
                    {
                        if ((item.Number == entriesTreeView.SelectedNode.Text.Replace("Entry: ", "").Replace("Subentry: ", "").Replace("Reference: ", "").Replace("Combination: ", "") |
                            item.Number == entriesTreeView.SelectedNode.Parent.Text.Replace("Entry: ", "").Replace("Subentry: ", "").Replace("Reference: ", "").Replace("Combination: ", "")) &
                            (item.EntryType == entriesTreeView.SelectedNode.Text.Split(separator)[0] | item.EntryType == entriesTreeView.SelectedNode.Parent.Text.Split(separator)[0]))
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
            //previewGroupBox.Height = entriesGroupBox.Height + headwordGroupBox.Height + attributesGroupBox.Height + 12;
            attachmentGroupBox.Visible = true;
            manualHeadwordSorterGrpBox.Visible = false;
        }

        private void finishEditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            headwordsListGroupBox.Visible = false;
            entriesGroupBox.Visible = false;
            headwordGroupBox.Visible = false;
            attributesGroupBox.Visible = false;
            previewGroupBox.Visible = false;
            attachmentGroupBox.Visible = false;
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

            try
            {
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

                toolStripResult.Text = "Letter " + cmbBoxLetter4Sort.SelectedItem.ToString() + "'s Headword Count = " + collection.Count().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Server is not available or not responding!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

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
            int count = 0;
            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter4Sort.SelectedItem.ToString());
            BsonDocument response = new BsonDocument();
            WriteConcernResult result = new WriteConcernResult(response: response);

            for (int i = 0; i < newTableForUpdatingPriorities.Rows.Count; i++)
			{
                result = collection.Update(Query.EQ("Lemma", newTableForUpdatingPriorities.Rows[i].ItemArray[0].ToString()), MongoDB.Driver.Builders.Update.Set("Priority", (i + 1)));
                count++;
			}

            if (result.DocumentsAffected <= 0)
            {
                txtStatus.Text = "No record has been saved!";
            }
            else
            {
                txtStatus.Text = "Saved " + count.ToString() + " records successfully!";
                cmbBoxLetter4Sort_SelectedIndexChanged(sender, e);
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
                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Lemma", txtLemma.Text.Trim()));

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
                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Pronunciation", txtPronunciation.Text.Trim()));
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
                    updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Description", txtDescription.Text.Trim()));
                }
            }
            else
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Description", BsonNull.Value));
            }

            if (chkIncomplete.Checked != currentHeadword.Incomplete)
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("Incomplete", chkIncomplete.Checked));
            }

            if (DateTime.Now != currentHeadword.ModificationDateTime)
            {
                updateHeadword.Add(MongoDB.Driver.Builders.Update.Set("ModificationDateTime", new BsonDateTime(DateTime.Now)));
            }

            UpdateBuilder update = MongoDB.Driver.Builders.Update.Combine(updateHeadword);

            WriteConcernResult result = collection.Update(Query.EQ("_id", currentHeadwordObjectID), update, UpdateFlags.Upsert);
            if (result.DocumentsAffected == 1)
            {
                toolStripResult.Text = "Result: Headword saved successfully!";
                btnSaveHeadword.Enabled = false;
                headwordsListBox.SelectedItem = txtLemma.Text;
                headwordsListBoxSelectedIndexChanged(sender, e);
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

            if (cmbBoxEntryType.SelectedItem.ToString() == "Entry" | cmbBoxEntryType.SelectedItem.ToString() == "Subentry")
            {
                if (!String.IsNullOrWhiteSpace(txtTranslation.Text))
                {
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
                }
            }

            if (cmbBoxEntryType.SelectedItem.ToString() == "Entry" | cmbBoxEntryType.SelectedItem.ToString() == "Subentry")
            {
                if (!String.IsNullOrWhiteSpace(txtTranslation.Text))
                {
                    string translation = String.IsNullOrWhiteSpace(txtTranslation.Text) ? null : txtTranslation.Text;

                    if (translation != currentEntry.Translation)
                    {
                        updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.Translation", txtTranslation.Text.Trim()));
                    }
                }
                else
                {
                    updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.TranslationLanguage", BsonNull.Value));
                    updateEntry.Add(MongoDB.Driver.Builders.Update.Set("Entries.$.Translation", BsonNull.Value));
                }
            }

            UpdateBuilder update = MongoDB.Driver.Builders.Update.Combine(updateEntry);

            var query = Query.And(Query.EQ("_id", currentHeadwordObjectID),
                Query.ElemMatch("Entries",
                    Query.And(
                        Query.And(Query.EQ("Number", currentEntry.Number), Query.EQ("EntryType", currentEntry.EntryType)),
                        Query.Or(Query.EQ("SourceText", String.IsNullOrWhiteSpace(currentEntry.SourceText) ? "{$type: 6}" : currentEntry.SourceText),
                                 Query.EQ("Translation", String.IsNullOrWhiteSpace(currentEntry.Translation) ? "{$type: 6}" : currentEntry.Translation))
                        )));

            WriteConcernResult result = collection.Update(query, update, UpdateFlags.Upsert);
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

            string source = String.IsNullOrWhiteSpace(txtSourceText.Text) ? null : txtSourceText.Text.Trim();

            string lang = cmbBoxTranslationLanguage.SelectedItem.ToString() == "Persisch" ? "FA" : "DE";
            string translang = String.IsNullOrWhiteSpace(txtTranslation.Text) ? null : lang;

            string trans = String.IsNullOrWhiteSpace(txtTranslation.Text) ? null : txtTranslation.Text.Trim();

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

        private void btnAddHeadword_Click(object sender, EventArgs e)
        {
            collection = farhang_database.GetCollection<Headword>(cmbBoxLetter.SelectedItem.ToString());
            //var maxPriority = collection.FindAll().SetSortOrder(SortBy.Descending("Priority")).SetLimit(1);
            //var max = 1;
            //foreach (var item in maxPriority)
            //{
            //    max = item.Priority;
            //}

            string lemma = null;
            string word = null;
            string pronunciation = null;
            string description = null;

            if (!String.IsNullOrWhiteSpace(txtLemma.Text))
            {
                lemma = txtLemma.Text.Trim();
                word = lemma;

                foreach (var item in special_characters)
                {
                    word = word.Replace(item, "");
                }
            }

            pronunciation = String.IsNullOrWhiteSpace(txtPronunciation.Text) ? null : txtPronunciation.Text.Trim();

            description = String.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();

            Headword newHeadword = new Headword(lemma, word, pronunciation, description, currentHeadword.Priority, chkIncomplete.Checked, DateTime.Now, DateTime.Now);

            WriteConcernResult result = collection.Insert(newHeadword);
            if (result.DocumentsAffected <= 0)
            {
                toolStripResult.Text = "Result: Error creating headword!";
            }
            else
            {
                toolStripResult.Text = "Result: Headword created successfully!";
                cmbBoxLetterSelectedIndexChanged(sender, e);
            }

            BsonDocument response = new BsonDocument();
            WriteConcernResult priorityUpdateResult = new WriteConcernResult(response: response);
            for (int i = 0; i < headwordsListBox.Items.Count; i++)
            {
                priorityUpdateResult = collection.Update(Query.EQ("Lemma", headwordsListBox.Items[i].ToString()), MongoDB.Driver.Builders.Update.Set("Priority", (i + 1)), UpdateFlags.Multi);
            }

            if (priorityUpdateResult.DocumentsAffected > 0)
            {
                txtStatus.Text = "Saved " + result.DocumentsAffected.ToString() + " records successfully!";
            }
            else
            {
                txtStatus.Text = "No record has been saved!";
            }
        }

        private void btnAddUpdateAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF (*.pdf)|*.pdf;|PS/EPS (*.ps *.eps)|*.ps;*.eps|TIFF (*.tiff *.tif)|*.tif;*.tiff|JPEG/JPG (*.jpeg *.jpg)|*.jpg;*.jpeg|PNG (*.png)|*.png;|All files (*.*)|*.*";
            DialogResult result = openFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // read file content as byte array
                byte[] file_contents = File.ReadAllBytes(openFile.FileName);

                // write it to database with its name and extension
                var gfsFile = gridFS.Create(openFile.SafeFileName);
                gfsFile.Write(file_contents, 0, file_contents.Length);
                gfsFile.Close();

                // add file info to headword
                MongoGridFSFileInfo file = new MongoGridFSFileInfo(gridFS, openFile.SafeFileName);
                currentHeadword.AddAttachment(file.Id.AsObjectId, file.Name.ToString(), int.Parse(txtAttachmentColumns.Text), txtAttachmentTitle.Text, txtAttachmentTranslation.Text);

                var update = MongoDB.Driver.Builders.Update.Set("Attachment", currentHeadword.Attachment.ToBsonDocument());

                WriteConcernResult writeResult = collection.Update(Query.EQ("_id", currentHeadwordObjectID), update, UpdateFlags.Upsert);
                if (writeResult.DocumentsAffected == 1)
                {

                    toolStripResult.Text = String.IsNullOrWhiteSpace(txtAttachment.Text) ? "Result: Attachment added successfully!" : "Result: Attachment updated successfully!";
                    txtAttachment.Text = file.Name;
                }
                else
                {
                    toolStripResult.Text = "Result: Error adding attachment!";
                }
            }
        }

        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove attachment (file) '" + txtAttachment.Text + "' and its references?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                MongoGridFSFileInfo file = new MongoGridFSFileInfo(gridFS, currentHeadword.Attachment.FileName);
                file.Delete();

                var update = MongoDB.Driver.Builders.Update.Unset("Attachment");

                WriteConcernResult writeResult = collection.Update(Query.EQ("_id", currentHeadwordObjectID), update, UpdateFlags.Upsert);
                if (writeResult.DocumentsAffected == 1)
                {

                    toolStripResult.Text = "Result: Attachment removed successfully!";
                    txtAttachment.Text = String.Empty;
                    btnRemoveAttachment.Enabled = false;
                }
                else
                {
                    toolStripResult.Text = "Result: Error removing attachment!";
                }
            }
        }

        private void txtAttachment_TextChanged(object sender, EventArgs e)
        {
            if (txtAttachment.Text != String.Empty)
            {
                btnRemoveAttachment.Enabled = true;
            }
        }

        private void pDFBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDFBuilder pdfBuilderFrm = new PDFBuilder();
            pdfBuilderFrm.ShowDialog();
        }

        private void mobileDatabaseExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MobileDBExporter mobileDBExporterFrm = new MobileDBExporter();
            mobileDBExporterFrm.ShowDialog();
        }
	}
}
