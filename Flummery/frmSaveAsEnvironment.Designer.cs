namespace Flummery
{
    partial class frmSaveAsEnvironment
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
            this.btnCRPath = new System.Windows.Forms.Button();
            this.txtCRPath = new System.Windows.Forms.TextBox();
            this.lblCRPath = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCRPath
            // 
            this.btnCRPath.Location = new System.Drawing.Point(499, 4);
            this.btnCRPath.Name = "btnCRPath";
            this.btnCRPath.Size = new System.Drawing.Size(29, 23);
            this.btnCRPath.TabIndex = 8;
            this.btnCRPath.Text = "...";
            this.btnCRPath.UseVisualStyleBackColor = true;
            // 
            // txtCRPath
            // 
            this.txtCRPath.Location = new System.Drawing.Point(160, 6);
            this.txtCRPath.Name = "txtCRPath";
            this.txtCRPath.Size = new System.Drawing.Size(333, 20);
            this.txtCRPath.TabIndex = 7;
            // 
            // lblCRPath
            // 
            this.lblCRPath.AutoSize = true;
            this.lblCRPath.Location = new System.Drawing.Point(12, 9);
            this.lblCRPath.Name = "lblCRPath";
            this.lblCRPath.Size = new System.Drawing.Size(71, 13);
            this.lblCRPath.TabIndex = 6;
            this.lblCRPath.Text = "Output Folder";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Output Folder";
            // 
            // frmSaveAsEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 490);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCRPath);
            this.Controls.Add(this.txtCRPath);
            this.Controls.Add(this.lblCRPath);
            this.Name = "frmSaveAsEnvironment";
            this.Text = "frmSaveAsEnvironment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCRPath;
        private System.Windows.Forms.TextBox txtCRPath;
        private System.Windows.Forms.Label lblCRPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}