namespace Flummery.Controls
{
    partial class Skins
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Skins));
            this.btnPanelTitle = new System.Windows.Forms.Button();
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.lblSkinName = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPanelTitle
            // 
            this.btnPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPanelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanelTitle.Location = new System.Drawing.Point(5, 5);
            this.btnPanelTitle.Name = "btnPanelTitle";
            this.btnPanelTitle.Size = new System.Drawing.Size(307, 23);
            this.btnPanelTitle.TabIndex = 50;
            this.btnPanelTitle.Text = "Skins";
            this.btnPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanelTitle.UseVisualStyleBackColor = true;
            this.btnPanelTitle.Click += new System.EventHandler(this.btnPanelTitle_Click);
            // 
            // pnlPanel
            // 
            this.pnlPanel.AutoSize = true;
            this.pnlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPanel.Controls.Add(this.label2);
            this.pnlPanel.Controls.Add(this.button2);
            this.pnlPanel.Controls.Add(this.label1);
            this.pnlPanel.Controls.Add(this.button1);
            this.pnlPanel.Controls.Add(this.lblSkinName);
            this.pnlPanel.Controls.Add(this.btnPreview);
            this.pnlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanel.Location = new System.Drawing.Point(5, 28);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(307, 130);
            this.pnlPanel.TabIndex = 51;
            // 
            // lblSkinName
            // 
            this.lblSkinName.AutoSize = true;
            this.lblSkinName.Location = new System.Drawing.Point(3, 12);
            this.lblSkinName.Name = "lblSkinName";
            this.lblSkinName.Size = new System.Drawing.Size(44, 13);
            this.lblSkinName.TabIndex = 49;
            this.lblSkinName.Text = "Position";
            this.lblSkinName.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.Location = new System.Drawing.Point(277, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(25, 27);
            this.btnPreview.TabIndex = 55;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Position";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(277, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 27);
            this.button1.TabIndex = 57;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Position";
            this.label2.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(277, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 27);
            this.button2.TabIndex = 59;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // Skins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPanel);
            this.Controls.Add(this.btnPanelTitle);
            this.Name = "Skins";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(317, 163);
            this.pnlPanel.ResumeLayout(false);
            this.pnlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPanelTitle;
        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.Label lblSkinName;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}
