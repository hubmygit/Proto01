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
            this.panelInbox = new System.Windows.Forms.Panel();
            this.lblInPanelTitle = new System.Windows.Forms.Label();
            this.lblInProtokoloNum = new System.Windows.Forms.Label();
            this.lblInGetDate = new System.Windows.Forms.Label();
            this.lblInDocNum = new System.Windows.Forms.Label();
            this.lblInDocDate = new System.Windows.Forms.Label();
            this.lblInFolderId = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.lblInProeleusi = new System.Windows.Forms.Label();
            this.lblInSummary = new System.Windows.Forms.Label();
            this.lblInToText = new System.Windows.Forms.Label();
            this.tbInProtokoloNum = new System.Windows.Forms.TextBox();
            this.tbInGetDate = new System.Windows.Forms.TextBox();
            this.tbInDocNum = new System.Windows.Forms.TextBox();
            this.tbInDocDate = new System.Windows.Forms.TextBox();
            this.tbInFolderId = new System.Windows.Forms.TextBox();
            this.tbInProeleusi = new System.Windows.Forms.TextBox();
            this.tbInSummary = new System.Windows.Forms.TextBox();
            this.tbInToText = new System.Windows.Forms.TextBox();
            this.panelOutbox = new System.Windows.Forms.Panel();
            this.tbOutSummary = new System.Windows.Forms.TextBox();
            this.tbOutKateuth = new System.Windows.Forms.TextBox();
            this.tbOutDocNum = new System.Windows.Forms.TextBox();
            this.tbOutSetDate = new System.Windows.Forms.TextBox();
            this.tbOutProtokoloNum = new System.Windows.Forms.TextBox();
            this.lblOutSummary = new System.Windows.Forms.Label();
            this.lblOutKateuth = new System.Windows.Forms.Label();
            this.lblOutDocNum = new System.Windows.Forms.Label();
            this.lblOutSetDate = new System.Windows.Forms.Label();
            this.lblOutProtokoloNum = new System.Windows.Forms.Label();
            this.lblOutPanelTitle = new System.Windows.Forms.Label();
            this.panelInbox.SuspendLayout();
            this.panelOutbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProtokoloKind
            // 
            this.lblProtokoloKind.AutoSize = true;
            this.lblProtokoloKind.Location = new System.Drawing.Point(128, 65);
            this.lblProtokoloKind.Name = "lblProtokoloKind";
            this.lblProtokoloKind.Size = new System.Drawing.Size(129, 13);
            this.lblProtokoloKind.TabIndex = 0;
            this.lblProtokoloKind.Text = "Κατηγορία Πρωτοκόλλου";
            // 
            // cbProtokoloKind
            // 
            this.cbProtokoloKind.FormattingEnabled = true;
            this.cbProtokoloKind.Location = new System.Drawing.Point(263, 62);
            this.cbProtokoloKind.Name = "cbProtokoloKind";
            this.cbProtokoloKind.Size = new System.Drawing.Size(130, 21);
            this.cbProtokoloKind.TabIndex = 1;
            this.cbProtokoloKind.SelectedIndexChanged += new System.EventHandler(this.cbProtokoloKind_SelectedIndexChanged);
            // 
            // panelInbox
            // 
            this.panelInbox.Controls.Add(this.tbInToText);
            this.panelInbox.Controls.Add(this.tbInSummary);
            this.panelInbox.Controls.Add(this.tbInProeleusi);
            this.panelInbox.Controls.Add(this.tbInFolderId);
            this.panelInbox.Controls.Add(this.tbInDocDate);
            this.panelInbox.Controls.Add(this.tbInDocNum);
            this.panelInbox.Controls.Add(this.tbInGetDate);
            this.panelInbox.Controls.Add(this.tbInProtokoloNum);
            this.panelInbox.Controls.Add(this.lblInToText);
            this.panelInbox.Controls.Add(this.lblInSummary);
            this.panelInbox.Controls.Add(this.lblInProeleusi);
            this.panelInbox.Controls.Add(this.lblInFolderId);
            this.panelInbox.Controls.Add(this.lblInDocDate);
            this.panelInbox.Controls.Add(this.lblInDocNum);
            this.panelInbox.Controls.Add(this.lblInGetDate);
            this.panelInbox.Controls.Add(this.lblInProtokoloNum);
            this.panelInbox.Controls.Add(this.lblInPanelTitle);
            this.panelInbox.Location = new System.Drawing.Point(12, 110);
            this.panelInbox.Name = "panelInbox";
            this.panelInbox.Size = new System.Drawing.Size(560, 440);
            this.panelInbox.TabIndex = 2;
            this.panelInbox.Visible = false;
            this.panelInbox.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInbox_Paint);
            // 
            // lblInPanelTitle
            // 
            this.lblInPanelTitle.AutoSize = true;
            this.lblInPanelTitle.Location = new System.Drawing.Point(246, 9);
            this.lblInPanelTitle.Name = "lblInPanelTitle";
            this.lblInPanelTitle.Size = new System.Drawing.Size(72, 13);
            this.lblInPanelTitle.TabIndex = 0;
            this.lblInPanelTitle.Text = "Εισερχόμενα";
            // 
            // lblInProtokoloNum
            // 
            this.lblInProtokoloNum.AutoSize = true;
            this.lblInProtokoloNum.Location = new System.Drawing.Point(13, 45);
            this.lblInProtokoloNum.Name = "lblInProtokoloNum";
            this.lblInProtokoloNum.Size = new System.Drawing.Size(151, 13);
            this.lblInProtokoloNum.TabIndex = 1;
            this.lblInProtokoloNum.Text = "Αύξων Αριθμός Πρωτοκόλλου";
            // 
            // lblInGetDate
            // 
            this.lblInGetDate.AutoSize = true;
            this.lblInGetDate.Location = new System.Drawing.Point(13, 81);
            this.lblInGetDate.Name = "lblInGetDate";
            this.lblInGetDate.Size = new System.Drawing.Size(102, 13);
            this.lblInGetDate.TabIndex = 2;
            this.lblInGetDate.Text = "Ημερομηνία Λήψης";
            // 
            // lblInDocNum
            // 
            this.lblInDocNum.AutoSize = true;
            this.lblInDocNum.Location = new System.Drawing.Point(13, 117);
            this.lblInDocNum.Name = "lblInDocNum";
            this.lblInDocNum.Size = new System.Drawing.Size(174, 13);
            this.lblInDocNum.TabIndex = 3;
            this.lblInDocNum.Text = "Αριθμός Εισερχομένου Εγγράφου";
            // 
            // lblInDocDate
            // 
            this.lblInDocDate.AutoSize = true;
            this.lblInDocDate.Location = new System.Drawing.Point(13, 153);
            this.lblInDocDate.Name = "lblInDocDate";
            this.lblInDocDate.Size = new System.Drawing.Size(119, 13);
            this.lblInDocDate.TabIndex = 4;
            this.lblInDocDate.Text = "Ημερομηνία Έκδοδσης";
            // 
            // lblInFolderId
            // 
            this.lblInFolderId.AutoSize = true;
            this.lblInFolderId.Location = new System.Drawing.Point(13, 189);
            this.lblInFolderId.Name = "lblInFolderId";
            this.lblInFolderId.Size = new System.Drawing.Size(138, 13);
            this.lblInFolderId.TabIndex = 5;
            this.lblInFolderId.Text = "Αριθμός Φακέλου Αρχείου";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(128, 30);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(45, 13);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Εταιρία";
            // 
            // cbCompany
            // 
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(263, 27);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(130, 21);
            this.cbCompany.TabIndex = 4;
            // 
            // lblInProeleusi
            // 
            this.lblInProeleusi.AutoSize = true;
            this.lblInProeleusi.Location = new System.Drawing.Point(13, 225);
            this.lblInProeleusi.Name = "lblInProeleusi";
            this.lblInProeleusi.Size = new System.Drawing.Size(62, 13);
            this.lblInProeleusi.TabIndex = 6;
            this.lblInProeleusi.Text = "Προέλευση";
            // 
            // lblInSummary
            // 
            this.lblInSummary.AutoSize = true;
            this.lblInSummary.Location = new System.Drawing.Point(13, 291);
            this.lblInSummary.Name = "lblInSummary";
            this.lblInSummary.Size = new System.Drawing.Size(54, 13);
            this.lblInSummary.TabIndex = 7;
            this.lblInSummary.Text = "Περίληψη";
            // 
            // lblInToText
            // 
            this.lblInToText.AutoSize = true;
            this.lblInToText.Location = new System.Drawing.Point(13, 357);
            this.lblInToText.Name = "lblInToText";
            this.lblInToText.Size = new System.Drawing.Size(211, 13);
            this.lblInToText.TabIndex = 8;
            this.lblInToText.Text = "Παράδοση για ενέργεια / Παρατηρήσεις";
            // 
            // tbInProtokoloNum
            // 
            this.tbInProtokoloNum.Location = new System.Drawing.Point(249, 42);
            this.tbInProtokoloNum.Name = "tbInProtokoloNum";
            this.tbInProtokoloNum.Size = new System.Drawing.Size(280, 20);
            this.tbInProtokoloNum.TabIndex = 9;
            // 
            // tbInGetDate
            // 
            this.tbInGetDate.Location = new System.Drawing.Point(249, 78);
            this.tbInGetDate.Name = "tbInGetDate";
            this.tbInGetDate.Size = new System.Drawing.Size(280, 20);
            this.tbInGetDate.TabIndex = 10;
            // 
            // tbInDocNum
            // 
            this.tbInDocNum.Location = new System.Drawing.Point(249, 114);
            this.tbInDocNum.Name = "tbInDocNum";
            this.tbInDocNum.Size = new System.Drawing.Size(280, 20);
            this.tbInDocNum.TabIndex = 11;
            // 
            // tbInDocDate
            // 
            this.tbInDocDate.Location = new System.Drawing.Point(249, 150);
            this.tbInDocDate.Name = "tbInDocDate";
            this.tbInDocDate.Size = new System.Drawing.Size(280, 20);
            this.tbInDocDate.TabIndex = 12;
            // 
            // tbInFolderId
            // 
            this.tbInFolderId.Location = new System.Drawing.Point(249, 186);
            this.tbInFolderId.Name = "tbInFolderId";
            this.tbInFolderId.Size = new System.Drawing.Size(280, 20);
            this.tbInFolderId.TabIndex = 13;
            // 
            // tbInProeleusi
            // 
            this.tbInProeleusi.Location = new System.Drawing.Point(249, 222);
            this.tbInProeleusi.Multiline = true;
            this.tbInProeleusi.Name = "tbInProeleusi";
            this.tbInProeleusi.Size = new System.Drawing.Size(280, 50);
            this.tbInProeleusi.TabIndex = 14;
            // 
            // tbInSummary
            // 
            this.tbInSummary.Location = new System.Drawing.Point(249, 288);
            this.tbInSummary.Multiline = true;
            this.tbInSummary.Name = "tbInSummary";
            this.tbInSummary.Size = new System.Drawing.Size(280, 50);
            this.tbInSummary.TabIndex = 15;
            // 
            // tbInToText
            // 
            this.tbInToText.Location = new System.Drawing.Point(249, 354);
            this.tbInToText.Multiline = true;
            this.tbInToText.Name = "tbInToText";
            this.tbInToText.Size = new System.Drawing.Size(280, 50);
            this.tbInToText.TabIndex = 16;
            // 
            // panelOutbox
            // 
            this.panelOutbox.Controls.Add(this.tbOutSummary);
            this.panelOutbox.Controls.Add(this.tbOutKateuth);
            this.panelOutbox.Controls.Add(this.tbOutDocNum);
            this.panelOutbox.Controls.Add(this.tbOutSetDate);
            this.panelOutbox.Controls.Add(this.tbOutProtokoloNum);
            this.panelOutbox.Controls.Add(this.lblOutSummary);
            this.panelOutbox.Controls.Add(this.lblOutKateuth);
            this.panelOutbox.Controls.Add(this.lblOutDocNum);
            this.panelOutbox.Controls.Add(this.lblOutSetDate);
            this.panelOutbox.Controls.Add(this.lblOutProtokoloNum);
            this.panelOutbox.Controls.Add(this.lblOutPanelTitle);
            this.panelOutbox.Location = new System.Drawing.Point(578, 110);
            this.panelOutbox.Name = "panelOutbox";
            this.panelOutbox.Size = new System.Drawing.Size(560, 440);
            this.panelOutbox.TabIndex = 5;
            this.panelOutbox.Visible = false;
            // 
            // tbOutSummary
            // 
            this.tbOutSummary.Location = new System.Drawing.Point(249, 216);
            this.tbOutSummary.Multiline = true;
            this.tbOutSummary.Name = "tbOutSummary";
            this.tbOutSummary.Size = new System.Drawing.Size(280, 50);
            this.tbOutSummary.TabIndex = 15;
            // 
            // tbOutKateuth
            // 
            this.tbOutKateuth.Location = new System.Drawing.Point(249, 150);
            this.tbOutKateuth.Multiline = true;
            this.tbOutKateuth.Name = "tbOutKateuth";
            this.tbOutKateuth.Size = new System.Drawing.Size(280, 50);
            this.tbOutKateuth.TabIndex = 14;
            // 
            // tbOutDocNum
            // 
            this.tbOutDocNum.Location = new System.Drawing.Point(249, 114);
            this.tbOutDocNum.Name = "tbOutDocNum";
            this.tbOutDocNum.Size = new System.Drawing.Size(280, 20);
            this.tbOutDocNum.TabIndex = 11;
            // 
            // tbOutSetDate
            // 
            this.tbOutSetDate.Location = new System.Drawing.Point(249, 78);
            this.tbOutSetDate.Name = "tbOutSetDate";
            this.tbOutSetDate.Size = new System.Drawing.Size(280, 20);
            this.tbOutSetDate.TabIndex = 10;
            // 
            // tbOutProtokoloNum
            // 
            this.tbOutProtokoloNum.Location = new System.Drawing.Point(249, 42);
            this.tbOutProtokoloNum.Name = "tbOutProtokoloNum";
            this.tbOutProtokoloNum.Size = new System.Drawing.Size(280, 20);
            this.tbOutProtokoloNum.TabIndex = 9;
            // 
            // lblOutSummary
            // 
            this.lblOutSummary.AutoSize = true;
            this.lblOutSummary.Location = new System.Drawing.Point(13, 219);
            this.lblOutSummary.Name = "lblOutSummary";
            this.lblOutSummary.Size = new System.Drawing.Size(54, 13);
            this.lblOutSummary.TabIndex = 7;
            this.lblOutSummary.Text = "Περίληψη";
            // 
            // lblOutKateuth
            // 
            this.lblOutKateuth.AutoSize = true;
            this.lblOutKateuth.Location = new System.Drawing.Point(13, 153);
            this.lblOutKateuth.Name = "lblOutKateuth";
            this.lblOutKateuth.Size = new System.Drawing.Size(69, 13);
            this.lblOutKateuth.TabIndex = 6;
            this.lblOutKateuth.Text = "Κατεύθυνση";
            // 
            // lblOutDocNum
            // 
            this.lblOutDocNum.AutoSize = true;
            this.lblOutDocNum.Location = new System.Drawing.Point(13, 117);
            this.lblOutDocNum.Name = "lblOutDocNum";
            this.lblOutDocNum.Size = new System.Drawing.Size(89, 13);
            this.lblOutDocNum.TabIndex = 3;
            this.lblOutDocNum.Text = "Σχετικοί Αριθμοί";
            // 
            // lblOutSetDate
            // 
            this.lblOutSetDate.AutoSize = true;
            this.lblOutSetDate.Location = new System.Drawing.Point(13, 81);
            this.lblOutSetDate.Name = "lblOutSetDate";
            this.lblOutSetDate.Size = new System.Drawing.Size(124, 13);
            this.lblOutSetDate.TabIndex = 2;
            this.lblOutSetDate.Text = "Ημερομηνία Αποστολής";
            // 
            // lblOutProtokoloNum
            // 
            this.lblOutProtokoloNum.AutoSize = true;
            this.lblOutProtokoloNum.Location = new System.Drawing.Point(13, 45);
            this.lblOutProtokoloNum.Name = "lblOutProtokoloNum";
            this.lblOutProtokoloNum.Size = new System.Drawing.Size(151, 13);
            this.lblOutProtokoloNum.TabIndex = 1;
            this.lblOutProtokoloNum.Text = "Αύξων Αριθμός Πρωτοκόλλου";
            // 
            // lblOutPanelTitle
            // 
            this.lblOutPanelTitle.AutoSize = true;
            this.lblOutPanelTitle.Location = new System.Drawing.Point(246, 9);
            this.lblOutPanelTitle.Name = "lblOutPanelTitle";
            this.lblOutPanelTitle.Size = new System.Drawing.Size(67, 13);
            this.lblOutPanelTitle.TabIndex = 0;
            this.lblOutPanelTitle.Text = "Εξερχόμενα";
            // 
            // ProtokoloInsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 561);
            this.Controls.Add(this.panelOutbox);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.panelInbox);
            this.Controls.Add(this.cbProtokoloKind);
            this.Controls.Add(this.lblProtokoloKind);
            this.Name = "ProtokoloInsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εισαγωγή";
            this.panelInbox.ResumeLayout(false);
            this.panelInbox.PerformLayout();
            this.panelOutbox.ResumeLayout(false);
            this.panelOutbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProtokoloKind;
        private System.Windows.Forms.ComboBox cbProtokoloKind;
        private System.Windows.Forms.Panel panelInbox;
        private System.Windows.Forms.Label lblInPanelTitle;
        private System.Windows.Forms.Label lblInFolderId;
        private System.Windows.Forms.Label lblInDocDate;
        private System.Windows.Forms.Label lblInDocNum;
        private System.Windows.Forms.Label lblInGetDate;
        private System.Windows.Forms.Label lblInProtokoloNum;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label lblInToText;
        private System.Windows.Forms.Label lblInSummary;
        private System.Windows.Forms.Label lblInProeleusi;
        private System.Windows.Forms.TextBox tbInToText;
        private System.Windows.Forms.TextBox tbInSummary;
        private System.Windows.Forms.TextBox tbInProeleusi;
        private System.Windows.Forms.TextBox tbInFolderId;
        private System.Windows.Forms.TextBox tbInDocDate;
        private System.Windows.Forms.TextBox tbInDocNum;
        private System.Windows.Forms.TextBox tbInGetDate;
        private System.Windows.Forms.TextBox tbInProtokoloNum;
        private System.Windows.Forms.Panel panelOutbox;
        private System.Windows.Forms.TextBox tbOutSummary;
        private System.Windows.Forms.TextBox tbOutKateuth;
        private System.Windows.Forms.TextBox tbOutDocNum;
        private System.Windows.Forms.TextBox tbOutSetDate;
        private System.Windows.Forms.TextBox tbOutProtokoloNum;
        private System.Windows.Forms.Label lblOutSummary;
        private System.Windows.Forms.Label lblOutKateuth;
        private System.Windows.Forms.Label lblOutDocNum;
        private System.Windows.Forms.Label lblOutSetDate;
        private System.Windows.Forms.Label lblOutProtokoloNum;
        private System.Windows.Forms.Label lblOutPanelTitle;
    }
}