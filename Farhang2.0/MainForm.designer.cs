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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Headword");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripResult = new System.Windows.Forms.ToolStripLabel();
            this.headwordsListBox = new System.Windows.Forms.ListBox();
            this.cmbBoxLetter = new System.Windows.Forms.ComboBox();
            this.headwordsListGroupBox = new System.Windows.Forms.GroupBox();
            this.lblLetter = new System.Windows.Forms.Label();
            this.btnDeleteHeadword = new System.Windows.Forms.Button();
            this.btnIPAKeyboard4Search = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnAddHeadword = new System.Windows.Forms.Button();
            this.entriesTreeView = new System.Windows.Forms.TreeView();
            this.entriesGroupBox = new System.Windows.Forms.GroupBox();
            this.attributesGroupBox = new System.Windows.Forms.GroupBox();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnSaveEntry = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnIPAKeyboard4Translation = new System.Windows.Forms.Button();
            this.btnIPAKeyboard4SourceText = new System.Windows.Forms.Button();
            this.txtTranslation = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.cmbBoxTranslationLanguage = new System.Windows.Forms.ComboBox();
            this.cmbBoxEntryType = new System.Windows.Forms.ComboBox();
            this.txtSourceText = new System.Windows.Forms.TextBox();
            this.lblTranslation = new System.Windows.Forms.Label();
            this.lblDestinationLanguage = new System.Windows.Forms.Label();
            this.lblSourceText = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.finishEditingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findHeadwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.zoom100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newHeadwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteHeadwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.newEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.newSubentryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSubentryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dictionaryPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualHeadwordSorterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unmaximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutFarhang20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.manualHeadwordSorterGrpBox = new System.Windows.Forms.GroupBox();
            this.lblLetter4Sort = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtTotal4MHS = new System.Windows.Forms.TextBox();
            this.btnSavePriorityList = new System.Windows.Forms.Button();
            this.btnIPAKeyboard4MHSSearch = new System.Windows.Forms.Button();
            this.txtMHSSearch = new System.Windows.Forms.TextBox();
            this.lblMHSSearch = new System.Windows.Forms.Label();
            this.lblScratchPad = new System.Windows.Forms.Label();
            this.txtScratch = new System.Windows.Forms.TextBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.cmbBoxLetter4Sort = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxOriginal = new System.Windows.Forms.GroupBox();
            this.dataGridViewOriginal = new System.Windows.Forms.DataGridView();
            this.grpBoxSorted = new System.Windows.Forms.GroupBox();
            this.dataGridView4Sort = new System.Windows.Forms.DataGridView();
            this.headwordGroupBox = new System.Windows.Forms.GroupBox();
            this.btnSaveHeadword = new System.Windows.Forms.Button();
            this.btnIPAKeyboard4Description = new System.Windows.Forms.Button();
            this.btnIPAKeyboard4Pronunciation = new System.Windows.Forms.Button();
            this.btnIPAKeyboard4Lemma = new System.Windows.Forms.Button();
            this.chkIncomplete = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPronunciation = new System.Windows.Forms.Label();
            this.lblLemma = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPronunciation = new System.Windows.Forms.TextBox();
            this.txtLemma = new System.Windows.Forms.TextBox();
            this.attachmentGroupBox = new System.Windows.Forms.GroupBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.txtAttachmentColumns = new System.Windows.Forms.TextBox();
            this.lblAttachmentTitle = new System.Windows.Forms.Label();
            this.txtAttachmentTitle = new System.Windows.Forms.TextBox();
            this.lblAttachmentTranslation = new System.Windows.Forms.Label();
            this.txtAttachmentTranslation = new System.Windows.Forms.TextBox();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.btnAddUpdateAttachment = new System.Windows.Forms.Button();
            this.mobileDatabaseExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.headwordsListGroupBox.SuspendLayout();
            this.entriesGroupBox.SuspendLayout();
            this.attributesGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.previewGroupBox.SuspendLayout();
            this.manualHeadwordSorterGrpBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpBoxOriginal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOriginal)).BeginInit();
            this.grpBoxSorted.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4Sort)).BeginInit();
            this.headwordGroupBox.SuspendLayout();
            this.attachmentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripResult});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1056, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripResult
            // 
            this.toolStripResult.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripResult.Font = new System.Drawing.Font("DejaVu Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripResult.Name = "toolStripResult";
            this.toolStripResult.Size = new System.Drawing.Size(0, 22);
            // 
            // headwordsListBox
            // 
            this.headwordsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headwordsListBox.FormattingEnabled = true;
            this.headwordsListBox.ItemHeight = 15;
            this.headwordsListBox.Location = new System.Drawing.Point(6, 105);
            this.headwordsListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headwordsListBox.Name = "headwordsListBox";
            this.headwordsListBox.Size = new System.Drawing.Size(247, 484);
            this.headwordsListBox.TabIndex = 2;
            this.headwordsListBox.SelectedIndexChanged += new System.EventHandler(this.headwordsListBoxSelectedIndexChanged);
            // 
            // cmbBoxLetter
            // 
            this.cmbBoxLetter.ItemHeight = 15;
            this.cmbBoxLetter.Items.AddRange(new object[] {
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
            this.cmbBoxLetter.Location = new System.Drawing.Point(67, 20);
            this.cmbBoxLetter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbBoxLetter.Name = "cmbBoxLetter";
            this.cmbBoxLetter.Size = new System.Drawing.Size(185, 23);
            this.cmbBoxLetter.TabIndex = 0;
            this.cmbBoxLetter.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLetterSelectedIndexChanged);
            // 
            // headwordsListGroupBox
            // 
            this.headwordsListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.headwordsListGroupBox.Controls.Add(this.lblLetter);
            this.headwordsListGroupBox.Controls.Add(this.btnDeleteHeadword);
            this.headwordsListGroupBox.Controls.Add(this.btnIPAKeyboard4Search);
            this.headwordsListGroupBox.Controls.Add(this.txtSearch);
            this.headwordsListGroupBox.Controls.Add(this.lblSearch);
            this.headwordsListGroupBox.Controls.Add(this.cmbBoxLetter);
            this.headwordsListGroupBox.Controls.Add(this.headwordsListBox);
            this.headwordsListGroupBox.Location = new System.Drawing.Point(11, 52);
            this.headwordsListGroupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headwordsListGroupBox.Name = "headwordsListGroupBox";
            this.headwordsListGroupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.headwordsListGroupBox.Size = new System.Drawing.Size(256, 589);
            this.headwordsListGroupBox.TabIndex = 0;
            this.headwordsListGroupBox.TabStop = false;
            this.headwordsListGroupBox.Text = "Headwords\' List";
            this.headwordsListGroupBox.Visible = false;
            // 
            // lblLetter
            // 
            this.lblLetter.AutoSize = true;
            this.lblLetter.Location = new System.Drawing.Point(5, 24);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(49, 15);
            this.lblLetter.TabIndex = 8;
            this.lblLetter.Text = "Letter:";
            // 
            // btnDeleteHeadword
            // 
            this.btnDeleteHeadword.Enabled = false;
            this.btnDeleteHeadword.Location = new System.Drawing.Point(6, 78);
            this.btnDeleteHeadword.Name = "btnDeleteHeadword";
            this.btnDeleteHeadword.Size = new System.Drawing.Size(247, 23);
            this.btnDeleteHeadword.TabIndex = 7;
            this.btnDeleteHeadword.Text = "Delete";
            this.btnDeleteHeadword.UseVisualStyleBackColor = true;
            this.btnDeleteHeadword.Click += new System.EventHandler(this.btnDeleteHeadword_Click);
            // 
            // btnIPAKeyboard4Search
            // 
            this.btnIPAKeyboard4Search.Location = new System.Drawing.Point(213, 49);
            this.btnIPAKeyboard4Search.Name = "btnIPAKeyboard4Search";
            this.btnIPAKeyboard4Search.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4Search.TabIndex = 5;
            this.btnIPAKeyboard4Search.Text = "IPA";
            this.btnIPAKeyboard4Search.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4Search.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(67, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            // btnAddHeadword
            // 
            this.btnAddHeadword.Enabled = false;
            this.btnAddHeadword.Location = new System.Drawing.Point(6, 132);
            this.btnAddHeadword.Name = "btnAddHeadword";
            this.btnAddHeadword.Size = new System.Drawing.Size(131, 23);
            this.btnAddHeadword.TabIndex = 6;
            this.btnAddHeadword.Text = "Add Headword";
            this.btnAddHeadword.UseVisualStyleBackColor = true;
            this.btnAddHeadword.Click += new System.EventHandler(this.btnAddHeadword_Click);
            // 
            // entriesTreeView
            // 
            this.entriesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entriesTreeView.FullRowSelect = true;
            this.entriesTreeView.Location = new System.Drawing.Point(9, 22);
            this.entriesTreeView.Name = "entriesTreeView";
            treeNode1.Name = "Headword";
            treeNode1.Text = "Headword";
            this.entriesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.entriesTreeView.Size = new System.Drawing.Size(406, 226);
            this.entriesTreeView.TabIndex = 0;
            // 
            // entriesGroupBox
            // 
            this.entriesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entriesGroupBox.Controls.Add(this.entriesTreeView);
            this.entriesGroupBox.Location = new System.Drawing.Point(272, 52);
            this.entriesGroupBox.Name = "entriesGroupBox";
            this.entriesGroupBox.Size = new System.Drawing.Size(421, 254);
            this.entriesGroupBox.TabIndex = 1;
            this.entriesGroupBox.TabStop = false;
            this.entriesGroupBox.Text = "Entries";
            this.entriesGroupBox.Visible = false;
            // 
            // attributesGroupBox
            // 
            this.attributesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.attributesGroupBox.Controls.Add(this.btnAddEntry);
            this.attributesGroupBox.Controls.Add(this.btnDeleteEntry);
            this.attributesGroupBox.Controls.Add(this.btnSaveEntry);
            this.attributesGroupBox.Controls.Add(this.txtNumber);
            this.attributesGroupBox.Controls.Add(this.btnIPAKeyboard4Translation);
            this.attributesGroupBox.Controls.Add(this.btnIPAKeyboard4SourceText);
            this.attributesGroupBox.Controls.Add(this.txtTranslation);
            this.attributesGroupBox.Controls.Add(this.lblNumber);
            this.attributesGroupBox.Controls.Add(this.cmbBoxTranslationLanguage);
            this.attributesGroupBox.Controls.Add(this.cmbBoxEntryType);
            this.attributesGroupBox.Controls.Add(this.txtSourceText);
            this.attributesGroupBox.Controls.Add(this.lblTranslation);
            this.attributesGroupBox.Controls.Add(this.lblDestinationLanguage);
            this.attributesGroupBox.Controls.Add(this.lblSourceText);
            this.attributesGroupBox.Controls.Add(this.lblType);
            this.attributesGroupBox.Location = new System.Drawing.Point(272, 479);
            this.attributesGroupBox.Name = "attributesGroupBox";
            this.attributesGroupBox.Size = new System.Drawing.Size(421, 162);
            this.attributesGroupBox.TabIndex = 3;
            this.attributesGroupBox.TabStop = false;
            this.attributesGroupBox.Text = "Attributes";
            this.attributesGroupBox.Visible = false;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEntry.Enabled = false;
            this.btnAddEntry.Location = new System.Drawing.Point(242, 133);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(92, 23);
            this.btnAddEntry.TabIndex = 15;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteEntry.Enabled = false;
            this.btnDeleteEntry.Location = new System.Drawing.Point(6, 134);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEntry.TabIndex = 14;
            this.btnDeleteEntry.Text = "Delete";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnSaveEntry
            // 
            this.btnSaveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEntry.Enabled = false;
            this.btnSaveEntry.Location = new System.Drawing.Point(340, 134);
            this.btnSaveEntry.Name = "btnSaveEntry";
            this.btnSaveEntry.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEntry.TabIndex = 5;
            this.btnSaveEntry.Text = "Save";
            this.btnSaveEntry.UseVisualStyleBackColor = true;
            this.btnSaveEntry.Click += new System.EventHandler(this.btnSaveEntry_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(308, 18);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(104, 23);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtField_TextChanged);
            // 
            // btnIPAKeyboard4Translation
            // 
            this.btnIPAKeyboard4Translation.Location = new System.Drawing.Point(376, 105);
            this.btnIPAKeyboard4Translation.Name = "btnIPAKeyboard4Translation";
            this.btnIPAKeyboard4Translation.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4Translation.TabIndex = 13;
            this.btnIPAKeyboard4Translation.Text = "IPA";
            this.btnIPAKeyboard4Translation.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4Translation.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // btnIPAKeyboard4SourceText
            // 
            this.btnIPAKeyboard4SourceText.Location = new System.Drawing.Point(376, 47);
            this.btnIPAKeyboard4SourceText.Name = "btnIPAKeyboard4SourceText";
            this.btnIPAKeyboard4SourceText.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4SourceText.TabIndex = 12;
            this.btnIPAKeyboard4SourceText.Text = "IPA";
            this.btnIPAKeyboard4SourceText.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4SourceText.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // txtTranslation
            // 
            this.txtTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTranslation.Location = new System.Drawing.Point(96, 105);
            this.txtTranslation.Name = "txtTranslation";
            this.txtTranslation.Size = new System.Drawing.Size(274, 23);
            this.txtTranslation.TabIndex = 4;
            this.txtTranslation.TextChanged += new System.EventHandler(this.txtField_TextChanged);
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
            // cmbBoxTranslationLanguage
            // 
            this.cmbBoxTranslationLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxTranslationLanguage.FormattingEnabled = true;
            this.cmbBoxTranslationLanguage.Items.AddRange(new object[] {
            "Persisch",
            "Deutsch"});
            this.cmbBoxTranslationLanguage.Location = new System.Drawing.Point(96, 76);
            this.cmbBoxTranslationLanguage.Name = "cmbBoxTranslationLanguage";
            this.cmbBoxTranslationLanguage.Size = new System.Drawing.Size(104, 23);
            this.cmbBoxTranslationLanguage.TabIndex = 3;
            this.cmbBoxTranslationLanguage.Text = "Persisch";
            this.cmbBoxTranslationLanguage.TextChanged += new System.EventHandler(this.cmbBoxField_TextChanged);
            // 
            // cmbBoxEntryType
            // 
            this.cmbBoxEntryType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxEntryType.FormattingEnabled = true;
            this.cmbBoxEntryType.Items.AddRange(new object[] {
            "Entry",
            "Subentry",
            "Combination",
            "Reference"});
            this.cmbBoxEntryType.Location = new System.Drawing.Point(96, 18);
            this.cmbBoxEntryType.Name = "cmbBoxEntryType";
            this.cmbBoxEntryType.Size = new System.Drawing.Size(104, 23);
            this.cmbBoxEntryType.TabIndex = 0;
            this.cmbBoxEntryType.Text = "Entry";
            this.cmbBoxEntryType.TextChanged += new System.EventHandler(this.cmbBoxField_TextChanged);
            // 
            // txtSourceText
            // 
            this.txtSourceText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceText.Location = new System.Drawing.Point(96, 47);
            this.txtSourceText.Name = "txtSourceText";
            this.txtSourceText.Size = new System.Drawing.Size(274, 23);
            this.txtSourceText.TabIndex = 2;
            this.txtSourceText.TextChanged += new System.EventHandler(this.txtField_TextChanged);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.headwordToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDictionaryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveChangesToolStripMenuItem,
            this.exportXMLToolStripMenuItem,
            this.toolStripMenuItem2,
            this.finishEditingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // editDictionaryToolStripMenuItem
            // 
            this.editDictionaryToolStripMenuItem.Name = "editDictionaryToolStripMenuItem";
            this.editDictionaryToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editDictionaryToolStripMenuItem.Text = "&Edit Dictionary";
            this.editDictionaryToolStripMenuItem.Click += new System.EventHandler(this.editDictionaryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveChangesToolStripMenuItem.Text = "&Save Changes";
            // 
            // exportXMLToolStripMenuItem
            // 
            this.exportXMLToolStripMenuItem.Enabled = false;
            this.exportXMLToolStripMenuItem.Name = "exportXMLToolStripMenuItem";
            this.exportXMLToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportXMLToolStripMenuItem.Text = "&Export XML";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 6);
            // 
            // finishEditingToolStripMenuItem
            // 
            this.finishEditingToolStripMenuItem.Name = "finishEditingToolStripMenuItem";
            this.finishEditingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.finishEditingToolStripMenuItem.Text = "&Finish Editing";
            this.finishEditingToolStripMenuItem.Click += new System.EventHandler(this.finishEditingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findHeadwordToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.selectAllToolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // findHeadwordToolStripMenuItem
            // 
            this.findHeadwordToolStripMenuItem.Name = "findHeadwordToolStripMenuItem";
            this.findHeadwordToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.findHeadwordToolStripMenuItem.Text = "&Find Headword";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(143, 6);
            // 
            // selectAllToolStripMenuItem1
            // 
            this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            this.selectAllToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.selectAllToolStripMenuItem1.Text = "&Select All";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputPreviewToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.zoom100ToolStripMenuItem,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // outputPreviewToolStripMenuItem
            // 
            this.outputPreviewToolStripMenuItem.Name = "outputPreviewToolStripMenuItem";
            this.outputPreviewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.outputPreviewToolStripMenuItem.Text = "&Output Preview";
            this.outputPreviewToolStripMenuItem.Visible = false;
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.statisticsToolStripMenuItem.Text = "&Statistics";
            this.statisticsToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // zoom100ToolStripMenuItem
            // 
            this.zoom100ToolStripMenuItem.Name = "zoom100ToolStripMenuItem";
            this.zoom100ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.zoom100ToolStripMenuItem.Text = "Zoom 100%";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom in";
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom out";
            // 
            // headwordToolStripMenuItem
            // 
            this.headwordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newHeadwordToolStripMenuItem,
            this.deleteHeadwordToolStripMenuItem,
            this.toolStripMenuItem4,
            this.newEntryToolStripMenuItem,
            this.deleteEntryToolStripMenuItem,
            this.toolStripMenuItem5,
            this.newSubentryToolStripMenuItem,
            this.deleteSubentryToolStripMenuItem,
            this.toolStripMenuItem6,
            this.firstToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.lastToolStripMenuItem});
            this.headwordToolStripMenuItem.Name = "headwordToolStripMenuItem";
            this.headwordToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.headwordToolStripMenuItem.Text = "&Headword";
            // 
            // newHeadwordToolStripMenuItem
            // 
            this.newHeadwordToolStripMenuItem.Name = "newHeadwordToolStripMenuItem";
            this.newHeadwordToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newHeadwordToolStripMenuItem.Text = "&New Headword";
            // 
            // deleteHeadwordToolStripMenuItem
            // 
            this.deleteHeadwordToolStripMenuItem.Enabled = false;
            this.deleteHeadwordToolStripMenuItem.Name = "deleteHeadwordToolStripMenuItem";
            this.deleteHeadwordToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteHeadwordToolStripMenuItem.Text = "Delete Headword";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(154, 6);
            // 
            // newEntryToolStripMenuItem
            // 
            this.newEntryToolStripMenuItem.Name = "newEntryToolStripMenuItem";
            this.newEntryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newEntryToolStripMenuItem.Text = "New &Entry";
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Enabled = false;
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            this.deleteEntryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteEntryToolStripMenuItem.Text = "Delete Entry";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(154, 6);
            // 
            // newSubentryToolStripMenuItem
            // 
            this.newSubentryToolStripMenuItem.Name = "newSubentryToolStripMenuItem";
            this.newSubentryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newSubentryToolStripMenuItem.Text = "New &Subentry";
            // 
            // deleteSubentryToolStripMenuItem
            // 
            this.deleteSubentryToolStripMenuItem.Enabled = false;
            this.deleteSubentryToolStripMenuItem.Name = "deleteSubentryToolStripMenuItem";
            this.deleteSubentryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteSubentryToolStripMenuItem.Text = "Delete Subentry";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(154, 6);
            // 
            // firstToolStripMenuItem
            // 
            this.firstToolStripMenuItem.Name = "firstToolStripMenuItem";
            this.firstToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.firstToolStripMenuItem.Text = "First";
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.previousToolStripMenuItem.Text = "Previous";
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.nextToolStripMenuItem.Text = "Next";
            // 
            // lastToolStripMenuItem
            // 
            this.lastToolStripMenuItem.Name = "lastToolStripMenuItem";
            this.lastToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.lastToolStripMenuItem.Text = "Last";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.dictionaryPropertiesToolStripMenuItem,
            this.statisticsToolStripMenuItem1,
            this.manualHeadwordSorterToolStripMenuItem,
            this.pDFBuilderToolStripMenuItem,
            this.mobileDatabaseExporterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // dictionaryPropertiesToolStripMenuItem
            // 
            this.dictionaryPropertiesToolStripMenuItem.Name = "dictionaryPropertiesToolStripMenuItem";
            this.dictionaryPropertiesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.dictionaryPropertiesToolStripMenuItem.Text = "&Dictionary Properties";
            // 
            // statisticsToolStripMenuItem1
            // 
            this.statisticsToolStripMenuItem1.Name = "statisticsToolStripMenuItem1";
            this.statisticsToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.statisticsToolStripMenuItem1.Text = "&Statistics";
            // 
            // manualHeadwordSorterToolStripMenuItem
            // 
            this.manualHeadwordSorterToolStripMenuItem.Name = "manualHeadwordSorterToolStripMenuItem";
            this.manualHeadwordSorterToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.manualHeadwordSorterToolStripMenuItem.Text = "&Manual Headword Sorter";
            this.manualHeadwordSorterToolStripMenuItem.Click += new System.EventHandler(this.manualHeadwordSorterToolStripMenuItem_Click);
            // 
            // pDFBuilderToolStripMenuItem
            // 
            this.pDFBuilderToolStripMenuItem.Name = "pDFBuilderToolStripMenuItem";
            this.pDFBuilderToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pDFBuilderToolStripMenuItem.Text = "&PDF Builder";
            this.pDFBuilderToolStripMenuItem.Click += new System.EventHandler(this.pDFBuilderToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizeToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.unmaximizeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.maximizeToolStripMenuItem.Text = "&Maximize";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.minimizeToolStripMenuItem.Text = "Mi&nimize";
            // 
            // unmaximizeToolStripMenuItem
            // 
            this.unmaximizeToolStripMenuItem.Name = "unmaximizeToolStripMenuItem";
            this.unmaximizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.unmaximizeToolStripMenuItem.Text = "&Unmaximize";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideToolStripMenuItem,
            this.visitWebsiteToolStripMenuItem,
            this.aboutFarhang20ToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.userGuideToolStripMenuItem.Text = "&User Guide";
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            this.visitWebsiteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.visitWebsiteToolStripMenuItem.Text = "&Visit Website";
            // 
            // aboutFarhang20ToolStripMenuItem
            // 
            this.aboutFarhang20ToolStripMenuItem.Name = "aboutFarhang20ToolStripMenuItem";
            this.aboutFarhang20ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.aboutFarhang20ToolStripMenuItem.Text = "&About Farhang 2.0";
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGroupBox.Controls.Add(this.webBrowser1);
            this.previewGroupBox.Location = new System.Drawing.Point(699, 52);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(345, 421);
            this.previewGroupBox.TabIndex = 4;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Output Preview";
            this.previewGroupBox.Visible = false;
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
            this.webBrowser1.Size = new System.Drawing.Size(339, 399);
            this.webBrowser1.TabIndex = 0;
            // 
            // manualHeadwordSorterGrpBox
            // 
            this.manualHeadwordSorterGrpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manualHeadwordSorterGrpBox.Controls.Add(this.lblLetter4Sort);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.txtStatus);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.lblStatus);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.txtTotal4MHS);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.btnSavePriorityList);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.btnIPAKeyboard4MHSSearch);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.txtMHSSearch);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.lblMHSSearch);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.lblScratchPad);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.txtScratch);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.lblTotalCount);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.cmbBoxLetter4Sort);
            this.manualHeadwordSorterGrpBox.Controls.Add(this.tableLayoutPanel1);
            this.manualHeadwordSorterGrpBox.Location = new System.Drawing.Point(11, 52);
            this.manualHeadwordSorterGrpBox.Name = "manualHeadwordSorterGrpBox";
            this.manualHeadwordSorterGrpBox.Size = new System.Drawing.Size(1033, 589);
            this.manualHeadwordSorterGrpBox.TabIndex = 0;
            this.manualHeadwordSorterGrpBox.TabStop = false;
            this.manualHeadwordSorterGrpBox.Text = "Manual Headword Sorter";
            this.manualHeadwordSorterGrpBox.Visible = false;
            // 
            // lblLetter4Sort
            // 
            this.lblLetter4Sort.AutoSize = true;
            this.lblLetter4Sort.Location = new System.Drawing.Point(6, 27);
            this.lblLetter4Sort.Name = "lblLetter4Sort";
            this.lblLetter4Sort.Size = new System.Drawing.Size(49, 15);
            this.lblLetter4Sort.TabIndex = 19;
            this.lblLetter4Sort.Text = "Letter:";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(526, 52);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(415, 23);
            this.txtStatus.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(467, 56);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 15);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status:";
            // 
            // txtTotal4MHS
            // 
            this.txtTotal4MHS.Location = new System.Drawing.Point(351, 52);
            this.txtTotal4MHS.Name = "txtTotal4MHS";
            this.txtTotal4MHS.ReadOnly = true;
            this.txtTotal4MHS.Size = new System.Drawing.Size(110, 23);
            this.txtTotal4MHS.TabIndex = 7;
            // 
            // btnSavePriorityList
            // 
            this.btnSavePriorityList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePriorityList.Enabled = false;
            this.btnSavePriorityList.Location = new System.Drawing.Point(952, 52);
            this.btnSavePriorityList.Name = "btnSavePriorityList";
            this.btnSavePriorityList.Size = new System.Drawing.Size(75, 23);
            this.btnSavePriorityList.TabIndex = 2;
            this.btnSavePriorityList.Text = "Save";
            this.btnSavePriorityList.UseVisualStyleBackColor = true;
            this.btnSavePriorityList.Click += new System.EventHandler(this.btnSavePriorityList_Click);
            // 
            // btnIPAKeyboard4MHSSearch
            // 
            this.btnIPAKeyboard4MHSSearch.Location = new System.Drawing.Point(214, 52);
            this.btnIPAKeyboard4MHSSearch.Name = "btnIPAKeyboard4MHSSearch";
            this.btnIPAKeyboard4MHSSearch.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4MHSSearch.TabIndex = 3;
            this.btnIPAKeyboard4MHSSearch.Text = "IPA";
            this.btnIPAKeyboard4MHSSearch.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4MHSSearch.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // txtMHSSearch
            // 
            this.txtMHSSearch.Location = new System.Drawing.Point(67, 52);
            this.txtMHSSearch.Name = "txtMHSSearch";
            this.txtMHSSearch.Size = new System.Drawing.Size(141, 23);
            this.txtMHSSearch.TabIndex = 1;
            this.txtMHSSearch.TextChanged += new System.EventHandler(this.txtMHSSearch_TextChanged);
            // 
            // lblMHSSearch
            // 
            this.lblMHSSearch.AutoSize = true;
            this.lblMHSSearch.Location = new System.Drawing.Point(6, 56);
            this.lblMHSSearch.Name = "lblMHSSearch";
            this.lblMHSSearch.Size = new System.Drawing.Size(56, 15);
            this.lblMHSSearch.TabIndex = 10;
            this.lblMHSSearch.Text = "Search:";
            // 
            // lblScratchPad
            // 
            this.lblScratchPad.AutoSize = true;
            this.lblScratchPad.Location = new System.Drawing.Point(258, 26);
            this.lblScratchPad.Name = "lblScratchPad";
            this.lblScratchPad.Size = new System.Drawing.Size(87, 15);
            this.lblScratchPad.TabIndex = 8;
            this.lblScratchPad.Text = "Scratch Pad:";
            // 
            // txtScratch
            // 
            this.txtScratch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScratch.Location = new System.Drawing.Point(351, 22);
            this.txtScratch.Name = "txtScratch";
            this.txtScratch.Size = new System.Drawing.Size(676, 23);
            this.txtScratch.TabIndex = 1;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(258, 56);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(82, 15);
            this.lblTotalCount.TabIndex = 6;
            this.lblTotalCount.Text = "Total Count:";
            // 
            // cmbBoxLetter4Sort
            // 
            this.cmbBoxLetter4Sort.ItemHeight = 15;
            this.cmbBoxLetter4Sort.Items.AddRange(new object[] {
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
            this.cmbBoxLetter4Sort.Location = new System.Drawing.Point(67, 23);
            this.cmbBoxLetter4Sort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbBoxLetter4Sort.Name = "cmbBoxLetter4Sort";
            this.cmbBoxLetter4Sort.Size = new System.Drawing.Size(186, 23);
            this.cmbBoxLetter4Sort.TabIndex = 0;
            this.cmbBoxLetter4Sort.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLetter4Sort_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grpBoxOriginal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpBoxSorted, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 506);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // grpBoxOriginal
            // 
            this.grpBoxOriginal.Controls.Add(this.dataGridViewOriginal);
            this.grpBoxOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxOriginal.Location = new System.Drawing.Point(514, 3);
            this.grpBoxOriginal.Name = "grpBoxOriginal";
            this.grpBoxOriginal.Size = new System.Drawing.Size(505, 500);
            this.grpBoxOriginal.TabIndex = 19;
            this.grpBoxOriginal.TabStop = false;
            this.grpBoxOriginal.Text = "Original";
            // 
            // dataGridViewOriginal
            // 
            this.dataGridViewOriginal.AllowUserToAddRows = false;
            this.dataGridViewOriginal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewOriginal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOriginal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOriginal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOriginal.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewOriginal.MultiSelect = false;
            this.dataGridViewOriginal.Name = "dataGridViewOriginal";
            this.dataGridViewOriginal.ReadOnly = true;
            this.dataGridViewOriginal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOriginal.Size = new System.Drawing.Size(499, 478);
            this.dataGridViewOriginal.TabIndex = 0;
            // 
            // grpBoxSorted
            // 
            this.grpBoxSorted.Controls.Add(this.dataGridView4Sort);
            this.grpBoxSorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxSorted.Location = new System.Drawing.Point(3, 3);
            this.grpBoxSorted.Name = "grpBoxSorted";
            this.grpBoxSorted.Size = new System.Drawing.Size(505, 500);
            this.grpBoxSorted.TabIndex = 18;
            this.grpBoxSorted.TabStop = false;
            this.grpBoxSorted.Text = "Sorted";
            // 
            // dataGridView4Sort
            // 
            this.dataGridView4Sort.AllowUserToAddRows = false;
            this.dataGridView4Sort.AllowUserToDeleteRows = false;
            this.dataGridView4Sort.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView4Sort.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView4Sort.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView4Sort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4Sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4Sort.Location = new System.Drawing.Point(3, 19);
            this.dataGridView4Sort.MultiSelect = false;
            this.dataGridView4Sort.Name = "dataGridView4Sort";
            this.dataGridView4Sort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4Sort.Size = new System.Drawing.Size(499, 478);
            this.dataGridView4Sort.TabIndex = 0;
            this.dataGridView4Sort.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4Sort_CellValueChanged);
            this.dataGridView4Sort.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4Sort_RowEnter);
            // 
            // headwordGroupBox
            // 
            this.headwordGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.headwordGroupBox.Controls.Add(this.btnSaveHeadword);
            this.headwordGroupBox.Controls.Add(this.btnIPAKeyboard4Description);
            this.headwordGroupBox.Controls.Add(this.btnAddHeadword);
            this.headwordGroupBox.Controls.Add(this.btnIPAKeyboard4Pronunciation);
            this.headwordGroupBox.Controls.Add(this.btnIPAKeyboard4Lemma);
            this.headwordGroupBox.Controls.Add(this.chkIncomplete);
            this.headwordGroupBox.Controls.Add(this.lblDescription);
            this.headwordGroupBox.Controls.Add(this.lblPronunciation);
            this.headwordGroupBox.Controls.Add(this.lblLemma);
            this.headwordGroupBox.Controls.Add(this.txtDescription);
            this.headwordGroupBox.Controls.Add(this.txtPronunciation);
            this.headwordGroupBox.Controls.Add(this.txtLemma);
            this.headwordGroupBox.Location = new System.Drawing.Point(272, 312);
            this.headwordGroupBox.Name = "headwordGroupBox";
            this.headwordGroupBox.Size = new System.Drawing.Size(421, 161);
            this.headwordGroupBox.TabIndex = 2;
            this.headwordGroupBox.TabStop = false;
            this.headwordGroupBox.Text = "Headword";
            this.headwordGroupBox.Visible = false;
            // 
            // btnSaveHeadword
            // 
            this.btnSaveHeadword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHeadword.Enabled = false;
            this.btnSaveHeadword.Location = new System.Drawing.Point(340, 132);
            this.btnSaveHeadword.Name = "btnSaveHeadword";
            this.btnSaveHeadword.Size = new System.Drawing.Size(75, 23);
            this.btnSaveHeadword.TabIndex = 3;
            this.btnSaveHeadword.Text = "Save";
            this.btnSaveHeadword.UseVisualStyleBackColor = true;
            this.btnSaveHeadword.Click += new System.EventHandler(this.btnSaveHeadword_Click);
            // 
            // btnIPAKeyboard4Description
            // 
            this.btnIPAKeyboard4Description.Location = new System.Drawing.Point(376, 78);
            this.btnIPAKeyboard4Description.Name = "btnIPAKeyboard4Description";
            this.btnIPAKeyboard4Description.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4Description.TabIndex = 13;
            this.btnIPAKeyboard4Description.Text = "IPA";
            this.btnIPAKeyboard4Description.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4Description.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // btnIPAKeyboard4Pronunciation
            // 
            this.btnIPAKeyboard4Pronunciation.Location = new System.Drawing.Point(376, 48);
            this.btnIPAKeyboard4Pronunciation.Name = "btnIPAKeyboard4Pronunciation";
            this.btnIPAKeyboard4Pronunciation.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4Pronunciation.TabIndex = 12;
            this.btnIPAKeyboard4Pronunciation.Text = "IPA";
            this.btnIPAKeyboard4Pronunciation.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4Pronunciation.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // btnIPAKeyboard4Lemma
            // 
            this.btnIPAKeyboard4Lemma.Location = new System.Drawing.Point(376, 20);
            this.btnIPAKeyboard4Lemma.Name = "btnIPAKeyboard4Lemma";
            this.btnIPAKeyboard4Lemma.Size = new System.Drawing.Size(39, 23);
            this.btnIPAKeyboard4Lemma.TabIndex = 11;
            this.btnIPAKeyboard4Lemma.Text = "IPA";
            this.btnIPAKeyboard4Lemma.UseVisualStyleBackColor = true;
            this.btnIPAKeyboard4Lemma.Click += new System.EventHandler(this.btnIPAKeyboard4IPAButtons_Click);
            // 
            // chkIncomplete
            // 
            this.chkIncomplete.AutoSize = true;
            this.chkIncomplete.Location = new System.Drawing.Point(9, 109);
            this.chkIncomplete.Name = "chkIncomplete";
            this.chkIncomplete.Size = new System.Drawing.Size(78, 17);
            this.chkIncomplete.TabIndex = 10;
            this.chkIncomplete.Text = "Incomplete";
            this.chkIncomplete.UseVisualStyleBackColor = true;
            this.chkIncomplete.CheckedChanged += new System.EventHandler(this.chkIncomplete_CheckedChanged);
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
            this.txtDescription.Size = new System.Drawing.Size(260, 50);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtField_TextChanged);
            // 
            // txtPronunciation
            // 
            this.txtPronunciation.Location = new System.Drawing.Point(110, 48);
            this.txtPronunciation.Name = "txtPronunciation";
            this.txtPronunciation.Size = new System.Drawing.Size(260, 23);
            this.txtPronunciation.TabIndex = 1;
            this.txtPronunciation.TextChanged += new System.EventHandler(this.txtField_TextChanged);
            // 
            // txtLemma
            // 
            this.txtLemma.Location = new System.Drawing.Point(110, 20);
            this.txtLemma.Name = "txtLemma";
            this.txtLemma.Size = new System.Drawing.Size(260, 23);
            this.txtLemma.TabIndex = 0;
            this.txtLemma.TextChanged += new System.EventHandler(this.txtField_TextChanged);
            // 
            // attachmentGroupBox
            // 
            this.attachmentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attachmentGroupBox.Controls.Add(this.lblColumns);
            this.attachmentGroupBox.Controls.Add(this.txtAttachmentColumns);
            this.attachmentGroupBox.Controls.Add(this.lblAttachmentTitle);
            this.attachmentGroupBox.Controls.Add(this.txtAttachmentTitle);
            this.attachmentGroupBox.Controls.Add(this.lblAttachmentTranslation);
            this.attachmentGroupBox.Controls.Add(this.txtAttachmentTranslation);
            this.attachmentGroupBox.Controls.Add(this.lblAttachment);
            this.attachmentGroupBox.Controls.Add(this.txtAttachment);
            this.attachmentGroupBox.Controls.Add(this.btnRemoveAttachment);
            this.attachmentGroupBox.Controls.Add(this.btnAddUpdateAttachment);
            this.attachmentGroupBox.Location = new System.Drawing.Point(699, 479);
            this.attachmentGroupBox.Name = "attachmentGroupBox";
            this.attachmentGroupBox.Size = new System.Drawing.Size(345, 162);
            this.attachmentGroupBox.TabIndex = 6;
            this.attachmentGroupBox.TabStop = false;
            this.attachmentGroupBox.Text = "Attachment";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(6, 82);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(77, 15);
            this.lblColumns.TabIndex = 21;
            this.lblColumns.Text = "Column(s):";
            // 
            // txtAttachmentColumns
            // 
            this.txtAttachmentColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachmentColumns.Location = new System.Drawing.Point(99, 77);
            this.txtAttachmentColumns.Name = "txtAttachmentColumns";
            this.txtAttachmentColumns.Size = new System.Drawing.Size(240, 23);
            this.txtAttachmentColumns.TabIndex = 20;
            this.txtAttachmentColumns.Text = "1";
            // 
            // lblAttachmentTitle
            // 
            this.lblAttachmentTitle.AutoSize = true;
            this.lblAttachmentTitle.Location = new System.Drawing.Point(6, 25);
            this.lblAttachmentTitle.Name = "lblAttachmentTitle";
            this.lblAttachmentTitle.Size = new System.Drawing.Size(37, 15);
            this.lblAttachmentTitle.TabIndex = 19;
            this.lblAttachmentTitle.Text = "Title:";
            // 
            // txtAttachmentTitle
            // 
            this.txtAttachmentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachmentTitle.Location = new System.Drawing.Point(99, 21);
            this.txtAttachmentTitle.Name = "txtAttachmentTitle";
            this.txtAttachmentTitle.Size = new System.Drawing.Size(240, 23);
            this.txtAttachmentTitle.TabIndex = 18;
            // 
            // lblAttachmentTranslation
            // 
            this.lblAttachmentTranslation.AutoSize = true;
            this.lblAttachmentTranslation.Location = new System.Drawing.Point(6, 54);
            this.lblAttachmentTranslation.Name = "lblAttachmentTranslation";
            this.lblAttachmentTranslation.Size = new System.Drawing.Size(79, 15);
            this.lblAttachmentTranslation.TabIndex = 17;
            this.lblAttachmentTranslation.Text = "Translation:";
            // 
            // txtAttachmentTranslation
            // 
            this.txtAttachmentTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachmentTranslation.Location = new System.Drawing.Point(99, 49);
            this.txtAttachmentTranslation.Name = "txtAttachmentTranslation";
            this.txtAttachmentTranslation.Size = new System.Drawing.Size(240, 23);
            this.txtAttachmentTranslation.TabIndex = 16;
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(6, 109);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(87, 15);
            this.lblAttachment.TabIndex = 15;
            this.lblAttachment.Text = "Attachment:";
            // 
            // txtAttachment
            // 
            this.txtAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachment.Location = new System.Drawing.Point(99, 105);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Size = new System.Drawing.Size(240, 23);
            this.txtAttachment.TabIndex = 14;
            this.txtAttachment.TextChanged += new System.EventHandler(this.txtAttachment_TextChanged);
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAttachment.Enabled = false;
            this.btnRemoveAttachment.Location = new System.Drawing.Point(264, 134);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAttachment.TabIndex = 1;
            this.btnRemoveAttachment.Text = "Remove";
            this.btnRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // btnAddUpdateAttachment
            // 
            this.btnAddUpdateAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUpdateAttachment.Enabled = false;
            this.btnAddUpdateAttachment.Location = new System.Drawing.Point(139, 134);
            this.btnAddUpdateAttachment.Name = "btnAddUpdateAttachment";
            this.btnAddUpdateAttachment.Size = new System.Drawing.Size(119, 23);
            this.btnAddUpdateAttachment.TabIndex = 0;
            this.btnAddUpdateAttachment.Text = "Add/Update";
            this.btnAddUpdateAttachment.UseVisualStyleBackColor = true;
            this.btnAddUpdateAttachment.Click += new System.EventHandler(this.btnAddUpdateAttachment_Click);
            // 
            // mobileDatabaseExporterToolStripMenuItem
            // 
            this.mobileDatabaseExporterToolStripMenuItem.Name = "mobileDatabaseExporterToolStripMenuItem";
            this.mobileDatabaseExporterToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.mobileDatabaseExporterToolStripMenuItem.Text = "Mobile Database &Exporter";
            this.mobileDatabaseExporterToolStripMenuItem.Click += new System.EventHandler(this.mobileDatabaseExporterToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 653);
            this.Controls.Add(this.attachmentGroupBox);
            this.Controls.Add(this.headwordGroupBox);
            this.Controls.Add(this.entriesGroupBox);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.attributesGroupBox);
            this.Controls.Add(this.headwordsListGroupBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.manualHeadwordSorterGrpBox);
            this.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farhang 2.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.headwordsListGroupBox.ResumeLayout(false);
            this.headwordsListGroupBox.PerformLayout();
            this.entriesGroupBox.ResumeLayout(false);
            this.attributesGroupBox.ResumeLayout(false);
            this.attributesGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.previewGroupBox.ResumeLayout(false);
            this.manualHeadwordSorterGrpBox.ResumeLayout(false);
            this.manualHeadwordSorterGrpBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpBoxOriginal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOriginal)).EndInit();
            this.grpBoxSorted.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4Sort)).EndInit();
            this.headwordGroupBox.ResumeLayout(false);
            this.headwordGroupBox.PerformLayout();
            this.attachmentGroupBox.ResumeLayout(false);
            this.attachmentGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.GroupBox headwordsListGroupBox;
		private System.Windows.Forms.ComboBox cmbBoxLetter;
		private System.Windows.Forms.ListBox headwordsListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView entriesTreeView;
        private System.Windows.Forms.GroupBox entriesGroupBox;
        private System.Windows.Forms.GroupBox attributesGroupBox;
        private System.Windows.Forms.ComboBox cmbBoxTranslationLanguage;
        private System.Windows.Forms.ComboBox cmbBoxEntryType;
        private System.Windows.Forms.Label lblTranslation;
        private System.Windows.Forms.Label lblDestinationLanguage;
        private System.Windows.Forms.Label lblSourceText;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDictionaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem finishEditingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findHeadwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem zoom100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHeadwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteHeadwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem newEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem newSubentryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSubentryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem firstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dictionaryPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unmaximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutFarhang20ToolStripMenuItem;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnIPAKeyboard4Search;
        private System.Windows.Forms.Button btnIPAKeyboard4Translation;
        private System.Windows.Forms.Button btnIPAKeyboard4SourceText;
        public System.Windows.Forms.TextBox txtSourceText;
        public System.Windows.Forms.TextBox txtTranslation;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ToolStripMenuItem manualHeadwordSorterToolStripMenuItem;
        private System.Windows.Forms.GroupBox manualHeadwordSorterGrpBox;
        private System.Windows.Forms.ComboBox cmbBoxLetter4Sort;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.TextBox txtScratch;
        private System.Windows.Forms.Label lblScratchPad;
        private System.Windows.Forms.Button btnIPAKeyboard4MHSSearch;
        public System.Windows.Forms.TextBox txtMHSSearch;
        private System.Windows.Forms.Label lblMHSSearch;
        private System.Windows.Forms.Button btnSavePriorityList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpBoxOriginal;
        private System.Windows.Forms.DataGridView dataGridViewOriginal;
        private System.Windows.Forms.GroupBox grpBoxSorted;
        private System.Windows.Forms.TextBox txtTotal4MHS;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDeleteHeadword;
        private System.Windows.Forms.Button btnAddHeadword;
        private System.Windows.Forms.Button btnSaveEntry;
        private System.Windows.Forms.DataGridView dataGridView4Sort;
        private System.Windows.Forms.GroupBox headwordGroupBox;
        private System.Windows.Forms.Button btnSaveHeadword;
        private System.Windows.Forms.Button btnIPAKeyboard4Description;
        private System.Windows.Forms.Button btnIPAKeyboard4Pronunciation;
        private System.Windows.Forms.Button btnIPAKeyboard4Lemma;
        private System.Windows.Forms.CheckBox chkIncomplete;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPronunciation;
        private System.Windows.Forms.Label lblLemma;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtPronunciation;
        public System.Windows.Forms.TextBox txtLemma;
        private System.Windows.Forms.ToolStripLabel toolStripResult;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.Label lblLetter4Sort;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.GroupBox attachmentGroupBox;
        private System.Windows.Forms.Button btnRemoveAttachment;
        private System.Windows.Forms.Button btnAddUpdateAttachment;
        private System.Windows.Forms.Label lblAttachment;
        public System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.ToolStripMenuItem pDFBuilderToolStripMenuItem;
        private System.Windows.Forms.Label lblAttachmentTitle;
        public System.Windows.Forms.TextBox txtAttachmentTitle;
        private System.Windows.Forms.Label lblAttachmentTranslation;
        public System.Windows.Forms.TextBox txtAttachmentTranslation;
        private System.Windows.Forms.Label lblColumns;
        public System.Windows.Forms.TextBox txtAttachmentColumns;
        private System.Windows.Forms.ToolStripMenuItem mobileDatabaseExporterToolStripMenuItem;
	}
}
