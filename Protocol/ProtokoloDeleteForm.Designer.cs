namespace Protocol
{
    partial class ProtokoloDeleteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtokoloDeleteForm));
            this.lvRep = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFilters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvRep
            // 
            this.lvRep.AllowColumnReorder = true;
            this.lvRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.lvRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lvRep.FullRowSelect = true;
            this.lvRep.GridLines = true;
            this.lvRep.Location = new System.Drawing.Point(0, 74);
            this.lvRep.MultiSelect = false;
            this.lvRep.Name = "lvRep";
            this.lvRep.Size = new System.Drawing.Size(1272, 460);
            this.lvRep.TabIndex = 2;
            this.lvRep.UseCompatibleStateImageBehavior = false;
            this.lvRep.View = System.Windows.Forms.View.Details;
            this.lvRep.DoubleClick += new System.EventHandler(this.lvRep_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ΑΑ Πρωτοκόλλου";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Έτος";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Κατ.Πρωτοκόλλου";
            this.columnHeader3.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Εταιρία";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ημ/νία Έκδοσης";
            this.columnHeader5.Width = 92;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ημ.Λήψης/Αποστ.";
            this.columnHeader6.Width = 118;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Αρ.Εισερχ/Σχετικοί Αρ.";
            this.columnHeader7.Width = 117;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Προέλευση/Κατεύθυνση";
            this.columnHeader8.Width = 138;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Περίληψη";
            this.columnHeader9.Width = 90;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Παρ.για ενέργεια/Παρατηρήσεις";
            this.columnHeader10.Width = 181;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Αρ.Φακέλου Αρχείου";
            this.columnHeader11.Width = 117;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Id";
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Attachments";
            this.columnHeader13.Width = 58;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Emails";
            this.columnHeader14.Width = 54;
            // 
            // btnFilters
            // 
            this.btnFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnFilters.Image = global::Protocol.Properties.Resources.Filter_32x;
            this.btnFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilters.Location = new System.Drawing.Point(12, 15);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(135, 40);
            this.btnFilters.TabIndex = 9;
            this.btnFilters.Text = "Φίλτρα";
            this.btnFilters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilters.UseVisualStyleBackColor = true;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // ProtokoloDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 534);
            this.Controls.Add(this.btnFilters);
            this.Controls.Add(this.lvRep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1288, 572);
            this.Name = "ProtokoloDeleteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Διαγραφή";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvRep;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        public System.Windows.Forms.Button btnFilters;
    }
}