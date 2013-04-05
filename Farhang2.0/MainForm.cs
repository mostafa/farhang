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
using Npgsql;
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
        List<String> dbList = new List<string>();
		Dictionary<String, NpgsqlConnection> connectionPool = new Dictionary<string,NpgsqlConnection>();
        Dictionary<String, NpgsqlCommand> selectCommandPool = new Dictionary<string, NpgsqlCommand>();
        Dictionary<String, NpgsqlDataAdapter> dataAdapterPool = new Dictionary<string, NpgsqlDataAdapter>();
        Dictionary<String, DataSet> dataSetPool = new Dictionary<string, DataSet>();
        int currentHeadwordID = 0;
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

        void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
            this.Enabled = false;
            headwordsListBox.Items.Clear();
            txtSelectedAlphabet.Text = cmbBoxAlphabet.SelectedItem.ToString();
            txtHeadwordsCount.Text = "0";

            dbList = Farhang2._0.Database.getDBList(cmbBoxAlphabet.SelectedItem.ToString());

            String queryAllHeadwords = "select \"Headword\".\"Lemma\" from \"Headword\" ORDER BY \"Headword\".\"ID\" ASC;";
            foreach (var item in dbList)
            {
                connectionPool[item.ToString()] = new NpgsqlConnection();
                connectionPool[item.ToString()].ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=dotnet;Database=" + item.ToString() + ";Encoding=UNICODE";
                try
                {
                    connectionPool[item.ToString()].Open();
                    if (connectionPool[item.ToString()].State == ConnectionState.Open)
                    {
                        selectCommandPool[item.ToString()] = new NpgsqlCommand(queryAllHeadwords, connectionPool[item.ToString()]);
                        dataAdapterPool[item.ToString()] = new NpgsqlDataAdapter(selectCommandPool[item.ToString()]);
                        dataSetPool[item.ToString()] = new DataSet();
                        dataAdapterPool[item.ToString()].Fill(dataSetPool[item.ToString()]);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(item.ToString() + ": Connection Error!!! Make sure you have started your PostgreSQL 8.4 instance!");
                    return;
                }

                headwordsListBox.SuspendLayout();

                for (int i = 0; i < dataSetPool[item.ToString()].Tables[0].Rows.Count; i++)
                {
                    headwordsListBox.Items.Add(dataSetPool[item.ToString()].Tables[0].Rows[i].ItemArray[0].ToString());
                    txtHeadwordsCount.Text = (Convert.ToInt32(txtHeadwordsCount.Text) + 1).ToString();
                }

                //headwordsListBox.Sorted = true;
                headwordsListBox.ResumeLayout();

                if (connectionPool[item.ToString()].State == ConnectionState.Open)
                {
                    connectionPool[item.ToString()].Close();
                }
            }

            this.Enabled = true;
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
            cmbBoxType.SelectedIndex = 0;
            txtNumber.Value = 0;
            txtSourceText.Text = "";
            cmbBoxDestinationLanguage.SelectedIndex = 0;
            txtTranslation.Text = "";

            foreach (var item in connectionPool.Keys)
            {
                try
                {
                    if (connectionPool[item].State == ConnectionState.Closed)
                    {
                        connectionPool[item].Open();
                    }

                    selectCommandPool[item] = new NpgsqlCommand("select \"ID\", \"Lemma\", \"Pronunciation\", \"Description\", \"Finished\" from \"Headword\" WHERE \"Headword\".\"Lemma\" = '" + headwordsListBox.SelectedItem.ToString().Replace("\'", "\\'") + "' ORDER BY \"Headword\".\"ID\" ASC;", connectionPool[item]);
                    dataAdapterPool[item] = new NpgsqlDataAdapter(selectCommandPool[item]);
                    dataSetPool[item] = new DataSet();
                    dataAdapterPool[item].Fill(dataSetPool[item]);
                    if ((dataSetPool[item].Tables.Count > 0) & (dataSetPool[item].Tables[0].Rows.Count > 0))
                    {
                        currentHeadwordID = Convert.ToInt32(dataSetPool[item].Tables[0].Rows[0].ItemArray[0]);
                        txtLemma.Text = dataSetPool[item].Tables[0].Rows[0].ItemArray[1].ToString();
                        txtPronunciation.Text = dataSetPool[item].Tables[0].Rows[0].ItemArray[2].ToString();
                        txtDescription.Text = dataSetPool[item].Tables[0].Rows[0].ItemArray[3].ToString();
                        // Finished: TRUE -> Incomplete: FALSE
                        // Finished: FALSE -> Incomplete: TRUE
                        chkIncomplete.Checked = Convert.ToBoolean(dataSetPool[item].Tables[0].Rows[0].ItemArray[4]) == false ? true : false;
                        dataSetPool[item].Dispose();
                        break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection Error!!! Make sure you have started your PostgreSQL 8.4 instance!");
                    return;
                }

                if (connectionPool[item.ToString()].State == ConnectionState.Open)
                {
                    connectionPool[item.ToString()].Close();
                }
            }

            entriesTreeView.Nodes.Clear();
            foreach (var item in dataSetPool.Keys)
            {
                dataSetPool[item].Clear();
            }

            // construct headword structure
            entriesTreeView.Nodes.Add("Headword");
            entriesTreeView.Nodes[0].Nodes.Add("Lemma: " + txtLemma.Text);
            entriesTreeView.Nodes[0].Nodes[0].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Bold);
            entriesTreeView.Nodes[0].Nodes.Add(String.IsNullOrWhiteSpace(txtPronunciation.Text) ? "Pronunciation: " : "Pronuncation: [" + txtPronunciation.Text + "]");
            entriesTreeView.Nodes[0].Nodes[1].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Regular);
            entriesTreeView.Nodes[0].Nodes.Add(String.IsNullOrWhiteSpace(txtDescription.Text) ? "Description: " : "Description: " + txtDescription.Text);
            entriesTreeView.Nodes[0].Nodes[2].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Italic);

            foreach (var item in connectionPool.Keys)
            {
                try
                {
                    if (connectionPool[item].State == ConnectionState.Closed)
                    {
                        connectionPool[item].Open();
                    }

                    selectCommandPool[item] = new NpgsqlCommand("SELECT \"Entry\".\"ID\", \"Entry\".\"PID\", \"Entry\".\"Type\", \"Entry\".\"Data\", \"Entry\".\"Number\", \"Translation\".\"ID\", \"Translation\".\"PID\", \"Translation\".\"LID\", \"Translation\".\"Data\", \"Headword\".\"Lemma\" FROM \"Entry\", \"Translation\", \"Headword\" WHERE \"Translation\".\"PID\" = \"Entry\".\"ID\" AND \"Entry\".\"PID\" = " + currentHeadwordID.ToString() + " AND \"Headword\".\"Lemma\" = '" + txtLemma.Text.ToString().Replace("\'", "\\'") + "' ORDER BY \"Entry\".\"ID\" ASC;", connectionPool[item]);
                    dataAdapterPool[item] = new NpgsqlDataAdapter(selectCommandPool[item]);
                    dataSetPool[item] = new DataSet();
                    dataAdapterPool[item].Fill(dataSetPool[item]);

                    if ((dataSetPool[item].Tables.Count > 0) & (dataSetPool[item].Tables[0].Rows.Count > 0))
                    {
                        // construct entry structure
                        entriesTreeView.Nodes[0].Nodes.Add("Entries");

                        for (int i = 0; i < dataSetPool[item].Tables[0].Rows.Count; i++)
                        {
                            int entryNumber = Convert.ToInt32(dataSetPool[item].Tables[0].Rows[i].ItemArray[4]);
                            if (entryNumber == 0 && i == 0)
                            {
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Entry: " + dataSetPool[item].Tables[0].Rows[i].ItemArray[0].ToString());
                            }
                            else if (entryNumber == 0)
                            {
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Subentry: " + dataSetPool[item].Tables[0].Rows[i].ItemArray[0].ToString());
                            }
                            else
                            {
                                entriesTreeView.Nodes[0].Nodes[3].Nodes.Add("Entry: " + dataSetPool[item].Tables[0].Rows[i].ItemArray[0].ToString());
                            }

                            for (int j = 0; j < entriesTreeView.Nodes[0].Nodes[3].Nodes.Count; j++)
                            {
                                if (entriesTreeView.Nodes[0].Nodes[3].Nodes[j].Text.Contains("Entry: "))
                                {
                                    entriesTreeView.Nodes[0].Nodes[3].Nodes[j].NodeFont = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 8, FontStyle.Bold);
                                }
                            }
                            entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Number: " + dataSetPool[item].Tables[0].Rows[i].ItemArray[4].ToString());
                            entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Source: " + dataSetPool[item].Tables[0].Rows[i].ItemArray[3].ToString());
                            entriesTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add("Translation: " + dataSetPool[item].Tables[0].Rows[i].ItemArray[8].ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection Error!!! Make sure you have started your PostgreSQL 8.4 instance!");
                    return;
                }

                if (connectionPool[item.ToString()].State == ConnectionState.Open)
                {
                    connectionPool[item.ToString()].Close();
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
            headwordTemplate.Add("Headword", txtLemma.Text.ToString());
            headwordTemplate.Add("Pronunciation", String.IsNullOrWhiteSpace(txtPronunciation.Text.ToString()) ? "" : "[" + txtPronunciation.Text.ToString() + "]");
            headwordTemplate.Add("Description", txtDescription.Text.ToString());

            entries += headwordTemplate.Render();

            foreach (var item in dataSetPool.Keys)
            {
                if ((dataSetPool[item].Tables.Count > 0) & (dataSetPool[item].Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < dataSetPool[item].Tables[0].Rows.Count; i++)
                    {
                        Template entryTemplate = new Template("<div class='inline'><span><p id='deutschEntry'>$deutschEntry$</p><wbr /><p id='persianEntry'>$persianEntry$</p></span></div><br />", '$', '$');
                        Template subentryTemplate = new Template("<div class='inline'><span><p id='deutschSubentry'>$deutschSubentry$</p><wbr /><p id='persianSubentry'>$persianSubentry$</p></span></div><br />", '$', '$');

                        int entryNumber = Convert.ToInt32(dataSetPool[item].Tables[0].Rows[i].ItemArray[4]);
                        if (entryNumber == 0 && i == 0)
                        {
                            entryTemplate.Add("deutschEntry", dataSetPool[item].Tables[0].Rows[i].ItemArray[3].ToString());
                            entryTemplate.Add("persianEntry", dataSetPool[item].Tables[0].Rows[i].ItemArray[8].ToString());
                            entries += entryTemplate.Render();
                        }
                        else if (entryNumber == 0)
                        {
                            subentryTemplate.Add("deutschSubentry", dataSetPool[item].Tables[0].Rows[i].ItemArray[3].ToString());
                            subentryTemplate.Add("persianSubentry", dataSetPool[item].Tables[0].Rows[i].ItemArray[8].ToString());
                            entries += subentryTemplate.Render();
                        }
                        else
                        {
                            entryTemplate.Add("deutschEntry", entryNumber + ". " + dataSetPool[item].Tables[0].Rows[i].ItemArray[3].ToString());
                            entryTemplate.Add("persianEntry", entryNumber + ". " + dataSetPool[item].Tables[0].Rows[i].ItemArray[8].ToString());
                            entries += entryTemplate.Render();
                        }
                    }
                }
            }
            

            return htmlDocString.Replace("$entries$", entries);
        }

        void entriesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (var item in dataSetPool.Keys)
            {
                if ((dataSetPool[item].Tables.Count > 0) & (dataSetPool[item].Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < dataSetPool[item].Tables[0].Rows.Count; i++)
                    {
                        if (dataSetPool[item].Tables[0].Rows[i].ItemArray[0].ToString() == entriesTreeView.SelectedNode.Text.Replace("Entry: ", "").Replace("Subentry: ", ""))
                        {
                            switch (dataSetPool[item].Tables[0].Rows[i].ItemArray[2].ToString())
                            {
                                case "E":
                                    cmbBoxType.SelectedIndex = 0;
                                    break;
                                case "S":
                                    cmbBoxType.SelectedIndex = 1;
                                    break;
                                default:
                                    cmbBoxType.SelectedIndex = 0;
                                    break;
                            }

                            txtNumber.Value = Convert.ToInt32(dataSetPool[item].Tables[0].Rows[i].ItemArray[4]);

                            txtSourceText.Text = dataSetPool[item].Tables[0].Rows[i].ItemArray[3].ToString();

                            if (dataSetPool[item].Tables[0].Rows[i].ItemArray[7].ToString() == "2")
                            {
                                //persisch
                                cmbBoxDestinationLanguage.SelectedIndex = 0;
                            }
                            else
                            {
                                //deutsch
                                cmbBoxDestinationLanguage.SelectedIndex = 1;
                            }

                            txtTranslation.Text = dataSetPool[item].Tables[0].Rows[i].ItemArray[8].ToString();
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
                ipaForm = new _0.IPAKeyboard(this, textview);
                ipaForm.FormClosed += new FormClosedEventHandler(ipa_FormClosed);
                ipaForm.Show();
            }
        }
	}
}
