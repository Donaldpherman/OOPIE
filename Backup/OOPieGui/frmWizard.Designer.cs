namespace OOPieGUI
{
    partial class frmWizard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProgramName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bCancel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bCreate, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program Name:";
            // 
            // txtProgramName
            // 
            this.txtProgramName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProgramName.Location = new System.Drawing.Point(176, 25);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(164, 20);
            this.txtProgramName.TabIndex = 1;
            this.txtProgramName.Text = "Sourcefile.cs";
            this.txtProgramName.TextChanged += new System.EventHandler(this.txtProgramName_TextChanged);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bCancel.Location = new System.Drawing.Point(220, 93);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bCreate
            // 
            this.bCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bCreate.Location = new System.Drawing.Point(48, 93);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(75, 23);
            this.bCreate.TabIndex = 2;
            this.bCreate.Text = "Create";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // frmWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 140);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWizard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Program Wizard";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProgramName;
        private System.Windows.Forms.Button bCreate;
    }
}