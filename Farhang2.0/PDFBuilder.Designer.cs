namespace Farhang2
{
    partial class PDFBuilder
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
            this.btnGenerateTEXFile = new System.Windows.Forms.Button();
            this.grpBoxOutput = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblLetter = new System.Windows.Forms.Label();
            this.cmbBoxLetter = new System.Windows.Forms.ComboBox();
            this.grpBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateTEXFile
            // 
            this.btnGenerateTEXFile.Location = new System.Drawing.Point(244, 8);
            this.btnGenerateTEXFile.Name = "btnGenerateTEXFile";
            this.btnGenerateTEXFile.Size = new System.Drawing.Size(146, 23);
            this.btnGenerateTEXFile.TabIndex = 0;
            this.btnGenerateTEXFile.Text = "Generate TEX file";
            this.btnGenerateTEXFile.UseVisualStyleBackColor = true;
            this.btnGenerateTEXFile.Click += new System.EventHandler(this.btnGenerateTEXFile_Click);
            // 
            // grpBoxOutput
            // 
            this.grpBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxOutput.Controls.Add(this.listBox1);
            this.grpBoxOutput.Location = new System.Drawing.Point(12, 36);
            this.grpBoxOutput.Name = "grpBoxOutput";
            this.grpBoxOutput.Size = new System.Drawing.Size(608, 398);
            this.grpBoxOutput.TabIndex = 1;
            this.grpBoxOutput.TabStop = false;
            this.grpBoxOutput.Text = "Output";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(602, 379);
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
            // PDFBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.lblLetter);
            this.Controls.Add(this.grpBoxOutput);
            this.Controls.Add(this.cmbBoxLetter);
            this.Controls.Add(this.btnGenerateTEXFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PDFBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFBuilder";
            this.grpBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateTEXFile;
        private System.Windows.Forms.GroupBox grpBoxOutput;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.ComboBox cmbBoxLetter;
    }
}