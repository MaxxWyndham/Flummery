namespace Flummery
{
    partial class frmAbout
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
            pictureBox1 = new PictureBox();
            lblVersion = new Label();
            lblEmail = new LinkLabel();
            btnOk = new Button();
            btnUpdateCheck = new Button();
            btnDonate = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.flummery;
            pictureBox1.Location = new Point(13, 12);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(529, 217);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(14, 232);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(38, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "label1";
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Bottom;
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(10, 254);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(137, 15);
            lblEmail.TabIndex = 2;
            lblEmail.TabStop = true;
            lblEmail.Text = "errol@toxic-ragers.co.uk";
            lblEmail.LinkClicked += lblEmail_LinkClicked;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(453, 248);
            btnOk.Margin = new Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(88, 27);
            btnOk.TabIndex = 3;
            btnOk.Text = "close";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCheck
            // 
            btnUpdateCheck.Location = new Point(306, 248);
            btnUpdateCheck.Margin = new Padding(4, 3, 4, 3);
            btnUpdateCheck.Name = "btnUpdateCheck";
            btnUpdateCheck.Size = new Size(141, 27);
            btnUpdateCheck.TabIndex = 4;
            btnUpdateCheck.Text = "check for updates";
            btnUpdateCheck.UseVisualStyleBackColor = true;
            btnUpdateCheck.Click += btnUpdateCheck_Click;
            // 
            // btnDonate
            // 
            btnDonate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDonate.Location = new Point(211, 248);
            btnDonate.Margin = new Padding(4, 3, 4, 3);
            btnDonate.Name = "btnDonate";
            btnDonate.Size = new Size(88, 27);
            btnDonate.TabIndex = 5;
            btnDonate.Text = "donate";
            btnDonate.UseVisualStyleBackColor = true;
            btnDonate.Click += btnDonate_Click;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 288);
            Controls.Add(btnDonate);
            Controls.Add(btnUpdateCheck);
            Controls.Add(btnOk);
            Controls.Add(lblEmail);
            Controls.Add(lblVersion);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About Flummery";
            Load += frmAbout_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel lblEmail;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnUpdateCheck;
        private System.Windows.Forms.Button btnDonate;
    }
}