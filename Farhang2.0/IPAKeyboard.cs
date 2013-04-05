using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farhang2._0
{
    public partial class IPAKeyboard : Form
    {
        public Boolean instance = false;
        MainForm parentForm;
        //private List<Button> buttonList = new List<Button>();
        private static String[,] mainipa = new String[,] {  {"aː", "ɐ", "ɐ̯", "ã", "ãː", "a͜i", "aɪ", "a͜u", "aʊ", "ç"},
                                                        {"d͜ʒ", "eː", "ɛ", "ɛː", "ɛ̃", "ɛ̃ː", "ɛǝ", "eɪ", "ǝ", "iː"},
                                                        {"i̯", "ɪ", "l̩", "m̩", "n̩", "ŋ", "oː", "o̯", "õ", "õː"},
                                                        {"ɔ", "ø", "øː", "œ", "œ̃ː", "o͜u", "oʊ", "ɔ͜y", "ɔɪ", "ʃ"},
                                                        {"t͜s", "t͜ʃ", "θ", "uː", "u̯", "ʊ", "yː", "y̆", "ʏ", "ʒ"},
                                                        {"ʌ", "ӕ", "ð", "Ä", "ä", "Ö", "ö", "Ü", "ü", "ß"} };
        private static String[] combinations = new String[] { "∥ K-: ", "∥ -K: ", "∥ NB: ", "∥ ID ", "∥ zu ", "∥ hierzu " };
        private static String[] helpers1 = new String[] { "·", "̣", "|", "∥", "'", "ˌ", "↑", "®", "©", "‣" };
        private static String[] helpers2 = new String[] { "̲", "͟", "≈", "⌘", "↔", "à", "é", "¹", "²", "³" };
        TextBox textView = new TextBox();

        public IPAKeyboard()
        {
            InitializeComponent();

            if (instance == false)
            {
                instance = true;
            }
            else
            {
                this.Dispose();
            }
        }

        public IPAKeyboard(MainForm form)
        {
            InitializeComponent();
            parentForm = form;

            if (instance == false)
            {
                instance = true;
            }
            else
            {
                this.Dispose();
            }
        }

        private void IPAKeyboard_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            // create main ipa buttons
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button tmpBtn = new Button();
                    tmpBtn.Text = mainipa[i, j].ToString();
                    tmpBtn.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 10, FontStyle.Bold);
                    tmpBtn.Parent = this;
                    tmpBtn.Width = 42;
                    tmpBtn.Height = 35;
                    tmpBtn.Location = new Point(10 + (j * 47), 10 + (i * (tmpBtn.Height + 5)));
                    //buttonList.Add(tmpBtn);
                    tmpBtn.Click += new EventHandler(tmpBtn_Click);
                    tmpBtn.Show();
                }
            }

            // create combinations' buttons
            for (int i = 0; i < combinations.Length; i++)
            {
                Button tmpBtn = new Button();
                tmpBtn.Text = combinations[i].ToString();
                tmpBtn.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 9, FontStyle.Bold);
                tmpBtn.Parent = this;
                tmpBtn.Width = 73;
                tmpBtn.Height = 35;
                tmpBtn.Location = new Point(10 + (i * (tmpBtn.Width + 5)), 250);
                //buttonList.Add(tmpBtn);
                tmpBtn.Click += new EventHandler(tmpBtn_Click);
                tmpBtn.Show();
            }

            // create helpers1 buttons
            for (int i = 0; i < helpers1.Length; i++)
            {
                Button tmpBtn = new Button();
                tmpBtn.Text = helpers1[i].ToString();
                tmpBtn.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 10, FontStyle.Bold);
                tmpBtn.Parent = this;
                tmpBtn.Width = 42;
                tmpBtn.Height = 35;
                tmpBtn.Location = new Point(10 + (i * (tmpBtn.Width + 5)), 290);
                //buttonList.Add(tmpBtn);
                tmpBtn.Click +=new EventHandler(tmpBtn_Click);
                tmpBtn.Show();
            }

            // create helpers2 buttons
            for (int i = 0; i < helpers2.Length; i++)
            {
                Button tmpBtn = new Button();
                tmpBtn.Text = helpers2[i].ToString();
                tmpBtn.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 10, FontStyle.Bold);
                tmpBtn.Parent = this;
                tmpBtn.Width = 42;
                tmpBtn.Height = 35;
                tmpBtn.Location = new Point(10 + (i * (tmpBtn.Width + 5)), 330);
                //buttonList.Add(tmpBtn);
                tmpBtn.Click += new EventHandler(tmpBtn_Click);
                tmpBtn.Show();
            }

            textView.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 14, FontStyle.Bold);
            textView.Parent = this;
            textView.Width = this.Width - 28;
            textView.Location = new Point(10, 373);
            textView.TextChanged += new EventHandler(textView_TextChanged);
            textView.Show();

            this.ResumeLayout();

            textView.Focus();
        }

        void textView_TextChanged(object sender, EventArgs e)
        {
           parentForm.txtSearch.Text = textView.Text;
        }

        void tmpBtn_Click(object sender, EventArgs e)
        {
            var obj = (Button)sender;

            int oldSelectionIndex = textView.SelectionStart;
            textView.Text = textView.Text.Insert(oldSelectionIndex, obj.Text);
            textView.SelectionStart = oldSelectionIndex + obj.Text.Length;
            textView.Focus();
        }
    }
}
