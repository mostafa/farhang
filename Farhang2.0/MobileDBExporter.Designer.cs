namespace Farhang2
{
    partial class MobileDBExporter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerateMobileDB = new System.Windows.Forms.Button();
            this.grpBoxOutput = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblLetter = new System.Windows.Forms.Label();
            this.cmbBoxLetter = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkOutputPictures = new System.Windows.Forms.CheckBox();
            this.grpBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateMobileDB
            // 
            this.btnGenerateMobileDB.Location = new System.Drawing.Point(244, 8);
            this.btnGenerateMobileDB.Name = "btnGenerateMobileDB";
            this.btnGenerateMobileDB.Size = new System.Drawing.Size(189, 23);
            this.btnGenerateMobileDB.TabIndex = 0;
            this.btnGenerateMobileDB.Text = "Generate Mobile Database";
            this.btnGenerateMobileDB.UseVisualStyleBackColor = true;
            this.btnGenerateMobileDB.Click += new System.EventHandler(this.btnGenerateMobileDB_Click);
            // 
            // grpBoxOutput
            // 
            this.grpBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxOutput.Controls.Add(this.listBox1);
            this.grpBoxOutput.Location = new System.Drawing.Point(12, 65);
            this.grpBoxOutput.Name = "grpBoxOutput";
            this.grpBoxOutput.Size = new System.Drawing.Size(610, 371);
            this.grpBoxOutput.TabIndex = 1;
            this.grpBoxOutput.TabStop = false;
            this.grpBoxOutput.Text = "Output";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("DejaVu Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(604, 352);
            this.listBox1.TabIndex = 0;
            // 
            // lblLetter
            // 
            this.lblLetter.AutoSize = true;
            this.lblLetter.Location = new System.Drawing.Point(12, 13);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(37, 13);
            this.lblLetter.TabIndex = 10;
            this.lblLetter.Text = "Letter:";
            // 
            // cmbBoxLetter
            // 
            this.cmbBoxLetter.ItemHeight = 13;
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
            this.cmbBoxLetter.Location = new System.Drawing.Point(54, 9);
            this.cmbBoxLetter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbBoxLetter.Name = "cmbBoxLetter";
            this.cmbBoxLetter.Size = new System.Drawing.Size(185, 21);
            this.cmbBoxLetter.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(610, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // chkOutputPictures
            // 
            this.chkOutputPictures.AutoSize = true;
            this.chkOutputPictures.Checked = true;
            this.chkOutputPictures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutputPictures.Location = new System.Drawing.Point(525, 14);
            this.chkOutputPictures.Name = "chkOutputPictures";
            this.chkOutputPictures.Size = new System.Drawing.Size(97, 17);
            this.chkOutputPictures.TabIndex = 13;
            this.chkOutputPictures.Text = "Export Pictures";
            this.chkOutputPictures.UseVisualStyleBackColor = true;
            this.chkOutputPictures.Visible = false;
            // 
            // MobileDBExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 448);
            this.Controls.Add(this.chkOutputPictures);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblLetter);
            this.Controls.Add(this.grpBoxOutput);
            this.Controls.Add(this.cmbBoxLetter);
            this.Controls.Add(this.btnGenerateMobileDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MobileDBExporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Database Exporter";
            this.grpBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateMobileDB;
        private System.Windows.Forms.GroupBox grpBoxOutput;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.ComboBox cmbBoxLetter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkOutputPictures;
    }
}