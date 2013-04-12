/*
 * Developer: Mostafa Moradian
 * Date: 2/12/2013
 * Time: 2:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
        Form ipaForm;
        MongoClient client;
        MongoServer server;
        MongoDatabase farhang_database;
        MongoCollection<Headword> collection;
        MongoCursor<Headword> collection_data;
        Headword currentHeadword;
        BsonObjectId currentHeadwordObjectID;
        DataSet priorityDataSet;
        DataTable newTableForUpdatingPriorities;
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

            client = new MongoClient();
            server = client.GetServer();
            farhang_database = server.GetDatabase("farhang");
        }

        void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
            this.Enabled = false;
            headwordsListBox.Items.Clear();
            txtSelectedAlphabet.Text = cmbBoxAlphabet.SelectedItem.ToString();
            txtHeadwordsCount.Text = "0";

            headwordsListBox.SuspendLayout();

            collection = farhang_database.GetCollection<Headword>(cmbBoxAlphabet.SelectedItem.ToString().ToUpper());
            collection_data = collection.FindAllAs<Headword>().SetSortOrder("Priority");

            foreach (var item in collection_data)
            {
                headwordsListBox.Items.Add(item.Lemma);
                txtHeadwordsCount.Text = (Convert.ToInt32(txtHeadwordsCount.Text) + 1).ToString();
            }

            //headwordsListBox.Sorted = true;
            headwordsListBox.ResumeLayout();

            this.Enabled = true;
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
            cmbBoxType.SelectedIndex = 0;
            txtNumber.Text = "0";
            txtSourceText.Text = "";
            cmbBoxDestinationLanguage.SelectedIndex = 0;
            txtTranslation.Text = "";

            currentHeadword = collection.FindOneAs<Headword>(Query.EQ("Lemma", headwordsListBox.SelectedItem.ToString()));

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
                            cmbBoxType.Text = item.EntryType;

                            txtNumber.Text = item.Number;

                            txtSourceText.Text = item.SourceText;

                            if (item.TranslationLanguage == "FA")
                            {
                                //persisch
                                cmbBoxDestinationLanguage.SelectedIndex = 0;
                            }
                            else
                            {
                                //deutsch
                                cmbBoxDestinationLanguage.SelectedIndex = 1;
                            }

                            txtTranslation.Text = item.Translation;
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

        private void cmbBoxAlphabet4Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            //dataGridView4Sort.Rows.Clear();

            headwordsListBox.SuspendLayout();

            collection = farhang_database.GetCollection<Headword>(cmbBoxAlphabet4Sort.SelectedItem.ToString().ToUpper());
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

            lblTotal.Text = "Total: " + collection_data.Count().ToString();
            lblTotal.Visible = true;
            headwordsListBox.ResumeLayout();

            this.Enabled = true;
        }

        private void dataGridView4Sort_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            priorityDataSet.Tables[0].AcceptChanges();
            priorityDataSet.Tables[0].DefaultView.Sort = "Priority ASC";

            var newTableForUpdatingPriorities = priorityDataSet.Tables[0].DefaultView.ToTable("Headwords");

            btnSavePriorityList.Enabled = true;
        }

        private void btnSavePriorityList_Click(object sender, EventArgs e)
        {
            collection = farhang_database.GetCollection<Headword>(cmbBoxAlphabet4Sort.SelectedItem.ToString());
            for (int i = 0; i < newTableForUpdatingPriorities.Rows.Count; i++)
			{
                collection.Update(Query.EQ("Lemma", newTableForUpdatingPriorities.Rows[i].ItemArray[0].ToString()), MongoDB.Driver.Builders.Update.Set("Priority", (i + 1)));
			}
        }
	}
}
