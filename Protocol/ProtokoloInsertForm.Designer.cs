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
            this.lblProtokoloKind = new System.Windows.Forms.Label();
            this.cbProtokoloKind = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProtokoloKind
            // 
            this.lblProtokoloKind.AutoSize = true;
            this.lblProtokoloKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProtokoloKind.Location = new System.Drawing.Point(40, 28);
            this.lblProtokoloKind.Name = "lblProtokoloKind";
            this.lblProtokoloKind.Size = new System.Drawing.Size(165, 17);
            this.lblProtokoloKind.TabIndex = 0;
            this.lblProtokoloKind.Text = "Κατηγορία Πρωτοκόλλου";
            // 
            // cbProtokoloKind
            // 
            this.cbProtokoloKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbProtokoloKind.FormattingEnabled = true;
            this.cbProtokoloKind.Location = new System.Drawing.Point(211, 25);
            this.cbProtokoloKind.Name = "cbProtokoloKind";
            this.cbProtokoloKind.Size = new System.Drawing.Size(173, 24);
            this.cbProtokoloKind.TabIndex = 2;
            this.cbProtokoloKind.SelectedIndexChanged += new System.EventHandler(this.cbProtokoloKind_SelectedIndexChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(40, 65);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 17);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Εταιρία";
            // 
            // cbCompany
            // 
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(211, 62);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(173, 24);
            this.cbCompany.TabIndex = 1;
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnInsert.Location = new System.Drawing.Point(438, 12);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 40);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Καταχώρηση";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCancel.Location = new System.Drawing.Point(438, 59);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Ακύρωση";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProtokoloInsertForm
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 672);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cbProtokoloKind);
            this.Controls.Add(this.lblProtokoloKind);
            this.Name = "ProtokoloInsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εισαγωγή";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProtokoloInsertForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProtokoloKind;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ComboBox cbProtokoloKind;
        public System.Windows.Forms.ComboBox cbCompany;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Button btnInsert;
    }
}