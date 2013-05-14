using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farhang2
{
    public partial class IPAKeyboard : Form
    {
        MainForm parentForm;
        TextBox callingControl;
        //private List<Button> buttonList = new List<Button>();
        public static String[,] mainipa = new String[,] {  {"aː", "ɐ", "ɐ̯", "ã", "ãː", "a͜i", "aɪ", "a͜u", "aʊ", "ç"},
                                                        {"d͜ʒ", "eː", "ɛ", "ɛː", "ɛ̃", "ɛ̃ː", "ɛǝ", "eɪ", "ǝ", "iː"},
                                                        {"i̯", "ɪ", "l̩", "m̩", "n̩", "ŋ", "oː", "o̯", "õ", "õː"},
                                                        {"ɔ", "ø", "øː", "œ", "œ̃ː", "o͜u", "oʊ", "ɔ͜y", "ɔɪ", "ʃ"},
                                                        {"t͜s", "t͜ʃ", "θ", "uː", "u̯", "ʊ", "yː", "y̆", "ʏ", "ʒ"},
                                                        {"ʌ", "ӕ", "ð", "Ä", "ä", "Ö", "ö", "Ü", "ü", "ß"} };
        public static String[] combinations = new String[] { "∥ K-: ", "∥ -K: ", "∥ NB: ", "∥ ID ", "∥ zu ", "∥ hierzu ", "→" };
        public static String[] helpers1 = new String[] { "·", "̣", "|", "∥", "'", "ˌ", "↑", "®", "©", "‣" };
        public static String[] helpers2 = new String[] { "̲", "͟", "≈", "⌘", "↔", "à", "é", "¹", "²", "³" };
        public TextBox textView = new TextBox();

        public IPAKeyboard()
        {
            InitializeComponent();
        }

        public IPAKeyboard(MainForm form, TextBox sender)
        {
            InitializeComponent();
            parentForm = form;
            callingControl = sender;
        }

        private void IPAKeyboard_Load(object sender, EventArgs e)
        {
            int X = parentForm.PointToScreen(callingControl.Location).X + callingControl.Location.X - callingControl.Width / 2;
            int Y = parentForm.PointToScreen(callingControl.Location).Y + callingControl.Location.Y + callingControl.Height + 5;
            this.Location = new Point(X, Y);

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
                tmpBtn.Width = 60;
                tmpBtn.Height = 35;
                tmpBtn.Location = new Point(10 + (i * (tmpBtn.Width + 5)), 250);
                if (tmpBtn.Text == "∥ hierzu ")
                {
                    // hack for || hierzu button
                    tmpBtn.Width = 73;
                    tmpBtn.Location = new Point(335, 250);
                }

                if (tmpBtn.Text == "→")
                {
                    // hack for → button
                    tmpBtn.Location = new Point(tmpBtn.Location.X + 13, tmpBtn.Location.Y);
                }
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

            // construct a text box to show entered text using buttons
            textView.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 14, FontStyle.Bold);
            textView.Parent = this;
            textView.Width = 320;
            textView.Location = new Point(10, 373);
            textView.TextChanged += new EventHandler(textView_TextChanged);
            textView.Text += callingControl.Text;
            textView.Show();

            // construct copy button
            Button copyBtn = new Button();
            copyBtn.Text = "&Copy";
            copyBtn.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 10, FontStyle.Bold);
            copyBtn.Parent = this;
            copyBtn.Width = 60;
            copyBtn.Height = 35;
            copyBtn.Location = new Point(340, 373);
            //buttonList.Add(copyBtn);
            copyBtn.Click += new EventHandler(copyBtn_Click);
            copyBtn.Show();

            // construct clear button
            Button clearBtn = new Button();
            clearBtn.Text = "C&lear";
            clearBtn.Font = new System.Drawing.Font(new FontFamily("DejaVu Sans"), 10, FontStyle.Bold);
            clearBtn.Parent = this;
            clearBtn.Width = 60;
            clearBtn.Height = 35;
            clearBtn.Location = new Point(410, 373);
            //buttonList.Add(clearBtn);
            clearBtn.Click += new EventHandler(clearBtn_Click);
            clearBtn.Show();

            this.ResumeLayout();

            textView.Focus();
        }

        void copyBtn_Click(object sender, EventArgs e)
        {
            // reset clipboard
            Clipboard.Clear();
            // set clipboard text to the current value in textview text box
            Clipboard.SetText(textView.Text, TextDataFormat.UnicodeText);
        }

        void clearBtn_Click(object sender, EventArgs e)
        {
            // clear the textview text box
            textView.Text = "";
            // reset clipboard
            Clipboard.Clear();
        }

        void textView_TextChanged(object sender, EventArgs e)
        {
           callingControl.Text = textView.Text;
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
