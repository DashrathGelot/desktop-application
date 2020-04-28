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
using System.Drawing.Printing;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.Clear();
        }

        private void openTool_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"C:\";
            open.Title = "Select File";
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.DefaultExt = "txt";
            open.Filter = "Text Files (*.txt)|*.txt";
            if(open.ShowDialog()==DialogResult.OK)
            {
                using (StreamReader rd = new StreamReader(open.FileName))
                {
                    int count = 0;
                    string ln;
                    while((ln=rd.ReadLine())!=null)
                    {
                        Textareabox.Text = ln;
                        count++;
                    }
                    rd.Close();
                }
            }
            
        }

        private void exitTool_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveTool_Click(object sender, EventArgs e)
        {
            SaveFiles();  
        }
        public void SaveFiles()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "txt";
            save.Filter = "Text Files (*.txt)|*.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, Textareabox.Text);
            }
        }

        private void saveAsTool_Click(object sender, EventArgs e)
        {
            SaveFiles();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fon = new FontDialog();
            if(fon.ShowDialog()==DialogResult.OK)
            {
                Textareabox.Font = fon.Font;
                Textareabox.ForeColor = fon.Color;
            }
        }

        private void printTool_Click(object sender, EventArgs e)
        {
            PrintDialog prin = new PrintDialog();
            prin.ShowDialog();
        }

        private void pageSetupTool_Click(object sender, EventArgs e)
        {
            PageSetupDialog setupDlg = new PageSetupDialog();
           PrintDocument printDoc = new PrintDocument();
            PrintDialog prin = new PrintDialog();
            printDoc.DocumentName = "hello";
            setupDlg.Document = printDoc;
            setupDlg.AllowMargins = false;
            setupDlg.AllowOrientation = false;
            setupDlg.AllowPaper = false;
            setupDlg.AllowPrinter = false;
            setupDlg.Reset();
            if (setupDlg.ShowDialog() == DialogResult.OK)
            {
                printDoc.DefaultPageSettings = setupDlg.PageSettings;
                printDoc.PrinterSettings =
setupDlg.PrinterSettings;
            }
            
           
            //pages.ShowDialog();
            //  pages.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Textareabox.CanUndo)
            {
                Textareabox.Undo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.SelectedText = "";
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FindForm f = new FindForm();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.Text += Convert.ToString(DateTime.Now);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textareabox.SelectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
                
            
        }
      /*  void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            { MessageBox.Show("Your Word is Not Found", "Notepad", MessageBoxButtons.OK); }
        }*/
        private void Textareabox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            { MessageBox.Show("Your Word is Not Found", "Notepad", MessageBoxButtons.OK); }
        }
    }
}
