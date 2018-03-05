namespace Flummery
{
    partial class PnlDetails
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
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.Skins = new Flummery.Controls.Skins();
            this.Lighting = new Flummery.Controls.Lighting();
            this.Transform = new Flummery.Controls.Transform();
            this.pnlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPanel
            // 
            this.pnlPanel.AutoScroll = true;
            this.pnlPanel.AutoSize = true;
            this.pnlPanel.Controls.Add(this.Skins);
            this.pnlPanel.Controls.Add(this.Lighting);
            this.pnlPanel.Controls.Add(this.Transform);
            this.pnlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanel.Location = new System.Drawing.Point(0, 0);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(284, 488);
            this.pnlPanel.TabIndex = 0;
            // 
            // Skins
            // 
            this.Skins.AutoSize = true;
            this.Skins.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Skins.Dock = System.Windows.Forms.DockStyle.Top;
            this.Skins.Location = new System.Drawing.Point(0, 1206);
            this.Skins.Name = "Skins";
            this.Skins.Padding = new System.Windows.Forms.Padding(5);
            this.Skins.Size = new System.Drawing.Size(267, 70);
            this.Skins.TabIndex = 2;
            this.Skins.Visible = false;
            // 
            // Lighting
            // 
            this.Lighting.AutoSize = true;
            this.Lighting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Lighting.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lighting.Location = new System.Drawing.Point(0, 163);
            this.Lighting.MinimumSize = new System.Drawing.Size(210, 0);
            this.Lighting.Name = "Lighting";
            this.Lighting.Padding = new System.Windows.Forms.Padding(5);
            this.Lighting.Size = new System.Drawing.Size(267, 1043);
            this.Lighting.TabIndex = 1;
            this.Lighting.Visible = false;
            // 
            // Transform
            // 
            this.Transform.AutoScroll = true;
            this.Transform.AutoSize = true;
            this.Transform.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Transform.Dock = System.Windows.Forms.DockStyle.Top;
            this.Transform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transform.Location = new System.Drawing.Point(0, 0);
            this.Transform.MinimumSize = new System.Drawing.Size(174, 0);
            this.Transform.Name = "Transform";
            this.Transform.Padding = new System.Windows.Forms.Padding(5);
            this.Transform.Size = new System.Drawing.Size(267, 163);
            this.Transform.TabIndex = 0;
            this.Transform.Visible = false;
            // 
            // PnlDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 488);
            this.Controls.Add(this.pnlPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PnlDetails";
            this.Text = "Details";
            this.pnlPanel.ResumeLayout(false);
            this.pnlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanel;
        private Controls.Lighting Lighting;
        private Controls.Transform Transform;
        private Controls.Skins Skins;
    }
}