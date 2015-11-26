namespace Flummery
{
    partial class frmInterOpControl
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
            this.butStartServer = new System.Windows.Forms.Button();
            this.butStopServer = new System.Windows.Forms.Button();
            this.outputLog = new System.Windows.Forms.TextBox();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butStartServer
            // 
            this.butStartServer.Location = new System.Drawing.Point(119, 10);
            this.butStartServer.Name = "butStartServer";
            this.butStartServer.Size = new System.Drawing.Size(75, 23);
            this.butStartServer.TabIndex = 0;
            this.butStartServer.Text = "Start Server";
            this.butStartServer.UseVisualStyleBackColor = true;
            this.butStartServer.Click += new System.EventHandler(this.butStartServer_Click);
            // 
            // butStopServer
            // 
            this.butStopServer.Location = new System.Drawing.Point(200, 10);
            this.butStopServer.Name = "butStopServer";
            this.butStopServer.Size = new System.Drawing.Size(75, 23);
            this.butStopServer.TabIndex = 1;
            this.butStopServer.Text = "Stop Server";
            this.butStopServer.UseVisualStyleBackColor = true;
            this.butStopServer.Click += new System.EventHandler(this.butStopServer_Click);
            // 
            // outputLog
            // 
            this.outputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLog.Location = new System.Drawing.Point(12, 44);
            this.outputLog.Multiline = true;
            this.outputLog.Name = "outputLog";
            this.outputLog.Size = new System.Drawing.Size(260, 176);
            this.outputLog.TabIndex = 2;
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.Location = new System.Drawing.Point(55, 12);
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(58, 20);
            this.txtPortNumber.TabIndex = 3;
            this.txtPortNumber.Text = "666";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // serverStatus
            // 
            this.serverStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serverStatus.AutoSize = true;
            this.serverStatus.Location = new System.Drawing.Point(12, 223);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(37, 13);
            this.serverStatus.TabIndex = 5;
            this.serverStatus.Text = "Status";
            // 
            // frmInterOpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPortNumber);
            this.Controls.Add(this.outputLog);
            this.Controls.Add(this.butStopServer);
            this.Controls.Add(this.butStartServer);
            this.Name = "frmInterOpControl";
            this.Text = "DCC InterOp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInterOpControl_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butStartServer;
        private System.Windows.Forms.Button butStopServer;
        private System.Windows.Forms.TextBox outputLog;
        private System.Windows.Forms.TextBox txtPortNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label serverStatus;
    }
}