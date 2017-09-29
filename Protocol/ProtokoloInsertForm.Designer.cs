namespace Protocol
{
    partial class ProtokoloInsertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtokoloInsertForm));
            this.lblProtokoloKind = new System.Windows.Forms.Label();
            this.cbProtokoloKind = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.pbProtocol = new System.Windows.Forms.PictureBox();
            this.btnShowRecipients = new System.Windows.Forms.Button();
            this.chbSendMail = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbProtocol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProtokoloKind
            // 
            this.lblProtokoloKind.AutoSize = true;
            this.lblProtokoloKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProtokoloKind.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProtokoloKind.Location = new System.Drawing.Point(65, 28);
            this.lblProtokoloKind.Name = "lblProtokoloKind";
            this.lblProtokoloKind.Size = new System.Drawing.Size(165, 17);
            this.lblProtokoloKind.TabIndex = 0;
            this.lblProtokoloKind.Text = "Κατηγορία Πρωτοκόλλου";
            // 
            // cbProtokoloKind
            // 
            this.cbProtokoloKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbProtokoloKind.FormattingEnabled = true;
            this.cbProtokoloKind.Location = new System.Drawing.Point(236, 25);
            this.cbProtokoloKind.Name = "cbProtokoloKind";
            this.cbProtokoloKind.Size = new System.Drawing.Size(173, 24);
            this.cbProtokoloKind.TabIndex = 1;
            this.cbProtokoloKind.SelectedIndexChanged += new System.EventHandler(this.cbProtokoloKind_SelectedIndexChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCompany.Location = new System.Drawing.Point(65, 65);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 17);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Εταιρία";
            // 
            // cbCompany
            // 
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(236, 62);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(173, 24);
            this.cbCompany.TabIndex = 2;
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnInsert.Image = global::Protocol.Properties.Resources.Save_32x;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(430, 12);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(135, 40);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Καταχώρηση";
            this.btnInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // pbProtocol
            // 
            this.pbProtocol.Image = global::Protocol.Properties.Resources.AccountGroup_32x;
            this.pbProtocol.Location = new System.Drawing.Point(20, 40);
            this.pbProtocol.Name = "pbProtocol";
            this.pbProtocol.Size = new System.Drawing.Size(32, 32);
            this.pbProtocol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbProtocol.TabIndex = 11;
            this.pbProtocol.TabStop = false;
            // 
            // btnShowRecipients
            // 
            this.btnShowRecipients.Enabled = false;
            this.btnShowRecipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnShowRecipients.Image = global::Protocol.Properties.Resources.AccountAttribute_32x;
            this.btnShowRecipients.Location = new System.Drawing.Point(525, 104);
            this.btnShowRecipients.Name = "btnShowRecipients";
            this.btnShowRecipients.Size = new System.Drawing.Size(40, 40);
            this.btnShowRecipients.TabIndex = 10;
            this.btnShowRecipients.UseVisualStyleBackColor = true;
            this.btnShowRecipients.Click += new System.EventHandler(this.btnShowRecipients_Click);
            // 
            // chbSendMail
            // 
            this.chbSendMail.AutoSize = true;
            this.chbSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbSendMail.ForeColor = System.Drawing.Color.DarkBlue;
            this.chbSendMail.Image = global::Protocol.Properties.Resources.Outlook2013Logo_32xMD;
            this.chbSendMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chbSendMail.Location = new System.Drawing.Point(430, 109);
            this.chbSendMail.Name = "chbSendMail";
            this.chbSendMail.Size = new System.Drawing.Size(93, 32);
            this.chbSendMail.TabIndex = 9;
            this.chbSendMail.Text = "Email";
            this.chbSendMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbSendMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chbSendMail.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCancel.Image = global::Protocol.Properties.Resources.Cancel_32x;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(430, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Ακύρωση";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProtokoloInsertForm
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 672);
            this.Controls.Add(this.pbProtocol);
            this.Controls.Add(this.btnShowRecipients);
            this.Controls.Add(this.chbSendMail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cbProtokoloKind);
            this.Controls.Add(this.lblProtokoloKind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 710);
            this.MinimumSize = new System.Drawing.Size(600, 710);
            this.Name = "ProtokoloInsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εισαγωγή";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProtokoloInsertForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbProtocol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProtokoloKind;
        private System.Windows.Forms.Label lblCompany;
        public System.Windows.Forms.ComboBox cbProtokoloKind;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.Button btnInsert;
        public System.Windows.Forms.CheckBox chbSendMail;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnShowRecipients;
        private System.Windows.Forms.PictureBox pbProtocol;
    }
}