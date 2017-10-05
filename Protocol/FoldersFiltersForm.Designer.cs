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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtokFiltersForm));
            this.lblGetSetDate = new System.Windows.Forms.Label();
            this.btnSaveFilters = new System.Windows.Forms.Button();
            this.chbDeleted = new System.Windows.Forms.CheckBox();
            this.dtpGetSetDate_From = new System.Windows.Forms.DateTimePicker();
            this.dtpGetSetDate_To = new System.Windows.Forms.DateTimePicker();
            this.chlbProced = new System.Windows.Forms.CheckedListBox();
            this.lblProced = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.chlbCompany = new System.Windows.Forms.CheckedListBox();
            this.dtp_DocDate_To = new System.Windows.Forms.DateTimePicker();
            this.dtp_DocDate_From = new System.Windows.Forms.DateTimePicker();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.txtProelKateuth = new System.Windows.Forms.TextBox();
            this.lblProelKateuth = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.lblDocNum = new System.Windows.Forms.Label();
            this.txtToText = new System.Windows.Forms.TextBox();
            this.lblToText = new System.Windows.Forms.Label();
            this.chlbFolder = new System.Windows.Forms.CheckedListBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtSn = new System.Windows.Forms.TextBox();
            this.lblSn = new System.Windows.Forms.Label();
            this.chbHasAtt = new System.Windows.Forms.CheckBox();
            this.chbMailSent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblGetSetDate
            // 
            this.lblGetSetDate.AutoSize = true;
            this.lblGetSetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGetSetDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGetSetDate.Location = new System.Drawing.Point(59, 41);
            this.lblGetSetDate.Name = "lblGetSetDate";
            this.lblGetSetDate.Size = new System.Drawing.Size(120, 17);
            this.lblGetSetDate.TabIndex = 0;
            this.lblGetSetDate.Text = "Ημ.Λήψης/Αποστ.";
            // 
            // btnSaveFilters
            // 
            this.btnSaveFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSaveFilters.Image = global::Protocol.Properties.Resources.EditFilter_32x;
            this.btnSaveFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFilters.Location = new System.Drawing.Point(325, 484);
            this.btnSaveFilters.Name = "btnSaveFilters";
            this.btnSaveFilters.Size = new System.Drawing.Size(135, 40);
            this.btnSaveFilters.TabIndex = 6;
            this.btnSaveFilters.Text = "Εφαρμογή";
            this.btnSaveFilters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveFilters.UseVisualStyleBackColor = true;
            this.btnSaveFilters.Click += new System.EventHandler(this.btnSaveFilters_Click);
            // 
            // chbDeleted
            // 
            this.chbDeleted.AutoSize = true;
            this.chbDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbDeleted.ForeColor = System.Drawing.Color.DarkBlue;
            this.chbDeleted.Location = new System.Drawing.Point(28, 12);
            this.chbDeleted.Name = "chbDeleted";
            this.chbDeleted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbDeleted.Size = new System.Drawing.Size(171, 20);
            this.chbDeleted.TabIndex = 25;
            this.chbDeleted.Text = "Εμφάνιση Διαγραμμένων";
            this.chbDeleted.UseVisualStyleBackColor = true;
            this.chbDeleted.Visible = false;
            // 
            // dtpGetSetDate_From
            // 
            this.dtpGetSetDate_From.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_From.Location = new System.Drawing.Point(185, 36);
            this.dtpGetSetDate_From.Name = "dtpGetSetDate_From";
            this.dtpGetSetDate_From.Size = new System.Drawing.Size(280, 23);
            this.dtpGetSetDate_From.TabIndex = 26;
            // 
            // dtpGetSetDate_To
            // 
            this.dtpGetSetDate_To.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_To.Location = new System.Drawing.Point(471, 36);
            this.dtpGetSetDate_To.Name = "dtpGetSetDate_To";
            this.dtpGetSetDate_To.Size = new System.Drawing.Size(280, 23);
            this.dtpGetSetDate_To.TabIndex = 27;
            // 
            // chlbProced
            // 
            this.chlbProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbProced.FormattingEnabled = true;
            this.chlbProced.Location = new System.Drawing.Point(471, 94);
            this.chlbProced.Name = "chlbProced";
            this.chlbProced.Size = new System.Drawing.Size(131, 55);
            this.chlbProced.TabIndex = 28;
            // 
            // lblProced
            // 
            this.lblProced.AutoSize = true;
            this.lblProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProced.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProced.Location = new System.Drawing.Point(323, 94);
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
            this.lblCompany.Location = new System.Drawing.Point(118, 94);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(61, 17);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Εταιρεία";
            // 
            // chlbCompany
            // 
            this.chlbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbCompany.FormattingEnabled = true;
            this.chlbCompany.Location = new System.Drawing.Point(185, 94);
            this.chlbCompany.Name = "chlbCompany";
            this.chlbCompany.Size = new System.Drawing.Size(131, 55);
            this.chlbCompany.TabIndex = 31;
            // 
            // dtp_DocDate_To
            // 
            this.dtp_DocDate_To.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtp_DocDate_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtp_DocDate_To.Location = new System.Drawing.Point(471, 65);
            this.dtp_DocDate_To.Name = "dtp_DocDate_To";
            this.dtp_DocDate_To.Size = new System.Drawing.Size(280, 23);
            this.dtp_DocDate_To.TabIndex = 34;
            // 
            // dtp_DocDate_From
            // 
            this.dtp_DocDate_From.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtp_DocDate_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtp_DocDate_From.Location = new System.Drawing.Point(185, 65);
            this.dtp_DocDate_From.Name = "dtp_DocDate_From";
            this.dtp_DocDate_From.Size = new System.Drawing.Size(280, 23);
            this.dtp_DocDate_From.TabIndex = 33;
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDocDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDocDate.Location = new System.Drawing.Point(91, 65);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(88, 17);
            this.lblDocDate.TabIndex = 32;
            this.lblDocDate.Text = "Ημ.Έκδοσης";
            // 
            // txtProelKateuth
            // 
            this.txtProelKateuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtProelKateuth.Location = new System.Drawing.Point(185, 155);
            this.txtProelKateuth.Name = "txtProelKateuth";
            this.txtProelKateuth.Size = new System.Drawing.Size(280, 23);
            this.txtProelKateuth.TabIndex = 35;
            // 
            // lblProelKateuth
            // 
            this.lblProelKateuth.AutoSize = true;
            this.lblProelKateuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProelKateuth.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProelKateuth.Location = new System.Drawing.Point(18, 158);
            this.lblProelKateuth.Name = "lblProelKateuth";
            this.lblProelKateuth.Size = new System.Drawing.Size(161, 17);
            this.lblProelKateuth.TabIndex = 36;
            this.lblProelKateuth.Text = "Προέλευση/Κατεύθυνση";
            // 
            // txtSummary
            // 
            this.txtSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSummary.Location = new System.Drawing.Point(185, 184);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(280, 23);
            this.txtSummary.TabIndex = 37;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSummary.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSummary.Location = new System.Drawing.Point(111, 187);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(68, 17);
            this.lblSummary.TabIndex = 38;
            this.lblSummary.Text = "Περίληψη";
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDocNum.Location = new System.Drawing.Point(185, 213);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.Size = new System.Drawing.Size(280, 23);
            this.txtDocNum.TabIndex = 39;
            // 
            // lblDocNum
            // 
            this.lblDocNum.AutoSize = true;
            this.lblDocNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDocNum.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDocNum.Location = new System.Drawing.Point(16, 216);
            this.lblDocNum.Name = "lblDocNum";
            this.lblDocNum.Size = new System.Drawing.Size(163, 17);
            this.lblDocNum.TabIndex = 40;
            this.lblDocNum.Text = "Αρ.Εισερχ./Σχετ.Αριθμός";
            // 
            // txtToText
            // 
            this.txtToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtToText.Location = new System.Drawing.Point(185, 242);
            this.txtToText.Name = "txtToText";
            this.txtToText.Size = new System.Drawing.Size(280, 23);
            this.txtToText.TabIndex = 41;
            // 
            // lblToText
            // 
            this.lblToText.AutoSize = true;
            this.lblToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblToText.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblToText.Location = new System.Drawing.Point(0, 245);
            this.lblToText.Name = "lblToText";
            this.lblToText.Size = new System.Drawing.Size(179, 17);
            this.lblToText.TabIndex = 42;
            this.lblToText.Text = "Παρ.για ενέργεια/Παρατηρ.";
            // 
            // chlbFolder
            // 
            this.chlbFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbFolder.FormattingEnabled = true;
            this.chlbFolder.Location = new System.Drawing.Point(185, 271);
            this.chlbFolder.Name = "chlbFolder";
            this.chlbFolder.Size = new System.Drawing.Size(417, 106);
            this.chlbFolder.TabIndex = 44;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFolder.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFolder.Location = new System.Drawing.Point(41, 271);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(138, 17);
            this.lblFolder.TabIndex = 43;
            this.lblFolder.Text = "Αρ.Φακέλου Αρχείου";
            // 
            // txtSn
            // 
            this.txtSn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSn.Location = new System.Drawing.Point(185, 383);
            this.txtSn.Name = "txtSn";
            this.txtSn.Size = new System.Drawing.Size(280, 23);
            this.txtSn.TabIndex = 45;
            this.txtSn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSn_KeyPress);
            // 
            // lblSn
            // 
            this.lblSn.AutoSize = true;
            this.lblSn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSn.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSn.Location = new System.Drawing.Point(66, 386);
            this.lblSn.Name = "lblSn";
            this.lblSn.Size = new System.Drawing.Size(113, 17);
            this.lblSn.TabIndex = 46;
            this.lblSn.Text = "Αρ. Πρωτοκόλου";
            // 
            // chbHasAtt
            // 
            this.chbHasAtt.AutoSize = true;
            this.chbHasAtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbHasAtt.ForeColor = System.Drawing.Color.DarkBlue;
            this.chbHasAtt.Location = new System.Drawing.Point(78, 412);
            this.chbHasAtt.Name = "chbHasAtt";
            this.chbHasAtt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbHasAtt.Size = new System.Drawing.Size(121, 20);
            this.chbHasAtt.TabIndex = 47;
            this.chbHasAtt.Text = "Με Attachments";
            this.chbHasAtt.UseVisualStyleBackColor = true;
            // 
            // chbMailSent
            // 
            this.chbMailSent.AutoSize = true;
            this.chbMailSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbMailSent.ForeColor = System.Drawing.Color.DarkBlue;
            this.chbMailSent.Location = new System.Drawing.Point(43, 438);
            this.chbMailSent.Name = "chbMailSent";
            this.chbMailSent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbMailSent.Size = new System.Drawing.Size(156, 20);
            this.chbMailSent.TabIndex = 48;
            this.chbMailSent.Text = "Έχει αποσταλεί Email";
            this.chbMailSent.UseVisualStyleBackColor = true;
            // 
            // ProtokFiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.chbMailSent);
            this.Controls.Add(this.chbHasAtt);
            this.Controls.Add(this.lblSn);
            this.Controls.Add(this.txtSn);
            this.Controls.Add(this.chlbFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.txtToText);
            this.Controls.Add(this.lblToText);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.lblDocNum);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.txtProelKateuth);
            this.Controls.Add(this.lblProelKateuth);
            this.Controls.Add(this.dtp_DocDate_To);
            this.Controls.Add(this.dtp_DocDate_From);
            this.Controls.Add(this.lblDocDate);
            this.Controls.Add(this.chlbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblProced);
            this.Controls.Add(this.chlbProced);
            this.Controls.Add(this.dtpGetSetDate_To);
            this.Controls.Add(this.dtpGetSetDate_From);
            this.Controls.Add(this.chbDeleted);
            this.Controls.Add(this.btnSaveFilters);
            this.Controls.Add(this.lblGetSetDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ProtokFiltersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Φίλτρα";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGetSetDate;
        public System.Windows.Forms.Button btnSaveFilters;
        public System.Windows.Forms.CheckBox chbDeleted;
        public System.Windows.Forms.DateTimePicker dtpGetSetDate_From;
        public System.Windows.Forms.DateTimePicker dtpGetSetDate_To;
        private System.Windows.Forms.Label lblProced;
        public System.Windows.Forms.CheckedListBox chlbProced;
        private System.Windows.Forms.Label lblCompany;
        public System.Windows.Forms.CheckedListBox chlbCompany;
        public System.Windows.Forms.DateTimePicker dtp_DocDate_To;
        public System.Windows.Forms.DateTimePicker dtp_DocDate_From;
        private System.Windows.Forms.Label lblDocDate;
        public System.Windows.Forms.TextBox txtProelKateuth;
        private System.Windows.Forms.Label lblProelKateuth;
        public System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label lblSummary;
        public System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.Label lblDocNum;
        public System.Windows.Forms.TextBox txtToText;
        private System.Windows.Forms.Label lblToText;
        public System.Windows.Forms.CheckedListBox chlbFolder;
        private System.Windows.Forms.Label lblFolder;
        public System.Windows.Forms.TextBox txtSn;
        private System.Windows.Forms.Label lblSn;
        public System.Windows.Forms.CheckBox chbHasAtt;
        public System.Windows.Forms.CheckBox chbMailSent;
    }
}