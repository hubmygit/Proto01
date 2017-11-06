namespace Protocol
{
    partial class UsersSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersSelect));
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblWinUser = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chlbCompany = new System.Windows.Forms.CheckedListBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtInsDt = new System.Windows.Forms.TextBox();
            this.lblInsDt = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblEmail.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblEmail.Location = new System.Drawing.Point(115, 92);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "Email: ";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFullName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFullName.Location = new System.Drawing.Point(83, 60);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(88, 20);
            this.lblFullName.TabIndex = 22;
            this.lblFullName.Text = "Full Name: ";
            // 
            // lblWinUser
            // 
            this.lblWinUser.AutoSize = true;
            this.lblWinUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblWinUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblWinUser.Location = new System.Drawing.Point(89, 28);
            this.lblWinUser.Name = "lblWinUser";
            this.lblWinUser.Size = new System.Drawing.Size(82, 20);
            this.lblWinUser.TabIndex = 21;
            this.lblWinUser.Text = "Win User: ";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFullName.Location = new System.Drawing.Point(213, 57);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(403, 26);
            this.txtFullName.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtEmail.Location = new System.Drawing.Point(213, 89);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(403, 26);
            this.txtEmail.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Protocol.Properties.Resources.User_32x;
            this.pictureBox1.Location = new System.Drawing.Point(30, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // chlbCompany
            // 
            this.chlbCompany.CheckOnClick = true;
            this.chlbCompany.Enabled = false;
            this.chlbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbCompany.FormattingEnabled = true;
            this.chlbCompany.Location = new System.Drawing.Point(213, 153);
            this.chlbCompany.Name = "chlbCompany";
            this.chlbCompany.Size = new System.Drawing.Size(403, 242);
            this.chlbCompany.TabIndex = 32;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCompany.Location = new System.Drawing.Point(87, 153);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(84, 20);
            this.lblCompany.TabIndex = 33;
            this.lblCompany.Text = "Company: ";
            // 
            // txtInsDt
            // 
            this.txtInsDt.BackColor = System.Drawing.Color.White;
            this.txtInsDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtInsDt.Location = new System.Drawing.Point(213, 121);
            this.txtInsDt.Name = "txtInsDt";
            this.txtInsDt.ReadOnly = true;
            this.txtInsDt.Size = new System.Drawing.Size(403, 26);
            this.txtInsDt.TabIndex = 36;
            // 
            // lblInsDt
            // 
            this.lblInsDt.AutoSize = true;
            this.lblInsDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInsDt.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblInsDt.Location = new System.Drawing.Point(54, 124);
            this.lblInsDt.Name = "lblInsDt";
            this.lblInsDt.Size = new System.Drawing.Size(117, 20);
            this.lblInsDt.TabIndex = 37;
            this.lblInsDt.Text = "Last Entrance: ";
            // 
            // cbUser
            // 
            this.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(213, 27);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(403, 24);
            this.cbUser.TabIndex = 38;
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // UsersSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 462);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.txtInsDt);
            this.Controls.Add(this.lblInsDt);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.chlbCompany);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblWinUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(680, 500);
            this.MinimumSize = new System.Drawing.Size(680, 500);
            this.Name = "UsersSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εμφάνιση Χρήστη";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblWinUser;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.CheckedListBox chlbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtInsDt;
        private System.Windows.Forms.Label lblInsDt;
        public System.Windows.Forms.ComboBox cbUser;
    }
}