namespace Flummery
{
    partial class MaterialItem
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
            this.pbThumb = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // pbThumb
            // 
            this.pbThumb.BackColor = System.Drawing.Color.Black;
            this.pbThumb.Location = new System.Drawing.Point(1, 1);
            this.pbThumb.Name = "pbThumb";
            this.pbThumb.Size = new System.Drawing.Size(60, 60);
            this.pbThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumb.TabIndex = 0;
            this.pbThumb.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(1, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 12);
            this.lblName.TabIndex = 1;
            // 
            // MaterialItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbThumb);
            this.Name = "MaterialItem";
            this.Size = new System.Drawing.Size(62, 74);
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThumb;
        private System.Windows.Forms.Label lblName;
    }
}
