namespace Protocol
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParamsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FoldersTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderInsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderSelTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderUpdTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderDelTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderToProtokTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YMStatsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserInfoTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.InsertToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.SelectToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.UpdateToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMenuItem,
            this.ParamsTSMenuItem,
            this.StatisticsTSMenuItem,
            this.HelpTSMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileTSMenuItem
            // 
            this.FileTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertTSMenuItem,
            this.SelectTSMenuItem,
            this.UpdateTSMenuItem,
            this.DeleteTSMenuItem});
            this.FileTSMenuItem.Name = "FileTSMenuItem";
            this.FileTSMenuItem.Size = new System.Drawing.Size(55, 20);
            this.FileTSMenuItem.Text = "Αρχείο";
            // 
            // InsertTSMenuItem
            // 
            this.InsertTSMenuItem.Name = "InsertTSMenuItem";
            this.InsertTSMenuItem.Size = new System.Drawing.Size(152, 22);
            this.InsertTSMenuItem.Text = "Εισαγωγή";
            this.InsertTSMenuItem.Click += new System.EventHandler(this.InsertProtocol_Click);
            // 
            // SelectTSMenuItem
            // 
            this.SelectTSMenuItem.Name = "SelectTSMenuItem";
            this.SelectTSMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SelectTSMenuItem.Text = "Εμφάνιση";
            this.SelectTSMenuItem.Click += new System.EventHandler(this.SelectTSMenuItem_Click);
            // 
            // UpdateTSMenuItem
            // 
            this.UpdateTSMenuItem.Name = "UpdateTSMenuItem";
            this.UpdateTSMenuItem.Size = new System.Drawing.Size(152, 22);
            this.UpdateTSMenuItem.Text = "Μεταβολή";
            this.UpdateTSMenuItem.Visible = false;
            this.UpdateTSMenuItem.Click += new System.EventHandler(this.UpdateTSMenuItem_Click);
            // 
            // DeleteTSMenuItem
            // 
            this.DeleteTSMenuItem.Name = "DeleteTSMenuItem";
            this.DeleteTSMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteTSMenuItem.Text = "Διαγραφή";
            this.DeleteTSMenuItem.Click += new System.EventHandler(this.DeleteTSMenuItem_Click);
            // 
            // ParamsTSMenuItem
            // 
            this.ParamsTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FoldersTSMenuItem,
            this.ContactsTSMenuItem});
            this.ParamsTSMenuItem.Name = "ParamsTSMenuItem";
            this.ParamsTSMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ParamsTSMenuItem.Text = "Παράμετροι";
            // 
            // FoldersTSMenuItem
            // 
            this.FoldersTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FolderInsTSMenuItem,
            this.FolderSelTSMenuItem,
            this.FolderUpdTSMenuItem,
            this.FolderDelTSMenuItem,
            this.FolderToProtokTSMenuItem});
            this.FoldersTSMenuItem.Name = "FoldersTSMenuItem";
            this.FoldersTSMenuItem.Size = new System.Drawing.Size(176, 22);
            this.FoldersTSMenuItem.Text = "Φάκελοι";
            // 
            // FolderInsTSMenuItem
            // 
            this.FolderInsTSMenuItem.Name = "FolderInsTSMenuItem";
            this.FolderInsTSMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FolderInsTSMenuItem.Text = "Εισαγωγή";
            this.FolderInsTSMenuItem.Click += new System.EventHandler(this.FolderInsTSMenuItem_Click);
            // 
            // FolderSelTSMenuItem
            // 
            this.FolderSelTSMenuItem.Name = "FolderSelTSMenuItem";
            this.FolderSelTSMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FolderSelTSMenuItem.Text = "Εμφάνιση";
            this.FolderSelTSMenuItem.Click += new System.EventHandler(this.FolderSelTSMenuItem_Click);
            // 
            // FolderUpdTSMenuItem
            // 
            this.FolderUpdTSMenuItem.Name = "FolderUpdTSMenuItem";
            this.FolderUpdTSMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FolderUpdTSMenuItem.Text = "Μεταβολή";
            this.FolderUpdTSMenuItem.Click += new System.EventHandler(this.FolderUpdTSMenuItem_Click);
            // 
            // FolderDelTSMenuItem
            // 
            this.FolderDelTSMenuItem.Name = "FolderDelTSMenuItem";
            this.FolderDelTSMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FolderDelTSMenuItem.Text = "Διαγραφή";
            this.FolderDelTSMenuItem.Click += new System.EventHandler(this.FolderDelTSMenuItem_Click);
            // 
            // FolderToProtokTSMenuItem
            // 
            this.FolderToProtokTSMenuItem.Name = "FolderToProtokTSMenuItem";
            this.FolderToProtokTSMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FolderToProtokTSMenuItem.Text = "Πρωτόκολλα ανά Φάκελο";
            this.FolderToProtokTSMenuItem.Click += new System.EventHandler(this.FolderToProtokTSMenuItem_Click);
            // 
            // ContactsTSMenuItem
            // 
            this.ContactsTSMenuItem.Name = "ContactsTSMenuItem";
            this.ContactsTSMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ContactsTSMenuItem.Text = "Διευθυνσιογράφος";
            this.ContactsTSMenuItem.Visible = false;
            this.ContactsTSMenuItem.Click += new System.EventHandler(this.ContactsTSMenuItem_Click);
            // 
            // StatisticsTSMenuItem
            // 
            this.StatisticsTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YMStatsTSMenuItem});
            this.StatisticsTSMenuItem.Name = "StatisticsTSMenuItem";
            this.StatisticsTSMenuItem.Size = new System.Drawing.Size(76, 20);
            this.StatisticsTSMenuItem.Text = "Στατιστικά";
            // 
            // YMStatsTSMenuItem
            // 
            this.YMStatsTSMenuItem.Name = "YMStatsTSMenuItem";
            this.YMStatsTSMenuItem.Size = new System.Drawing.Size(159, 22);
            this.YMStatsTSMenuItem.Text = "Ετήσιο/Μηνιαίο";
            this.YMStatsTSMenuItem.Click += new System.EventHandler(this.YMStatsTSMenuItem_Click);
            // 
            // HelpTSMenuItem
            // 
            this.HelpTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserInfoTSMenuItem,
            this.ManualTSMenuItem,
            this.VersionTSMenuItem});
            this.HelpTSMenuItem.Name = "HelpTSMenuItem";
            this.HelpTSMenuItem.Size = new System.Drawing.Size(62, 20);
            this.HelpTSMenuItem.Text = "Βοήθεια";
            // 
            // UserInfoTSMenuItem
            // 
            this.UserInfoTSMenuItem.Name = "UserInfoTSMenuItem";
            this.UserInfoTSMenuItem.Size = new System.Drawing.Size(171, 22);
            this.UserInfoTSMenuItem.Text = "Στοιχεία Χρήστη";
            this.UserInfoTSMenuItem.Click += new System.EventHandler(this.UserInfoTSMenuItem_Click);
            // 
            // ManualTSMenuItem
            // 
            this.ManualTSMenuItem.Name = "ManualTSMenuItem";
            this.ManualTSMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ManualTSMenuItem.Text = "Εγχειρίδιο Χρήσης";
            this.ManualTSMenuItem.Click += new System.EventHandler(this.ManualTSMenuItem_Click);
            // 
            // VersionTSMenuItem
            // 
            this.VersionTSMenuItem.Name = "VersionTSMenuItem";
            this.VersionTSMenuItem.Size = new System.Drawing.Size(171, 22);
            this.VersionTSMenuItem.Text = "Έκδοση";
            this.VersionTSMenuItem.Click += new System.EventHandler(this.VersionTSMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLblUser
            // 
            this.tsStatusLblUser.Image = global::Protocol.Properties.Resources.User_16x;
            this.tsStatusLblUser.Name = "tsStatusLblUser";
            this.tsStatusLblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsStatusLblUser.Size = new System.Drawing.Size(103, 17);
            this.tsStatusLblUser.Text = "User: Unknown";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertToolStripBtn,
            this.SelectToolStripBtn,
            this.UpdateToolStripBtn,
            this.DeleteToolStripBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // InsertToolStripBtn
            // 
            this.InsertToolStripBtn.Image = global::Protocol.Properties.Resources.AccountGroup_16x;
            this.InsertToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertToolStripBtn.Name = "InsertToolStripBtn";
            this.InsertToolStripBtn.Size = new System.Drawing.Size(80, 22);
            this.InsertToolStripBtn.Text = "Εισαγωγή";
            this.InsertToolStripBtn.Click += new System.EventHandler(this.InsertProtocol_Click);
            // 
            // SelectToolStripBtn
            // 
            this.SelectToolStripBtn.Image = global::Protocol.Properties.Resources.FindResults_16x;
            this.SelectToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectToolStripBtn.Name = "SelectToolStripBtn";
            this.SelectToolStripBtn.Size = new System.Drawing.Size(79, 22);
            this.SelectToolStripBtn.Text = "Εμφάνιση";
            this.SelectToolStripBtn.Click += new System.EventHandler(this.SelectToolStripBtn_Click);
            // 
            // UpdateToolStripBtn
            // 
            this.UpdateToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpdateToolStripBtn.Image")));
            this.UpdateToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateToolStripBtn.Name = "UpdateToolStripBtn";
            this.UpdateToolStripBtn.Size = new System.Drawing.Size(83, 22);
            this.UpdateToolStripBtn.Text = "Μεταβολή";
            this.UpdateToolStripBtn.Visible = false;
            this.UpdateToolStripBtn.Click += new System.EventHandler(this.UpdateToolStripBtn_Click);
            // 
            // DeleteToolStripBtn
            // 
            this.DeleteToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripBtn.Image")));
            this.DeleteToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripBtn.Name = "DeleteToolStripBtn";
            this.DeleteToolStripBtn.Size = new System.Drawing.Size(81, 22);
            this.DeleteToolStripBtn.Text = "Διαγραφή";
            this.DeleteToolStripBtn.ToolTipText = "Διαγραφή";
            this.DeleteToolStripBtn.Visible = false;
            this.DeleteToolStripBtn.Click += new System.EventHandler(this.DeleteToolStripBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Protocol.Properties.Resources.RefNight760x470;
            this.pictureBox1.Location = new System.Drawing.Point(12, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 470);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Πρωτόκολλο";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateTSMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton InsertToolStripBtn;
        private System.Windows.Forms.ToolStripButton UpdateToolStripBtn;
        private System.Windows.Forms.ToolStripMenuItem DeleteTSMenuItem;
        private System.Windows.Forms.ToolStripButton DeleteToolStripBtn;
        private System.Windows.Forms.ToolStripMenuItem ParamsTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FoldersTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderInsTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderUpdTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderDelTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderToProtokTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserInfoTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectTSMenuItem;
        private System.Windows.Forms.ToolStripButton SelectToolStripBtn;
        private System.Windows.Forms.ToolStripMenuItem FolderSelTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VersionTSMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.ToolStripMenuItem ContactsTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatisticsTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YMStatsTSMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ManualTSMenuItem;
    }
}

