namespace Protocol
{
    partial class DeletionReasonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeletionReasonForm));
            this.lblDelReason = new System.Windows.Forms.Label();
            this.txtDelReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDelReason
            // 
            this.lblDelReason.AutoSize = true;
            this.lblDelReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDelReason.Location = new System.Drawing.Point(175, 28);
            this.lblDelReason.Name = "lblDelReason";
            this.lblDelReason.Size = new System.Drawing.Size(234, 17);
            this.lblDelReason.TabIndex = 0;
            this.lblDelReason.Text = "Αιτιολογία Διαγραφής Πρωτοκόλλου";
            // 
            // txtDelReason
            // 
            this.txtDelReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDelReason.Location = new System.Drawing.Point(12, 73);
            this.txtDelReason.MaxLength = 255;
            this.txtDelReason.Multiline = true;
            this.txtDelReason.Name = "txtDelReason";
            this.txtDelReason.Size = new System.Drawing.Size(547, 177);
            this.txtDelReason.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::Protocol.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(579, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Protocol.Properties.Resources.Cancel_32x;
            this.pictureBox1.Location = new System.Drawing.Point(128, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // DeletionReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 262);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDelReason);
            this.Controls.Add(this.lblDelReason);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(750, 300);
            this.MinimumSize = new System.Drawing.Size(750, 300);
            this.Name = "DeletionReasonForm";
            this.Text = "Διαγραφή Πρωτοκόλλου";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDelReason;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtDelReason;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}