﻿namespace Protocol
{
    partial class FoldersInsertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoldersInsertForm));
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescr = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblProced = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.cbProced = new System.Windows.Forms.ComboBox();
            this.pbFolder = new System.Windows.Forms.PictureBox();
            this.btnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblId.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblId.Location = new System.Drawing.Point(39, 17);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 17);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            this.lblId.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblName.Location = new System.Drawing.Point(39, 119);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(111, 17);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Όνομα Φακέλου";
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescr.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDescr.Location = new System.Drawing.Point(39, 153);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(76, 17);
            this.lblDescr.TabIndex = 21;
            this.lblDescr.Text = "Περιγραφή";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtId.Location = new System.Drawing.Point(219, 14);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(280, 23);
            this.txtId.TabIndex = 1;
            this.txtId.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtName.Location = new System.Drawing.Point(219, 116);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 23);
            this.txtName.TabIndex = 4;
            // 
            // txtDescr
            // 
            this.txtDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescr.Location = new System.Drawing.Point(219, 150);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(280, 50);
            this.txtDescr.TabIndex = 5;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCompany.Location = new System.Drawing.Point(39, 51);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 17);
            this.lblCompany.TabIndex = 7;
            this.lblCompany.Text = "Εταιρία";
            // 
            // lblProced
            // 
            this.lblProced.AutoSize = true;
            this.lblProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProced.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProced.Location = new System.Drawing.Point(39, 85);
            this.lblProced.Name = "lblProced";
            this.lblProced.Size = new System.Drawing.Size(165, 17);
            this.lblProced.TabIndex = 8;
            this.lblProced.Text = "Κατηγορία Πρωτοκόλλου";
            // 
            // cbCompany
            // 
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(219, 48);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(280, 24);
            this.cbCompany.TabIndex = 22;
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // cbProced
            // 
            this.cbProced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbProced.FormattingEnabled = true;
            this.cbProced.Location = new System.Drawing.Point(219, 82);
            this.cbProced.Name = "cbProced";
            this.cbProced.Size = new System.Drawing.Size(280, 24);
            this.cbProced.TabIndex = 23;
            this.cbProced.SelectedIndexChanged += new System.EventHandler(this.cbProced_SelectedIndexChanged);
            // 
            // pbFolder
            // 
            this.pbFolder.Image = global::Protocol.Properties.Resources.FolderOpen_32x;
            this.pbFolder.Location = new System.Drawing.Point(585, 168);
            this.pbFolder.Name = "pbFolder";
            this.pbFolder.Size = new System.Drawing.Size(32, 32);
            this.pbFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFolder.TabIndex = 24;
            this.pbFolder.TabStop = false;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnInsert.Image = global::Protocol.Properties.Resources.Save_32x;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(532, 48);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(135, 40);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Καταχώρηση";
            this.btnInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // FoldersInsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 262);
            this.Controls.Add(this.pbFolder);
            this.Controls.Add(this.cbProced);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.lblProced);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(710, 300);
            this.MinimumSize = new System.Drawing.Size(710, 300);
            this.Name = "FoldersInsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Δημιουργία Νέου Φακέλου";
            ((System.ComponentModel.ISupportInitialize)(this.pbFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescr;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblProced;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.ComboBox cbProced;
        public System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.PictureBox pbFolder;
        public System.Windows.Forms.Label lblId;
    }
}