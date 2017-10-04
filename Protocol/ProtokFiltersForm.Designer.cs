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
            this.pbFolder = new System.Windows.Forms.PictureBox();
            this.btnSaveFilters = new System.Windows.Forms.Button();
            this.chbDeleted = new System.Windows.Forms.CheckBox();
            this.dtpGetSetDate_From = new System.Windows.Forms.DateTimePicker();
            this.dtpGetSetDate_To = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pbFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGetSetDate
            // 
            this.lblGetSetDate.AutoSize = true;
            this.lblGetSetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGetSetDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGetSetDate.Location = new System.Drawing.Point(89, 127);
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
            this.lblName.Location = new System.Drawing.Point(98, 156);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(111, 17);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Όνομα Φακέλου";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtName.Location = new System.Drawing.Point(215, 153);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 23);
            this.txtName.TabIndex = 4;
            // 
            // pbFolder
            // 
            this.pbFolder.Image = global::Protocol.Properties.Resources.EditFilter_32x;
            this.pbFolder.Location = new System.Drawing.Point(24, 141);
            this.pbFolder.Name = "pbFolder";
            this.pbFolder.Size = new System.Drawing.Size(32, 32);
            this.pbFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFolder.TabIndex = 24;
            this.pbFolder.TabStop = false;
            // 
            // btnSaveFilters
            // 
            this.btnSaveFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSaveFilters.Image = global::Protocol.Properties.Resources.Save_32x;
            this.btnSaveFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFilters.Location = new System.Drawing.Point(258, 274);
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
            this.chbDeleted.Location = new System.Drawing.Point(58, 66);
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
            this.dtpGetSetDate_From.Location = new System.Drawing.Point(215, 122);
            this.dtpGetSetDate_From.Name = "dtpGetSetDate_From";
            this.dtpGetSetDate_From.Size = new System.Drawing.Size(280, 23);
            this.dtpGetSetDate_From.TabIndex = 26;
            // 
            // dtpGetSetDate_To
            // 
            this.dtpGetSetDate_To.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpGetSetDate_To.Location = new System.Drawing.Point(501, 122);
            this.dtpGetSetDate_To.Name = "dtpGetSetDate_To";
            this.dtpGetSetDate_To.Size = new System.Drawing.Size(280, 23);
            this.dtpGetSetDate_To.TabIndex = 27;
            // 
            // ProtokFiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.dtpGetSetDate_To);
            this.Controls.Add(this.dtpGetSetDate_From);
            this.Controls.Add(this.chbDeleted);
            this.Controls.Add(this.pbFolder);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGetSetDate;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Button btnSaveFilters;
        private System.Windows.Forms.PictureBox pbFolder;
        public System.Windows.Forms.CheckBox chbDeleted;
        public System.Windows.Forms.DateTimePicker dtpGetSetDate_From;
        public System.Windows.Forms.DateTimePicker dtpGetSetDate_To;
    }
}