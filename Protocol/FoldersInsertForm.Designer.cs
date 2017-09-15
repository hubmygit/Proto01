namespace Protocol
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescr = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblId.Location = new System.Drawing.Point(12, 11);
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
            this.lblName.Location = new System.Drawing.Point(12, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(111, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Όνομα Φακέλου";
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescr.Location = new System.Drawing.Point(12, 78);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(76, 17);
            this.lblDescr.TabIndex = 2;
            this.lblDescr.Text = "Περιγραφή";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtId.Location = new System.Drawing.Point(129, 8);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(280, 23);
            this.txtId.TabIndex = 3;
            this.txtId.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtName.Location = new System.Drawing.Point(129, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 23);
            this.txtName.TabIndex = 4;
            // 
            // txtDescr
            // 
            this.txtDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescr.Location = new System.Drawing.Point(129, 75);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(280, 50);
            this.txtDescr.TabIndex = 5;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnInsert.Location = new System.Drawing.Point(446, 37);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 40);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Καταχώρηση";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // FoldersInsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 182);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Name = "FoldersInsertForm";
            this.Text = "Δημιουργία Νέου Φακέλου";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescr;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Button btnInsert;
    }
}