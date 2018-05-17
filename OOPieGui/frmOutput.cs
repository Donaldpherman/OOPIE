using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOPieGUI
{
    public partial class frmOutput : Form
    {
        string programName_;

        public frmOutput()
        {
            InitializeComponent();
        }

        public void Initialize(string programName)
        {
            programName_ = programName;
        }

        public void ExecuteProgram(string program)
        {

        }

        private void frmOutput_Load(object sender, EventArgs e)
        {
        }

        void Compiler_OnAction(object[] args)
        {
           
        }
        public void Clear()
        {
            txtOutput.Text = "";
        }
        public void setRichTextBox(string text)
        {
            txtOutput.Text = text;
        }

        public string ProgramName { get { return programName_; } }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
