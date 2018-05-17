using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OOPieCore;

namespace OOPieGUI
{
    public partial class frmMain : Form
    {
        //List of open editor windows - possibly another data structure in future?
        List<frmEditor> editors_ = new List<frmEditor>();
        Dictionary<string, frmOutput> outputWindows_ = new Dictionary<string, frmOutput>();
        frmEditor activeEditor_ = null;

        frmOutput frmOutput;

        /// <summary>
        /// Main form initialization functions go here
        /// </summary>
        public frmMain()
        {            
            InitializeComponent();
            frmWizard.OnCreate += new frmWizard.OnCreateHandler(frmWizard_OnCreate);
        }

        /// <summary>
        /// Event when create button is clicked on New Program Wizard
        /// </summary>
        /// <param name="programName">
        /// The name of new program, in future the new program settings, 
        /// which will be a class
        /// </param>
        void frmWizard_OnCreate(string programName)
        {
            frmEditor editor = new frmEditor(); //create new editor window
            editor.MdiParent = this; //set it as a child to Main Form
            editor.ProgramName = programName;
            editor.Show(); //display it
            editor.FormClosing += new FormClosingEventHandler(editor_FormClosing); //Add event handler to catch events when form is closed
            editor.Activated += new EventHandler(editor_Activated);
            editors_.Add(editor); //add it to active editors list
            activeEditor_ = editor; //set it as active
            this.Text = String.Format("OOPie - {0}", activeEditor_.programName_);
            EditorWindowsUpdate();
        }

        void editor_Activated(object sender, EventArgs e)
        {
            activeEditor_ = (frmEditor)sender;
            this.Text = String.Format("OO Pie - {0}", activeEditor_.programName_);
        }

        /// <summary>
        /// Exit OOPie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// New Program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWizard wizard = new frmWizard();
            wizard.ShowDialog();            
        }

        /// <summary>
        /// Close open program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            editors_.Remove((frmEditor)sender);
            EditorWindowsUpdate();
            //in future add "Would you like to save?" dialog
        }

        /// <summary>
        /// Update list of active editors in the Window toolbar
        /// </summary>
        private void EditorWindowsUpdate()
        {
            windowToolStripMenuItem.DropDownItems.Clear();
            foreach (frmEditor editor in editors_)
            {
                windowToolStripMenuItem.DropDownItems.Add(editor.ProgramName);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmIntro intro = new frmIntro();
            intro.ShowDialog();
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editors_.Count == 0)
            {
                MessageBox.Show("No files open!", "OOPie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (activeEditor_ == null)
            {
                MessageBox.Show("No active editor found!", "OOPie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Text = activeEditor_.ProgramText;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "C# cs files (*.cs)|*.cs|All files (*.*)|*.*";
            sf.AddExtension = true;
            sf.FileName = activeEditor_.ProgramName;
            if (sf.ShowDialog() == DialogResult.OK)
            {
                OOPieIO.Save(sf.FileName, Text);
                MessageBox.Show("File saved", "OOPies", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "C# cs files (*.cs)|*.cs|All files (*.*)|*.*";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in of.FileNames)
                {
                    try
                    {
                        //string program = OOPieIO.Load(of.FileName);
                        string program = OOPieIO.Load(fileName);
                        frmEditor editor = new frmEditor(); //create new editor window
                        editor.MdiParent = this; //set it as a child to Main Form
                        //editor.ProgramName = of.FileName;
                        editor.ProgramName = fileName;
                        editor.ProgramText = program;
                        editor.Show(); //display it
                        editor.FormClosing += new FormClosingEventHandler(editor_FormClosing); //Add event handler to catch events when form is closed
                        editor.Activated += new EventHandler(editor_Activated);
                        editors_.Add(editor); //add it to active editors list
                        activeEditor_ = editor; //set it as active
                        this.Text = String.Format("OO Pie - {0}", activeEditor_.programName_);
                        EditorWindowsUpdate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to read OOPie file!", "OOPie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            Run();

            OutPut();
        }

        /// <summary>
        /// Runs the program in the active editor window
        /// </summary>
        private void Run()
        {
            if (activeEditor_ == null)
            {
                MessageBox.Show("No active editor found!", "OO Pie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (frmOutput != null)
                frmOutput.Dispose();

            Helper.clear();

            foreach (frmEditor editor in editors_)
            {
                Pie.LoadParser(editor.programName_);
            }
        }

        private void OutPut()
        {
            frmOutput = new frmOutput();
            frmOutput.MdiParent = this;
            frmOutput.Show();
            frmOutput.setRichTextBox(Helper.ToString());
            //output.Left = this.Width - output.Width - 35;
            //output.Top = 0;
            //output.Initialize(programName);
            //outputWindows_.Add(programName, output);
            frmOutput.FormClosed += new FormClosedEventHandler(output_FormClosed);
        }



        /// <summary>
        /// Find the  existent output window by program name. If none exists, create a new one
        /// </summary>
        /// <param name="programName"></param>
        /// <returns></returns>
        private frmOutput GetOutputWindow(string programName)
        {
            if (outputWindows_.Keys.Contains(programName))
                return outputWindows_[programName];

            frmOutput output = new frmOutput();
            output.MdiParent = this;
            output.Show();
            output.Left = this.Width - output.Width - 35;
            output.Top = 0;
            output.Initialize(programName);
            outputWindows_.Add(programName, output);
            output.FormClosed += new FormClosedEventHandler(output_FormClosed);
            return output;
        }

        void output_FormClosed(object sender, FormClosedEventArgs e)
        {            
            //outputWindows_.Remove(((frmOutput)sender).ProgramName);
        }

        /*
        private frmErrList GetErrorWindow(string programName)
        {
            if (errorWindows_.Keys.Contains(programName))
                return errorWindows_[programName];

            frmErrList errors = new frmErrList();
            errors.MdiParent = this;
            errors.Show();
            errors.Left = this.Width - errors.Width - 35;
            errors.Top = this.Height - errors.Height - 115;
            errors.Initialize(programName);
            errorWindows_.Add(programName, errors);
            errors.FormClosed += new FormClosedEventHandler(errors_FormClosed);
            return errors;
        }
         * */

        void errors_FormClosed(object sender, FormClosedEventArgs e)
        {
            //errorWindows_.Remove(((frmErrList)sender).ProgramName);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
