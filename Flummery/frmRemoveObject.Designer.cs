namespace Flummery
{
    partial class frmRemoveObject
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
            this.gbName = new System.Windows.Forms.GroupBox();
            this.chkBone = new System.Windows.Forms.CheckBox();
            this.chkModel = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbName.Controls.Add(this.chkModel);
            this.gbName.Controls.Add(this.chkBone);
            this.gbName.Location = new System.Drawing.Point(12, 12);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(171, 69);
            this.gbName.TabIndex = 1;
            this.gbName.TabStop = false;
            this.gbName.Text = "Remove...";
            // 
            // chkBone
            // 
            this.chkBone.AutoSize = true;
            this.chkBone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBone.Location = new System.Drawing.Point(76, 19);
            this.chkBone.Name = "chkBone";
            this.chkBone.Size = new System.Drawing.Size(60, 17);
            this.chkBone.TabIndex = 0;
            this.chkBone.Text = "...Bone";
            this.chkBone.UseVisualStyleBackColor = true;
            this.chkBone.CheckedChanged += new System.EventHandler(this.chkBone_CheckedChanged);
            // 
            // chkModel
            // 
            this.chkModel.AutoSize = true;
            this.chkModel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkModel.Location = new System.Drawing.Point(72, 42);
            this.chkModel.Name = "chkModel";
            this.chkModel.Size = new System.Drawing.Size(64, 17);
            this.chkModel.TabIndex = 1;
            this.chkModel.Text = "...Model";
            this.chkModel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(108, 91);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(27, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRemoveObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 126);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemoveObject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remove Object...";
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.CheckBox chkModel;
        private System.Windows.Forms.CheckBox chkBone;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}