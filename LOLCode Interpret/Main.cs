using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLCode_Interpret
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            {
                
                Stream myStream;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "LOL Files (*.lol)|*.lol";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Lexer.filePath = openFileDialog1.FileName.ToString();
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        myStream.Close();
                    }
                }
                lexemeClassificationGrid.DataSource = null;
                lexemeClassificationGrid.Rows.Clear();
                Lexer.keyMatch.Clear();
                Lexer.classification.Clear();

                Lexer.readPerLine(Lexer.filePath);
                codeTextBox.Text = Lexer.codeBlock;

                for (int i = 0; i < Lexer.keyMatch.Count(); i++)
                {
                    lexemeClassificationGrid.Rows.Add(Lexer.keyMatch[i], Lexer.classification[i]);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void codeLabel_Click(object sender, EventArgs e)
        {

        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
