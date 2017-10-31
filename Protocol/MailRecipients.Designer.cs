namespace Protocol
{
    partial class MailRecipients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailRecipients));
            this.lblRecipientsBcc = new System.Windows.Forms.Label();
            this.lblRecipientsCc = new System.Windows.Forms.Label();
            this.txtRecipientsCc = new System.Windows.Forms.TextBox();
            this.txtRecipientsBcc = new System.Windows.Forms.TextBox();
            this.txtRecipientsTo = new System.Windows.Forms.TextBox();
            this.lblRecipientsTo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnShowRecLv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecipientsBcc
            // 
            this.lblRecipientsBcc.AutoSize = true;
            this.lblRecipientsBcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRecipientsBcc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblRecipientsBcc.Location = new System.Drawing.Point(75, 168);
            this.lblRecipientsBcc.Name = "lblRecipientsBcc";
            this.lblRecipientsBcc.Size = new System.Drawing.Size(44, 20);
            this.lblRecipientsBcc.TabIndex = 7;
            this.lblRecipientsBcc.Text = "Bcc: ";
            // 
            // lblRecipientsCc
            // 
            this.lblRecipientsCc.AutoSize = true;
            this.lblRecipientsCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRecipientsCc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblRecipientsCc.Location = new System.Drawing.Point(83, 102);
            this.lblRecipientsCc.Name = "lblRecipientsCc";
            this.lblRecipientsCc.Size = new System.Drawing.Size(36, 20);
            this.lblRecipientsCc.TabIndex = 6;
            this.lblRecipientsCc.Text = "Cc: ";
            // 
            // txtRecipientsCc
            // 
            this.txtRecipientsCc.BackColor = System.Drawing.Color.White;
            this.txtRecipientsCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRecipientsCc.Location = new System.Drawing.Point(125, 99);
            this.txtRecipientsCc.Multiline = true;
            this.txtRecipientsCc.Name = "txtRecipientsCc";
            this.txtRecipientsCc.ReadOnly = true;
            this.txtRecipientsCc.Size = new System.Drawing.Size(452, 50);
            this.txtRecipientsCc.TabIndex = 9;
            // 
            // txtRecipientsBcc
            // 
            this.txtRecipientsBcc.BackColor = System.Drawing.Color.White;
            this.txtRecipientsBcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRecipientsBcc.Location = new System.Drawing.Point(125, 165);
            this.txtRecipientsBcc.Multiline = true;
            this.txtRecipientsBcc.Name = "txtRecipientsBcc";
            this.txtRecipientsBcc.ReadOnly = true;
            this.txtRecipientsBcc.Size = new System.Drawing.Size(452, 50);
            this.txtRecipientsBcc.TabIndex = 10;
            // 
            // txtRecipientsTo
            // 
            this.txtRecipientsTo.BackColor = System.Drawing.Color.White;
            this.txtRecipientsTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRecipientsTo.Location = new System.Drawing.Point(125, 33);
            this.txtRecipientsTo.Multiline = true;
            this.txtRecipientsTo.Name = "txtRecipientsTo";
            this.txtRecipientsTo.ReadOnly = true;
            this.txtRecipientsTo.Size = new System.Drawing.Size(452, 50);
            this.txtRecipientsTo.TabIndex = 19;
            // 
            // lblRecipientsTo
            // 
            this.lblRecipientsTo.AutoSize = true;
            this.lblRecipientsTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRecipientsTo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblRecipientsTo.Location = new System.Drawing.Point(84, 36);
            this.lblRecipientsTo.Name = "lblRecipientsTo";
            this.lblRecipientsTo.Size = new System.Drawing.Size(35, 20);
            this.lblRecipientsTo.TabIndex = 18;
            this.lblRecipientsTo.Text = "To: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Protocol.Properties.Resources.AccountAttribute_32x;
            this.pictureBox1.Location = new System.Drawing.Point(21, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnShowRecLv
            // 
            this.btnShowRecLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnShowRecLv.Image = global::Protocol.Properties.Resources.LookupUser_32x;
            this.btnShowRecLv.Location = new System.Drawing.Point(282, 230);
            this.btnShowRecLv.Name = "btnShowRecLv";
            this.btnShowRecLv.Size = new System.Drawing.Size(40, 40);
            this.btnShowRecLv.TabIndex = 21;
            this.btnShowRecLv.UseVisualStyleBackColor = true;
            this.btnShowRecLv.Visible = false;
            this.btnShowRecLv.Click += new System.EventHandler(this.btnShowRecLv_Click);
            // 
            // MailRecipients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 282);
            this.Controls.Add(this.btnShowRecLv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtRecipientsTo);
            this.Controls.Add(this.lblRecipientsTo);
            this.Controls.Add(this.txtRecipientsBcc);
            this.Controls.Add(this.txtRecipientsCc);
            this.Controls.Add(this.lblRecipientsBcc);
            this.Controls.Add(this.lblRecipientsCc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(620, 320);
            this.MinimumSize = new System.Drawing.Size(620, 320);
            this.Name = "MailRecipients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Παραλήπτες";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRecipientsBcc;
        private System.Windows.Forms.Label lblRecipientsCc;
        private System.Windows.Forms.Label lblRecipientsTo;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtRecipientsCc;
        public System.Windows.Forms.TextBox txtRecipientsBcc;
        public System.Windows.Forms.TextBox txtRecipientsTo;
        public System.Windows.Forms.Button btnShowRecLv;
    }
}