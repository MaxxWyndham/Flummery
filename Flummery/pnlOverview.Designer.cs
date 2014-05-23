namespace Flummery
{
    partial class pnlOverview
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
            this.tvNodes = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvNodes
            // 
            this.tvNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvNodes.Location = new System.Drawing.Point(12, 12);
            this.tvNodes.Name = "tvNodes";
            this.tvNodes.Size = new System.Drawing.Size(133, 237);
            this.tvNodes.TabIndex = 0;
            this.tvNodes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNodes_NodeMouseClick);
            this.tvNodes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNodes_NodeMouseDoubleClick);
            // 
            // pnlOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 261);
            this.Controls.Add(this.tvNodes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "pnlOverview";
            this.Text = "pnlOverview";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvNodes;
    }
}