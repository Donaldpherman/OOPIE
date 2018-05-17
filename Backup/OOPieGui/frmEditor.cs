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
    public partial class frmEditor : Form
    {
        public string programName_;

        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public string ProgramName
        {
            get { return programName_; }
            set
            {
                programName_ = value;
                this.Text = String.Format("Editor - {0}", programName_);
            }
        }

        public string ProgramText
        {
            get { return txtCode.Text.Trim(); }
            set
            {
                txtCode.Text = value;
            }
        }

        private void frmEditor_Activated(object sender, EventArgs e)
        {
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
