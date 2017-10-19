namespace Protocol
{
    partial class ContactsToEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsToEmail));
            this.txtRecipientsCc = new System.Windows.Forms.TextBox();
            this.txtRecipientsBcc = new System.Windows.Forms.TextBox();
            this.txtRecipientsTo = new System.Windows.Forms.TextBox();
            this.btnRecipientsBcc = new System.Windows.Forms.Button();
            this.btnRecipientsCc = new System.Windows.Forms.Button();
            this.btnRecipientsTo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRecipientsCc
            // 
            this.txtRecipientsCc.BackColor = System.Drawing.Color.White;
            this.txtRecipientsCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRecipientsCc.Location = new System.Drawing.Point(134, 99);
            this.txtRecipientsCc.Multiline = true;
            this.txtRecipientsCc.Name = "txtRecipientsCc";
            this.txtRecipientsCc.ReadOnly = true;
            this.txtRecipientsCc.Size = new System.Drawing.Size(443, 50);
            this.txtRecipientsCc.TabIndex = 5;
            // 
            // txtRecipientsBcc
            // 
            this.txtRecipientsBcc.BackColor = System.Drawing.Color.White;
            this.txtRecipientsBcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRecipientsBcc.Location = new System.Drawing.Point(134, 165);
            this.txtRecipientsBcc.Multiline = true;
            this.txtRecipientsBcc.Name = "txtRecipientsBcc";
            this.txtRecipientsBcc.ReadOnly = true;
            this.txtRecipientsBcc.Size = new System.Drawing.Size(443, 50);
            this.txtRecipientsBcc.TabIndex = 6;
            // 
            // txtRecipientsTo
            // 
            this.txtRecipientsTo.BackColor = System.Drawing.Color.White;
            this.txtRecipientsTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRecipientsTo.Location = new System.Drawing.Point(134, 33);
            this.txtRecipientsTo.Multiline = true;
            this.txtRecipientsTo.Name = "txtRecipientsTo";
            this.txtRecipientsTo.ReadOnly = true;
            this.txtRecipientsTo.Size = new System.Drawing.Size(443, 50);
            this.txtRecipientsTo.TabIndex = 4;
            // 
            // btnRecipientsBcc
            // 
            this.btnRecipientsBcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRecipientsBcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipientsBcc.Location = new System.Drawing.Point(75, 165);
            this.btnRecipientsBcc.Name = "btnRecipientsBcc";
            this.btnRecipientsBcc.Size = new System.Drawing.Size(54, 50);
            this.btnRecipientsBcc.TabIndex = 3;
            this.btnRecipientsBcc.Text = "Bcc...";
            this.btnRecipientsBcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipientsBcc.UseVisualStyleBackColor = true;
            this.btnRecipientsBcc.Click += new System.EventHandler(this.btnRecipientsBcc_Click);
            // 
            // btnRecipientsCc
            // 
            this.btnRecipientsCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRecipientsCc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipientsCc.Location = new System.Drawing.Point(75, 99);
            this.btnRecipientsCc.Name = "btnRecipientsCc";
            this.btnRecipientsCc.Size = new System.Drawing.Size(54, 50);
            this.btnRecipientsCc.TabIndex = 2;
            this.btnRecipientsCc.Text = "Cc...";
            this.btnRecipientsCc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipientsCc.UseVisualStyleBackColor = true;
            this.btnRecipientsCc.Click += new System.EventHandler(this.btnRecipientsCc_Click);
            // 
            // btnRecipientsTo
            // 
            this.btnRecipientsTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRecipientsTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipientsTo.Location = new System.Drawing.Point(75, 33);
            this.btnRecipientsTo.Name = "btnRecipientsTo";
            this.btnRecipientsTo.Size = new System.Drawing.Size(53, 50);
            this.btnRecipientsTo.TabIndex = 1;
            this.btnRecipientsTo.Text = "To...";
            this.btnRecipientsTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecipientsTo.UseVisualStyleBackColor = true;
            this.btnRecipientsTo.Click += new System.EventHandler(this.btnRecipientsTo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Protocol.Properties.Resources.LookupUser_32x;
            this.pictureBox1.Location = new System.Drawing.Point(21, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::Protocol.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(235, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ContactsToEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 302);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRecipientsBcc);
            this.Controls.Add(this.btnRecipientsCc);
            this.Controls.Add(this.btnRecipientsTo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtRecipientsTo);
            this.Controls.Add(this.txtRecipientsBcc);
            this.Controls.Add(this.txtRecipientsCc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(620, 340);
            this.MinimumSize = new System.Drawing.Size(620, 340);
            this.Name = "ContactsToEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Παραλήπτες";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtRecipientsCc;
        public System.Windows.Forms.TextBox txtRecipientsBcc;
        public System.Windows.Forms.TextBox txtRecipientsTo;
        private System.Windows.Forms.Button btnRecipientsTo;
        private System.Windows.Forms.Button btnRecipientsCc;
        private System.Windows.Forms.Button btnRecipientsBcc;
        public System.Windows.Forms.Button btnSave;
    }
}