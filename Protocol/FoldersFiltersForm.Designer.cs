namespace Protocol
{
    partial class FoldersFiltersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoldersFiltersForm));
            this.btnSaveFilters = new System.Windows.Forms.Button();
            this.chlbProced = new System.Windows.Forms.CheckedListBox();
            this.lblProced = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.chlbCompany = new System.Windows.Forms.CheckedListBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.lblDescr = new System.Windows.Forms.Label();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.chbHasProtocols = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSaveFilters
            // 
            this.btnSaveFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSaveFilters.Image = global::Protocol.Properties.Resources.EditFilter_32x;
            this.btnSaveFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFilters.Location = new System.Drawing.Point(250, 434);
            this.btnSaveFilters.Name = "btnSaveFilters";
            this.btnSaveFilters.Size = new System.Drawing.Size(135, 40);
            this.btnSaveFilters.TabIndex = 6;
            this.btnSaveFilters.Text = "Εφαρμογή";
            this.btnSaveFilters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveFilters.UseVisualStyleBackColor = true;
            this.btnSaveFilters.Click += new System.EventHandler(this.btnSaveFilters_Click);
            // 
            // chlbProced
            // 
            this.chlbProced.CheckOnClick = true;
            this.chlbProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbProced.FormattingEnabled = true;
            this.chlbProced.Location = new System.Drawing.Point(199, 203);
            this.chlbProced.Name = "chlbProced";
            this.chlbProced.Size = new System.Drawing.Size(131, 89);
            this.chlbProced.TabIndex = 28;
            // 
            // lblProced
            // 
            this.lblProced.AutoSize = true;
            this.lblProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProced.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProced.Location = new System.Drawing.Point(51, 201);
            this.lblProced.Name = "lblProced";
            this.lblProced.Size = new System.Drawing.Size(142, 17);
            this.lblProced.TabIndex = 29;
            this.lblProced.Text = "Κατηγ. Πρωτοκόλλου";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCompany.Location = new System.Drawing.Point(132, 87);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(61, 17);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Εταιρεία";
            // 
            // chlbCompany
            // 
            this.chlbCompany.CheckOnClick = true;
            this.chlbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbCompany.FormattingEnabled = true;
            this.chlbCompany.Location = new System.Drawing.Point(199, 87);
            this.chlbCompany.Name = "chlbCompany";
            this.chlbCompany.Size = new System.Drawing.Size(280, 89);
            this.chlbCompany.TabIndex = 31;
            // 
            // txtDescr
            // 
            this.txtDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescr.Location = new System.Drawing.Point(199, 319);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(280, 23);
            this.txtDescr.TabIndex = 37;
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescr.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDescr.Location = new System.Drawing.Point(117, 322);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(76, 17);
            this.lblDescr.TabIndex = 38;
            this.lblDescr.Text = "Περιγραφή";
            // 
            // txtFolderName
            // 
            this.txtFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFolderName.Location = new System.Drawing.Point(199, 37);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(280, 23);
            this.txtFolderName.TabIndex = 45;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFolderName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFolderName.Location = new System.Drawing.Point(51, 40);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(142, 17);
            this.lblFolderName.TabIndex = 46;
            this.lblFolderName.Text = "Αρ. Φακέλου Αρχείου";
            // 
            // chbHasProtocols
            // 
            this.chbHasProtocols.AutoSize = true;
            this.chbHasProtocols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbHasProtocols.ForeColor = System.Drawing.Color.DarkBlue;
            this.chbHasProtocols.Location = new System.Drawing.Point(53, 369);
            this.chbHasProtocols.Name = "chbHasProtocols";
            this.chbHasProtocols.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbHasProtocols.Size = new System.Drawing.Size(160, 20);
            this.chbHasProtocols.TabIndex = 47;
            this.chbHasProtocols.Text = "Περιέχει Πρωτόκολλα";
            this.chbHasProtocols.UseVisualStyleBackColor = true;
            // 
            // FoldersFiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 512);
            this.Controls.Add(this.chbHasProtocols);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.chlbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblProced);
            this.Controls.Add(this.chlbProced);
            this.Controls.Add(this.btnSaveFilters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(650, 550);
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "FoldersFiltersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Φίλτρα";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnSaveFilters;
        private System.Windows.Forms.Label lblProced;
        public System.Windows.Forms.CheckedListBox chlbProced;
        private System.Windows.Forms.Label lblCompany;
        public System.Windows.Forms.CheckedListBox chlbCompany;
        public System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label lblDescr;
        public System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblFolderName;
        public System.Windows.Forms.CheckBox chbHasProtocols;
    }
}