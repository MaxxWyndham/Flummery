namespace Flummery
{
    partial class frmRename
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
            this.lblRenameTo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblRename = new System.Windows.Forms.Label();
            this.chkActors = new System.Windows.Forms.CheckBox();
            this.chkModels = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRenameTo
            // 
            this.lblRenameTo.AutoSize = true;
            this.lblRenameTo.Location = new System.Drawing.Point(51, 9);
            this.lblRenameTo.Name = "lblRenameTo";
            this.lblRenameTo.Size = new System.Drawing.Size(62, 13);
            this.lblRenameTo.TabIndex = 0;
            this.lblRenameTo.Text = "Rename to:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(119, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblRename
            // 
            this.lblRename.AutoSize = true;
            this.lblRename.Location = new System.Drawing.Point(41, 34);
            this.lblRename.Name = "lblRename";
            this.lblRename.Size = new System.Drawing.Size(50, 13);
            this.lblRename.TabIndex = 2;
            this.lblRename.Text = "Rename:";
            // 
            // chkActors
            // 
            this.chkActors.AutoSize = true;
            this.chkActors.Checked = true;
            this.chkActors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActors.Location = new System.Drawing.Point(97, 33);
            this.chkActors.Name = "chkActors";
            this.chkActors.Size = new System.Drawing.Size(56, 17);
            this.chkActors.TabIndex = 3;
            this.chkActors.Text = "Actors";
            this.chkActors.UseVisualStyleBackColor = true;
            // 
            // chkModels
            // 
            this.chkModels.AutoSize = true;
            this.chkModels.Checked = true;
            this.chkModels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModels.Location = new System.Drawing.Point(159, 33);
            this.chkModels.Name = "chkModels";
            this.chkModels.Size = new System.Drawing.Size(60, 17);
            this.chkModels.TabIndex = 4;
            this.chkModels.Text = "Models";
            this.chkModels.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(63, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(144, 55);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 84);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(200, 318);
            this.textBox1.TabIndex = 7;
            this.textBox1.WordWrap = false;
            this.textBox1.Click += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // frmRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 414);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkModels);
            this.Controls.Add(this.chkActors);
            this.Controls.Add(this.lblRename);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblRenameTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRename";
            this.Text = "Rename Object(s)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRenameTo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRename;
        private System.Windows.Forms.CheckBox chkActors;
        private System.Windows.Forms.CheckBox chkModels;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox textBox1;
    }
}