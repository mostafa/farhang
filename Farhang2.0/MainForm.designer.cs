/*
 * User: Mostafa Moradian
 * Date: 2/12/2013
 * Time: 2:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Farhang2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Headword");
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.headwordsListBox = new System.Windows.Forms.ListBox();
            this.cmbBoxAlphabet = new System.Windows.Forms.ComboBox();
            this.lblAlphabet = new System.Windows.Forms.Label();
            this.headwordsListGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.headwordGroupBox = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPronunciation = new System.Windows.Forms.Label();
            this.lblLemma = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPronunciation = new System.Windows.Forms.TextBox();
            this.txtLemma = new System.Windows.Forms.TextBox();
            this.entriesTreeView = new System.Windows.Forms.TreeView();
            this.entriesGroupBox = new System.Windows.Forms.GroupBox();
            this.attributesGroupBox = new System.Windows.Forms.GroupBox();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.txtTranslation = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.cmbBoxDestinationLanguage = new System.Windows.Forms.ComboBox();
            this.cmbBoxType = new System.Windows.Forms.ComboBox();
            this.txtSourceText = new System.Windows.Forms.TextBox();
            this.lblTranslation = new System.Windows.Forms.Label();
            this.lblDestinationLanguage = new System.Windows.Forms.Label();
            this.lblSourceText = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.btnViewStatistics = new System.Windows.Forms.Button();
            this.txtSubentriesCount = new System.Windows.Forms.TextBox();
            this.lblSubentriesCount = new System.Windows.Forms.Label();
            this.txtEntriesCount = new System.Windows.Forms.TextBox();
            this.txtSelectedAlphabet = new System.Windows.Forms.TextBox();
            this.txtHeadwordsCount = new System.Windows.Forms.TextBox();
            this.lblEntriesCount = new System.Windows.Forms.Label();
            this.lblHeadwordsCount = new System.Windows.Forms.Label();
            this.lblSelectedAlphabet = new System.Windows.Forms.Label();
            this.chkIncomplete = new System.Windows.Forms.CheckBox();
            this.headwordsListGroupBox.SuspendLayout();
            this.headwordGroupBox.SuspendLayout();
            this.entriesGroupBox.SuspendLayout();
            this.attributesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            this.groupBoxPreview.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1056, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // headwordsListBox
            // 
            this.headwordsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headwordsListBox.FormattingEnabled = true;
            this.headwordsListBox.ItemHeight = 15;
            this.headwordsListBox.Location = new System.Drawing.Point(6, 75);
            this.headwordsListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headwordsListBox.Name = "headwordsListBox";
            this.headwordsListBox.Size = new System.Drawing.Size(211, 499);
            this.headwordsListBox.TabIndex = 2;
            this.headwordsListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
            // 
            // cmbBoxAlphabet
            // 
            this.cmbBoxAlphabet.ItemHeight = 15;
            this.cmbBoxAlphabet.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cmbBoxAlphabet.Location = new System.Drawing.Point(75, 20);
            this.cmbBoxAlphabet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbBoxAlphabet.Name = "cmbBoxAlphabet";
            this.cmbBoxAlphabet.Size = new System.Drawing.Size(140, 23);
            this.cmbBoxAlphabet.TabIndex = 0;
            this.cmbBoxAlphabet.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // lblAlphabet
            // 
            this.lblAlphabet.Location = new System.Drawing.Point(5, 21);
            this.lblAlphabet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlphabet.Name = "lblAlphabet";
            this.lblAlphabet.Size = new System.Drawing.Size(69, 20);
            this.lblAlphabet.TabIndex = 3;
            this.lblAlphabet.Text = "Alphabet:";
            // 
            // headwordsListGroupBox
            // 
            this.headwordsListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.headwordsListGroupBox.Controls.Add(this.textBox1);
            this.headwordsListGroupBox.Controls.Add(this.lblSearch);
            this.headwordsListGroupBox.Controls.Add(this.cmbBoxAlphabet);
            this.headwordsListGroupBox.Controls.Add(this.lblAlphabet);
            this.headwordsListGroupBox.Controls.Add(this.headwordsListBox);
            this.headwordsListGroupBox.Location = new System.Drawing.Point(11, 52);
            this.headwordsListGroupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headwordsListGroupBox.Name = "headwordsListGroupBox";
            this.headwordsListGroupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headwordsListGroupBox.Size = new System.Drawing.Size(220, 589);
            this.headwordsListGroupBox.TabIndex = 2;
            this.headwordsListGroupBox.TabStop = false;
            this.headwordsListGroupBox.Text = "Headwords\' List";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 23);
            this.textBox1.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(5, 52);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(56, 15);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search:";
            // 
            // headwordGroupBox
            // 
            this.headwordGroupBox.Controls.Add(this.lblDescription);
            this.headwordGroupBox.Controls.Add(this.lblPronunciation);
            this.headwordGroupBox.Controls.Add(this.lblLemma);
            this.headwordGroupBox.Controls.Add(this.txtDescription);
            this.headwordGroupBox.Controls.Add(this.txtPronunciation);
            this.headwordGroupBox.Controls.Add(this.txtLemma);
            this.headwordGroupBox.Location = new System.Drawing.Point(236, 52);
            this.headwordGroupBox.Name = "headwordGroupBox";
            this.headwordGroupBox.Size = new System.Drawing.Size(457, 148);
            this.headwordGroupBox.TabIndex = 3;
            this.headwordGroupBox.TabStop = false;
            this.headwordGroupBox.Text = "Headword";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 82);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 15);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // lblPronunciation
            // 
            this.lblPronunciation.AutoSize = true;
            this.lblPronunciation.Location = new System.Drawing.Point(6, 53);
            this.lblPronunciation.Name = "lblPronunciation";
            this.lblPronunciation.Size = new System.Drawing.Size(95, 15);
            this.lblPronunciation.TabIndex = 4;
            this.lblPronunciation.Text = "Pronuncation:";
            // 
            // lblLemma
            // 
            this.lblLemma.AutoSize = true;
            this.lblLemma.Location = new System.Drawing.Point(6, 24);
            this.lblLemma.Name = "lblLemma";
            this.lblLemma.Size = new System.Drawing.Size(60, 15);
            this.lblLemma.TabIndex = 3;
            this.lblLemma.Text = "Lemma:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 78);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(341, 65);
            this.txtDescription.TabIndex = 2;
            // 
            // txtPronunciation
            // 
            this.txtPronunciation.Location = new System.Drawing.Point(110, 48);
            this.txtPronunciation.Name = "txtPronunciation";
            this.txtPronunciation.Size = new System.Drawing.Size(341, 23);
            this.txtPronunciation.TabIndex = 1;
            // 
            // txtLemma
            // 
            this.txtLemma.Location = new System.Drawing.Point(110, 20);
            this.txtLemma.Name = "txtLemma";
            this.txtLemma.Size = new System.Drawing.Size(341, 23);
            this.txtLemma.TabIndex = 0;
            // 
            // entriesTreeView
            // 
            this.entriesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entriesTreeView.FullRowSelect = true;
            this.entriesTreeView.Location = new System.Drawing.Point(9, 22);
            this.entriesTreeView.Name = "entriesTreeView";
            treeNode2.Name = "Headword";
            treeNode2.Text = "Headword";
            this.entriesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.entriesTreeView.Size = new System.Drawing.Size(442, 277);
            this.entriesTreeView.TabIndex = 0;
            // 
            // entriesGroupBox
            // 
            this.entriesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entriesGroupBox.Controls.Add(this.entriesTreeView);
            this.entriesGroupBox.Location = new System.Drawing.Point(236, 201);
            this.entriesGroupBox.Name = "entriesGroupBox";
            this.entriesGroupBox.Size = new System.Drawing.Size(457, 305);
            this.entriesGroupBox.TabIndex = 4;
            this.entriesGroupBox.TabStop = false;
            this.entriesGroupBox.Text = "Entries";
            // 
            // attributesGroupBox
            // 
            this.attributesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.attributesGroupBox.Controls.Add(this.chkIncomplete);
            this.attributesGroupBox.Controls.Add(this.txtNumber);
            this.attributesGroupBox.Controls.Add(this.txtTranslation);
            this.attributesGroupBox.Controls.Add(this.lblNumber);
            this.attributesGroupBox.Controls.Add(this.cmbBoxDestinationLanguage);
            this.attributesGroupBox.Controls.Add(this.cmbBoxType);
            this.attributesGroupBox.Controls.Add(this.txtSourceText);
            this.attributesGroupBox.Controls.Add(this.lblTranslation);
            this.attributesGroupBox.Controls.Add(this.lblDestinationLanguage);
            this.attributesGroupBox.Controls.Add(this.lblSourceText);
            this.attributesGroupBox.Controls.Add(this.lblType);
            this.attributesGroupBox.Location = new System.Drawing.Point(236, 506);
            this.attributesGroupBox.Name = "attributesGroupBox";
            this.attributesGroupBox.Size = new System.Drawing.Size(457, 135);
            this.attributesGroupBox.TabIndex = 5;
            this.attributesGroupBox.TabStop = false;
            this.attributesGroupBox.Text = "Attributes";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.Location = new System.Drawing.Point(308, 18);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(143, 23);
            this.txtNumber.TabIndex = 1;
            // 
            // txtTranslation
            // 
            this.txtTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTranslation.Location = new System.Drawing.Point(96, 105);
            this.txtTranslation.Name = "txtTranslation";
            this.txtTranslation.Size = new System.Drawing.Size(355, 23);
            this.txtTranslation.TabIndex = 4;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(239, 22);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(63, 15);
            this.lblNumber.TabIndex = 9;
            this.lblNumber.Text = "Number:";
            // 
            // cmbBoxDestinationLanguage
            // 
            this.cmbBoxDestinationLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxDestinationLanguage.FormattingEnabled = true;
            this.cmbBoxDestinationLanguage.Items.AddRange(new object[] {
            "Persisch",
            "Deutsch"});
            this.cmbBoxDestinationLanguage.Location = new System.Drawing.Point(96, 76);
            this.cmbBoxDestinationLanguage.Name = "cmbBoxDestinationLanguage";
            this.cmbBoxDestinationLanguage.Size = new System.Drawing.Size(140, 23);
            this.cmbBoxDestinationLanguage.TabIndex = 3;
            // 
            // cmbBoxType
            // 
            this.cmbBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxType.FormattingEnabled = true;
            this.cmbBoxType.Items.AddRange(new object[] {
            "Entry",
            "Subentry"});
            this.cmbBoxType.Location = new System.Drawing.Point(96, 18);
            this.cmbBoxType.Name = "cmbBoxType";
            this.cmbBoxType.Size = new System.Drawing.Size(140, 23);
            this.cmbBoxType.TabIndex = 0;
            // 
            // txtSourceText
            // 
            this.txtSourceText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceText.Location = new System.Drawing.Point(96, 47);
            this.txtSourceText.Name = "txtSourceText";
            this.txtSourceText.Size = new System.Drawing.Size(355, 23);
            this.txtSourceText.TabIndex = 2;
            // 
            // lblTranslation
            // 
            this.lblTranslation.AutoSize = true;
            this.lblTranslation.Location = new System.Drawing.Point(6, 109);
            this.lblTranslation.Name = "lblTranslation";
            this.lblTranslation.Size = new System.Drawing.Size(79, 15);
            this.lblTranslation.TabIndex = 3;
            this.lblTranslation.Text = "Translation:";
            // 
            // lblDestinationLanguage
            // 
            this.lblDestinationLanguage.AutoSize = true;
            this.lblDestinationLanguage.Location = new System.Drawing.Point(6, 80);
            this.lblDestinationLanguage.Name = "lblDestinationLanguage";
            this.lblDestinationLanguage.Size = new System.Drawing.Size(84, 15);
            this.lblDestinationLanguage.TabIndex = 2;
            this.lblDestinationLanguage.Text = "Dest. Lang.:";
            // 
            // lblSourceText
            // 
            this.lblSourceText.AutoSize = true;
            this.lblSourceText.Location = new System.Drawing.Point(6, 51);
            this.lblSourceText.Name = "lblSourceText";
            this.lblSourceText.Size = new System.Drawing.Size(85, 15);
            this.lblSourceText.TabIndex = 1;
            this.lblSourceText.Text = "Source Text:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 15);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPreview.Controls.Add(this.webBrowser1);
            this.groupBoxPreview.Location = new System.Drawing.Point(699, 52);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(345, 407);
            this.groupBoxPreview.TabIndex = 6;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Preview";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.CausesValidation = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(3, 19);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(339, 385);
            this.webBrowser1.TabIndex = 0;
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStatistics.Controls.Add(this.btnViewStatistics);
            this.groupBoxStatistics.Controls.Add(this.txtSubentriesCount);
            this.groupBoxStatistics.Controls.Add(this.lblSubentriesCount);
            this.groupBoxStatistics.Controls.Add(this.txtEntriesCount);
            this.groupBoxStatistics.Controls.Add(this.txtSelectedAlphabet);
            this.groupBoxStatistics.Controls.Add(this.txtHeadwordsCount);
            this.groupBoxStatistics.Controls.Add(this.lblEntriesCount);
            this.groupBoxStatistics.Controls.Add(this.lblHeadwordsCount);
            this.groupBoxStatistics.Controls.Add(this.lblSelectedAlphabet);
            this.groupBoxStatistics.Location = new System.Drawing.Point(699, 465);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(345, 176);
            this.groupBoxStatistics.TabIndex = 7;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // btnViewStatistics
            // 
            this.btnViewStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewStatistics.Location = new System.Drawing.Point(139, 134);
            this.btnViewStatistics.Name = "btnViewStatistics";
            this.btnViewStatistics.Size = new System.Drawing.Size(200, 36);
            this.btnViewStatistics.TabIndex = 8;
            this.btnViewStatistics.Text = "View Full Statistics";
            this.btnViewStatistics.UseVisualStyleBackColor = true;
            // 
            // txtSubentriesCount
            // 
            this.txtSubentriesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubentriesCount.Location = new System.Drawing.Point(139, 105);
            this.txtSubentriesCount.Name = "txtSubentriesCount";
            this.txtSubentriesCount.ReadOnly = true;
            this.txtSubentriesCount.Size = new System.Drawing.Size(200, 23);
            this.txtSubentriesCount.TabIndex = 7;
            this.txtSubentriesCount.Text = "0";
            // 
            // lblSubentriesCount
            // 
            this.lblSubentriesCount.AutoSize = true;
            this.lblSubentriesCount.Location = new System.Drawing.Point(6, 109);
            this.lblSubentriesCount.Name = "lblSubentriesCount";
            this.lblSubentriesCount.Size = new System.Drawing.Size(125, 15);
            this.lblSubentriesCount.TabIndex = 6;
            this.lblSubentriesCount.Text = "Subentries\' Count:";
            // 
            // txtEntriesCount
            // 
            this.txtEntriesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntriesCount.Location = new System.Drawing.Point(139, 76);
            this.txtEntriesCount.Name = "txtEntriesCount";
            this.txtEntriesCount.ReadOnly = true;
            this.txtEntriesCount.Size = new System.Drawing.Size(200, 23);
            this.txtEntriesCount.TabIndex = 5;
            this.txtEntriesCount.Text = "0";
            // 
            // txtSelectedAlphabet
            // 
            this.txtSelectedAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedAlphabet.Location = new System.Drawing.Point(139, 18);
            this.txtSelectedAlphabet.Name = "txtSelectedAlphabet";
            this.txtSelectedAlphabet.ReadOnly = true;
            this.txtSelectedAlphabet.Size = new System.Drawing.Size(200, 23);
            this.txtSelectedAlphabet.TabIndex = 4;
            // 
            // txtHeadwordsCount
            // 
            this.txtHeadwordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeadwordsCount.Location = new System.Drawing.Point(139, 47);
            this.txtHeadwordsCount.Name = "txtHeadwordsCount";
            this.txtHeadwordsCount.ReadOnly = true;
            this.txtHeadwordsCount.Size = new System.Drawing.Size(200, 23);
            this.txtHeadwordsCount.TabIndex = 3;
            this.txtHeadwordsCount.Text = "0";
            // 
            // lblEntriesCount
            // 
            this.lblEntriesCount.AutoSize = true;
            this.lblEntriesCount.Location = new System.Drawing.Point(6, 80);
            this.lblEntriesCount.Name = "lblEntriesCount";
            this.lblEntriesCount.Size = new System.Drawing.Size(100, 15);
            this.lblEntriesCount.TabIndex = 2;
            this.lblEntriesCount.Text = "Entries\' Count:";
            // 
            // lblHeadwordsCount
            // 
            this.lblHeadwordsCount.AutoSize = true;
            this.lblHeadwordsCount.Location = new System.Drawing.Point(6, 51);
            this.lblHeadwordsCount.Name = "lblHeadwordsCount";
            this.lblHeadwordsCount.Size = new System.Drawing.Size(127, 15);
            this.lblHeadwordsCount.TabIndex = 1;
            this.lblHeadwordsCount.Text = "Headwords\' Count:";
            // 
            // lblSelectedAlphabet
            // 
            this.lblSelectedAlphabet.AutoSize = true;
            this.lblSelectedAlphabet.Location = new System.Drawing.Point(6, 22);
            this.lblSelectedAlphabet.Name = "lblSelectedAlphabet";
            this.lblSelectedAlphabet.Size = new System.Drawing.Size(68, 15);
            this.lblSelectedAlphabet.TabIndex = 0;
            this.lblSelectedAlphabet.Text = "Alphabet:";
            // 
            // chkIncomplete
            // 
            this.chkIncomplete.AutoSize = true;
            this.chkIncomplete.Location = new System.Drawing.Point(308, 78);
            this.chkIncomplete.Name = "chkIncomplete";
            this.chkIncomplete.Size = new System.Drawing.Size(97, 19);
            this.chkIncomplete.TabIndex = 10;
            this.chkIncomplete.Text = "Incomplete";
            this.chkIncomplete.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 653);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.attributesGroupBox);
            this.Controls.Add(this.entriesGroupBox);
            this.Controls.Add(this.headwordGroupBox);
            this.Controls.Add(this.headwordsListGroupBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farhang 2.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headwordsListGroupBox.ResumeLayout(false);
            this.headwordsListGroupBox.PerformLayout();
            this.headwordGroupBox.ResumeLayout(false);
            this.headwordGroupBox.PerformLayout();
            this.entriesGroupBox.ResumeLayout(false);
            this.attributesGroupBox.ResumeLayout(false);
            this.attributesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            this.groupBoxPreview.ResumeLayout(false);
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		private System.Windows.Forms.GroupBox headwordsListGroupBox;
		private System.Windows.Forms.Label lblAlphabet;
		private System.Windows.Forms.ComboBox cmbBoxAlphabet;
		private System.Windows.Forms.ListBox headwordsListBox;
		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox headwordGroupBox;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPronunciation;
        private System.Windows.Forms.Label lblLemma;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPronunciation;
        private System.Windows.Forms.TextBox txtLemma;
        private System.Windows.Forms.TreeView entriesTreeView;
        private System.Windows.Forms.GroupBox entriesGroupBox;
        private System.Windows.Forms.GroupBox attributesGroupBox;
        private System.Windows.Forms.ComboBox cmbBoxDestinationLanguage;
        private System.Windows.Forms.ComboBox cmbBoxType;
        private System.Windows.Forms.TextBox txtSourceText;
        private System.Windows.Forms.Label lblTranslation;
        private System.Windows.Forms.Label lblDestinationLanguage;
        private System.Windows.Forms.Label lblSourceText;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtTranslation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.NumericUpDown txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.Label lblEntriesCount;
        private System.Windows.Forms.Label lblHeadwordsCount;
        private System.Windows.Forms.Label lblSelectedAlphabet;
        private System.Windows.Forms.TextBox txtHeadwordsCount;
        private System.Windows.Forms.TextBox txtSelectedAlphabet;
        private System.Windows.Forms.TextBox txtEntriesCount;
        private System.Windows.Forms.TextBox txtSubentriesCount;
        private System.Windows.Forms.Label lblSubentriesCount;
        private System.Windows.Forms.Button btnViewStatistics;
        private System.Windows.Forms.CheckBox chkIncomplete;
	}
}
