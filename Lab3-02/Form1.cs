using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_02
{
    public partial class Form1 : Form
    {
        private string currentFile = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dig.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(dig.FileName).ToLower() == ".rtf")
                    richTextBox1.LoadFile(dig.FileName);
                else
                    richTextBox1.Text = File.ReadAllText(dig.FileName);

                currentFile = dig.FileName;
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            currentFile = "";
        }
        private void ChangeSelectionFont(FontStyle style)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newStyle;

                if (currentFont.Style.HasFlag(style))
                    newStyle = currentFont.Style & ~style; // bỏ style
                else
                    newStyle = currentFont.Style | style;  // thêm style

                richTextBox1.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ChangeSelectionFont(FontStyle.Bold);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ChangeSelectionFont(FontStyle.Italic);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ChangeSelectionFont(FontStyle.Underline);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toolStripComboBox1.Text)) return;

            string fontName = toolStripComboBox1.Text;
            float fontSize = richTextBox1.SelectionFont != null ? richTextBox1.SelectionFont.Size : 14;

            richTextBox1.SelectionFont = new Font(fontName, fontSize);
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toolStripComboBox2.Text)) return;

            float fontSize;
            if (!float.TryParse(toolStripComboBox2.Text, out fontSize)) return;

            string fontName = richTextBox1.SelectionFont != null ? richTextBox1.SelectionFont.FontFamily.Name : "Tahoma";

            richTextBox1.SelectionFont = new Font(fontName, fontSize);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            currentFile = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog dig = new SaveFileDialog();
                dig.Filter = "Rich Text Format (*.rtf)|*.rtf";
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(dig.FileName);
                    currentFile = dig.FileName;
                    MessageBox.Show("Đã lưu văn bản thành công!");
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFile);
                MessageBox.Show("Đã lưu văn bản thành công!");
            }
        }
    }
}
