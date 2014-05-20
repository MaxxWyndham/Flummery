namespace Flummery
{
    partial class frmNewObject
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
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblChildOf = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.rdoTypeModel = new System.Windows.Forms.RadioButton();
            this.rdoTypeEmpty = new System.Windows.Forms.RadioButton();
            this.lblChildOfValue = new System.Windows.Forms.Label();
            this.btnChildBrowse = new System.Windows.Forms.Button();
            this.btnModelBrowse = new System.Windows.Forms.Button();
            this.lblModelValue = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbName.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbName.Controls.Add(this.txtName);
            this.gbName.Location = new System.Drawing.Point(12, 12);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(303, 45);
            this.gbName.TabIndex = 0;
            this.gbName.TabStop = false;
            this.gbName.Text = "Name";
            // 
            // gbProperties
            // 
            this.gbProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProperties.Controls.Add(this.lblModelValue);
            this.gbProperties.Controls.Add(this.btnModelBrowse);
            this.gbProperties.Controls.Add(this.btnChildBrowse);
            this.gbProperties.Controls.Add(this.lblChildOfValue);
            this.gbProperties.Controls.Add(this.rdoTypeEmpty);
            this.gbProperties.Controls.Add(this.rdoTypeModel);
            this.gbProperties.Controls.Add(this.lblModel);
            this.gbProperties.Controls.Add(this.lblChildOf);
            this.gbProperties.Controls.Add(this.lblType);
            this.gbProperties.Location = new System.Drawing.Point(12, 63);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(303, 107);
            this.gbProperties.TabIndex = 0;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Properties";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(6, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(291, 20);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "New object";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(39, 25);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // lblChildOf
            // 
            this.lblChildOf.AutoSize = true;
            this.lblChildOf.Location = new System.Drawing.Point(28, 51);
            this.lblChildOf.Name = "lblChildOf";
            this.lblChildOf.Size = new System.Drawing.Size(45, 13);
            this.lblChildOf.TabIndex = 1;
            this.lblChildOf.Text = "Child of:";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(34, 80);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model:";
            // 
            // rdoTypeModel
            // 
            this.rdoTypeModel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoTypeModel.Enabled = false;
            this.rdoTypeModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoTypeModel.Location = new System.Drawing.Point(79, 19);
            this.rdoTypeModel.Name = "rdoTypeModel";
            this.rdoTypeModel.Size = new System.Drawing.Size(64, 24);
            this.rdoTypeModel.TabIndex = 3;
            this.rdoTypeModel.Text = "Model";
            this.rdoTypeModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoTypeModel.UseVisualStyleBackColor = true;
            // 
            // rdoTypeEmpty
            // 
            this.rdoTypeEmpty.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoTypeEmpty.Checked = true;
            this.rdoTypeEmpty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoTypeEmpty.Location = new System.Drawing.Point(149, 19);
            this.rdoTypeEmpty.Name = "rdoTypeEmpty";
            this.rdoTypeEmpty.Size = new System.Drawing.Size(64, 24);
            this.rdoTypeEmpty.TabIndex = 4;
            this.rdoTypeEmpty.TabStop = true;
            this.rdoTypeEmpty.Text = "Empty";
            this.rdoTypeEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoTypeEmpty.UseVisualStyleBackColor = true;
            // 
            // lblChildOfValue
            // 
            this.lblChildOfValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChildOfValue.Location = new System.Drawing.Point(79, 46);
            this.lblChildOfValue.Name = "lblChildOfValue";
            this.lblChildOfValue.Size = new System.Drawing.Size(134, 23);
            this.lblChildOfValue.TabIndex = 5;
            this.lblChildOfValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChildBrowse
            // 
            this.btnChildBrowse.Enabled = false;
            this.btnChildBrowse.Location = new System.Drawing.Point(219, 46);
            this.btnChildBrowse.Name = "btnChildBrowse";
            this.btnChildBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnChildBrowse.TabIndex = 7;
            this.btnChildBrowse.Text = "select";
            this.btnChildBrowse.UseVisualStyleBackColor = true;
            // 
            // btnModelBrowse
            // 
            this.btnModelBrowse.Enabled = false;
            this.btnModelBrowse.Location = new System.Drawing.Point(219, 75);
            this.btnModelBrowse.Name = "btnModelBrowse";
            this.btnModelBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnModelBrowse.TabIndex = 8;
            this.btnModelBrowse.Text = "select";
            this.btnModelBrowse.UseVisualStyleBackColor = true;
            // 
            // lblModelValue
            // 
            this.lblModelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModelValue.Location = new System.Drawing.Point(79, 75);
            this.lblModelValue.Name = "lblModelValue";
            this.lblModelValue.Size = new System.Drawing.Size(134, 23);
            this.lblModelValue.TabIndex = 9;
            this.lblModelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(240, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(159, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNewObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 215);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbProperties);
            this.Controls.Add(this.gbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewObject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Object...";
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.gbProperties.ResumeLayout(false);
            this.gbProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.Label lblModelValue;
        private System.Windows.Forms.Button btnModelBrowse;
        private System.Windows.Forms.Button btnChildBrowse;
        private System.Windows.Forms.Label lblChildOfValue;
        private System.Windows.Forms.RadioButton rdoTypeEmpty;
        private System.Windows.Forms.RadioButton rdoTypeModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblChildOf;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}