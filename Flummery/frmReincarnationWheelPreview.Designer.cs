namespace Flummery
{
    partial class frmReincarnationWheelPreview
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstWheels = new System.Windows.Forms.ListBox();
            this.lblPreviewPlaceholder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(383, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(302, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnClear.Location = new System.Drawing.Point(221, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lstWheels
            // 
            this.lstWheels.FormattingEnabled = true;
            this.lstWheels.Location = new System.Drawing.Point(12, 12);
            this.lstWheels.Name = "lstWheels";
            this.lstWheels.Size = new System.Drawing.Size(220, 160);
            this.lstWheels.TabIndex = 0;
            // 
            // lblPreviewPlaceholder
            // 
            this.lblPreviewPlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreviewPlaceholder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreviewPlaceholder.Location = new System.Drawing.Point(238, 12);
            this.lblPreviewPlaceholder.Name = "lblPreviewPlaceholder";
            this.lblPreviewPlaceholder.Size = new System.Drawing.Size(220, 160);
            this.lblPreviewPlaceholder.TabIndex = 32;
            this.lblPreviewPlaceholder.Text = "wheel preview preview goes here";
            this.lblPreviewPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReincarnationWheelPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 215);
            this.Controls.Add(this.lblPreviewPlaceholder);
            this.Controls.Add(this.lstWheels);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReincarnationWheelPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wheel Preview";
            this.Load += new System.EventHandler(this.frmReincarnationWheelPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstWheels;
        private System.Windows.Forms.Label lblPreviewPlaceholder;
    }
}