namespace Protocol
{
    partial class ProtokFiltersForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSaveFilters = new System.Windows.Forms.Button();
            this.chbDeleted = new System.Windows.Forms.CheckBox();
            this.dtpGetSetDate_From = new System.Windows.Forms.DateTimePicker();
            this.dtpGetSetDate_To = new System.Windows.Forms.DateTimePicker();
            this.chlbProced = new System.Windows.Forms.CheckedListBox();
            this.lblProced = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.chlbCompany = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblGetSetDate
            // 
            this.lblGetSetDate.AutoSize = true;
            this.lblGetSetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGetSetDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGetSetDate.Location = new System.Drawing.Point(59, 65);
            this.lblGetSetDate.Name = "lblGetSetDate";
            this.lblGetSetDate.Size = new System.Drawing.Size(120, 17);
            this.lblGetSetDate.TabIndex = 0;
            this.lblGetSetDate.Text = "Ημ.Λήψης/Αποστ.";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblName.Location = new System.Drawing.Point(375, 330);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(111, 17);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Όνομα Φακέλου";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtName.Location = new System.Drawing.Point(492, 327);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 23);
            this.txtName.TabIndex = 4;
            // 
            // btnSaveFilters
            // 
            this.btnSaveFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSaveFilters.Image = global::Protocol.Properties.Resources.EditFilter_32x;
            this.btnSaveFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFilters.Location = new System.Drawing.Point(325, 274);
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
            this.chbDeleted.Location = new System.Drawing.Point(28, 36);
            this.chbDeleted.Name = "chbDeleted";
            this.chbDeleted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbDeleted.Size = new System.Drawing.Size(171, 20);
            this.chbDeleted.TabIndex = 25;
            this.chbDeleted.Text = "Εμφάνιση Διαγραμμένων";
            this.chbDeleted.UseVisualStyleBackColor = true;
            // 
            // dtpGetSetDate_From
            // 
            this.dtpGetSetDate_From.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_From.Location = new System.Drawing.Point(185, 60);
            this.dtpGetSetDate_From.Name = "dtpGetSetDate_From";
            this.dtpGetSetDate_From.Size = new System.Drawing.Size(280, 23);
            this.dtpGetSetDate_From.TabIndex = 26;
            // 
            // dtpGetSetDate_To
            // 
            this.dtpGetSetDate_To.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_To.Location = new System.Drawing.Point(471, 60);
            this.dtpGetSetDate_To.Name = "dtpGetSetDate_To";
            this.dtpGetSetDate_To.Size = new System.Drawing.Size(280, 23);
            this.dtpGetSetDate_To.TabIndex = 27;
            // 
            // chlbProced
            // 
            this.chlbProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbProced.FormattingEnabled = true;
            this.chlbProced.Location = new System.Drawing.Point(185, 89);
            this.chlbProced.Name = "chlbProced";
            this.chlbProced.Size = new System.Drawing.Size(131, 55);
            this.chlbProced.TabIndex = 28;
            // 
            // lblProced
            // 
            this.lblProced.AutoSize = true;
            this.lblProced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProced.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProced.Location = new System.Drawing.Point(37, 89);
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
            this.lblCompany.Location = new System.Drawing.Point(118, 152);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(61, 17);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Εταιρεία";
            // 
            // chlbCompany
            // 
            this.chlbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chlbCompany.FormattingEnabled = true;
            this.chlbCompany.Location = new System.Drawing.Point(185, 152);
            this.chlbCompany.Name = "chlbCompany";
            this.chlbCompany.Size = new System.Drawing.Size(131, 55);
            this.chlbCompany.TabIndex = 31;
            // 
            // ProtokFiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.chlbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblProced);
            this.Controls.Add(this.chlbProced);
            this.Controls.Add(this.dtpGetSetDate_To);
            this.Controls.Add(this.dtpGetSetDate_From);
            this.Controls.Add(this.chbDeleted);
            this.Controls.Add(this.btnSaveFilters);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGetSetDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "ProtokFiltersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Φίλτρα";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGetSetDate;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Button btnSaveFilters;
        public System.Windows.Forms.CheckBox chbDeleted;
        public System.Windows.Forms.DateTimePicker dtpGetSetDate_From;
        public System.Windows.Forms.DateTimePicker dtpGetSetDate_To;
        private System.Windows.Forms.Label lblProced;
        public System.Windows.Forms.CheckedListBox chlbProced;
        private System.Windows.Forms.Label lblCompany;
        public System.Windows.Forms.CheckedListBox chlbCompany;
    }
}