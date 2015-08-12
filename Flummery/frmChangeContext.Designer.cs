namespace Flummery
{
    partial class frmChangeContext
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
            this.pnlButtonBox = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbContext = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGameContext = new System.Windows.Forms.ComboBox();
            this.cboModeContext = new System.Windows.Forms.ComboBox();
            this.pnlButtonBox.SuspendLayout();
            this.gbContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtonBox
            // 
            this.pnlButtonBox.Controls.Add(this.btnCancel);
            this.pnlButtonBox.Controls.Add(this.btnApply);
            this.pnlButtonBox.Controls.Add(this.btnOK);
            this.pnlButtonBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonBox.Location = new System.Drawing.Point(0, 112);
            this.pnlButtonBox.Name = "pnlButtonBox";
            this.pnlButtonBox.Size = new System.Drawing.Size(334, 30);
            this.pnlButtonBox.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(94, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(175, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(256, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbContext
            // 
            this.gbContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContext.Controls.Add(this.cboModeContext);
            this.gbContext.Controls.Add(this.cboGameContext);
            this.gbContext.Controls.Add(this.label2);
            this.gbContext.Controls.Add(this.label1);
            this.gbContext.Location = new System.Drawing.Point(12, 12);
            this.gbContext.Name = "gbContext";
            this.gbContext.Size = new System.Drawing.Size(310, 94);
            this.gbContext.TabIndex = 38;
            this.gbContext.TabStop = false;
            this.gbContext.Text = "Context";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Mode";
            // 
            // cboGameContext
            // 
            this.cboGameContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGameContext.FormattingEnabled = true;
            this.cboGameContext.Location = new System.Drawing.Point(102, 27);
            this.cboGameContext.Name = "cboGameContext";
            this.cboGameContext.Size = new System.Drawing.Size(197, 21);
            this.cboGameContext.TabIndex = 41;
            // 
            // cboModeContext
            // 
            this.cboModeContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeContext.FormattingEnabled = true;
            this.cboModeContext.Location = new System.Drawing.Point(102, 54);
            this.cboModeContext.Name = "cboModeContext";
            this.cboModeContext.Size = new System.Drawing.Size(197, 21);
            this.cboModeContext.TabIndex = 42;
            // 
            // frmChangeContext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 142);
            this.Controls.Add(this.gbContext);
            this.Controls.Add(this.pnlButtonBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeContext";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Current Context";
            this.pnlButtonBox.ResumeLayout(false);
            this.gbContext.ResumeLayout(false);
            this.gbContext.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtonBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbContext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGameContext;
        private System.Windows.Forms.ComboBox cboModeContext;
    }
}