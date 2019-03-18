using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Icon = new Icon(SystemIcons.Application, new Size(10, 10));
           
                     
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filePath = null;
            string fileContent = null;
            using (OpenFileDialog bb = new OpenFileDialog())
            {
                bb.InitialDirectory = "D:/";
                bb.Filter = "Text format (*.txt)|*.txt|Rich Text(*.rtf) | *.rtf";
                if(bb.ShowDialog()==DialogResult.OK)
                {
                    filePath = bb.FileName;
                    var fileStream = bb.OpenFile();
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        fileContent = streamReader.ReadToEnd();
                    }

                }
               
            }
            if(fileContent!= null)
            {
                textInside.Text = fileContent;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (textInside.Text.Equals(""))
                    {
                        MessageBox.Show("You haven`t entered any TEXT!");
                    }
                    File.WriteAllText(saveFileDialog.FileName,textInside.Text);
                }
            }
        }

        private void cutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (textInside.SelectionLength > 0)
            {
                textInside.Cut();
            }
                
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textInside.SelectionLength > 0)
            {
                textInside.Copy();
            }
               
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                textInside.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textInside.SelectAll();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                if(printDialog.ShowDialog()==DialogResult.OK)
                {
                   
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (textInside.Text.Equals(""))
             {
                MessageBox.Show("You haven`t entered any TEXT!");
             }
             File.WriteAllText("D:/sample.txt", textInside.Text);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if(textInside.SelectedText=="")
            {
                textInside.Font = new Font(comboBox.SelectedItem.ToString(), 12, FontStyle.Regular);
            }
            else
            {
                textInside.SelectionFont = new Font(comboBox.SelectedItem.ToString(), 12, FontStyle.Regular);
            }
        }

        private void textStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var style = (FontStyle)Enum.Parse(typeof(FontStyle), comboBox.SelectedItem.ToString());
            if (textInside.SelectedText == "")
            {            
                textInside.Font = new Font(textInside.Font, style);
            }
            else
            {
                textInside.SelectionFont = new Font(textInside.Font, style);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if(colorDialog.ShowDialog()==DialogResult.OK)
                {
                    button1.BackColor = colorDialog.Color;
                    Color selectedColor = colorDialog.Color;
                    if (textInside.SelectedText == "")
                    {
                        textInside.ForeColor = selectedColor;
                    }
                    else
                    {
                        textInside.SelectionColor = selectedColor;
                    }
                }
            }
            
        }
    }
}
