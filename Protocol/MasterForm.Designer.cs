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
            this.UpdateTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.InsertToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.UpdateToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileTSMenuItem
            // 
            this.FileTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertTSMenuItem,
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
            this.InsertTSMenuItem.Click += new System.EventHandler(this.InsertTSMenuItem_Click);
            // 
            // UpdateTSMenuItem
            // 
            this.UpdateTSMenuItem.Name = "UpdateTSMenuItem";
            this.UpdateTSMenuItem.Size = new System.Drawing.Size(152, 22);
            this.UpdateTSMenuItem.Text = "Μεταβολή";
            this.UpdateTSMenuItem.Click += new System.EventHandler(this.UpdateTSMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 240);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabel1.Text = "© MOH IT - 2017";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertToolStripBtn,
            this.UpdateToolStripBtn,
            this.DeleteToolStripBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // InsertToolStripBtn
            // 
            this.InsertToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("InsertToolStripBtn.Image")));
            this.InsertToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertToolStripBtn.Name = "InsertToolStripBtn";
            this.InsertToolStripBtn.Size = new System.Drawing.Size(80, 22);
            this.InsertToolStripBtn.Text = "Εισαγωγή";
            this.InsertToolStripBtn.Click += new System.EventHandler(this.InsertToolStripBtn_Click);
            // 
            // UpdateToolStripBtn
            // 
            this.UpdateToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpdateToolStripBtn.Image")));
            this.UpdateToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateToolStripBtn.Name = "UpdateToolStripBtn";
            this.UpdateToolStripBtn.Size = new System.Drawing.Size(83, 22);
            this.UpdateToolStripBtn.Text = "Μεταβολή";
            this.UpdateToolStripBtn.Click += new System.EventHandler(this.UpdateToolStripBtn_Click);
            // 
            // DeleteTSMenuItem
            // 
            this.DeleteTSMenuItem.Name = "DeleteTSMenuItem";
            this.DeleteTSMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteTSMenuItem.Text = "Διαγραφή";
            this.DeleteTSMenuItem.Click += new System.EventHandler(this.DeleteTSMenuItem_Click);
            // 
            // DeleteToolStripBtn
            // 
            this.DeleteToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripBtn.Image")));
            this.DeleteToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripBtn.Name = "DeleteToolStripBtn";
            this.DeleteToolStripBtn.Size = new System.Drawing.Size(81, 22);
            this.DeleteToolStripBtn.Text = "Διαγραφή";
            this.DeleteToolStripBtn.ToolTipText = "Διαγραφή";
            this.DeleteToolStripBtn.Click += new System.EventHandler(this.DeleteToolStripBtn_Click);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Πρωτόκολλο";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateTSMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton InsertToolStripBtn;
        private System.Windows.Forms.ToolStripButton UpdateToolStripBtn;
        private System.Windows.Forms.ToolStripMenuItem DeleteTSMenuItem;
        private System.Windows.Forms.ToolStripButton DeleteToolStripBtn;
    }
}

