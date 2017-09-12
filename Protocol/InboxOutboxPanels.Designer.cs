namespace Protocol
{
    partial class InboxOutboxPanels
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
            this.panelInbox = new System.Windows.Forms.Panel();
            this.btnInOpenFile = new System.Windows.Forms.Button();
            this.btnInRemoveAll = new System.Windows.Forms.Button();
            this.btnInRemoveFile = new System.Windows.Forms.Button();
            this.btnInAddFiles = new System.Windows.Forms.Button();
            this.lvInAttachedFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNewFolders = new System.Windows.Forms.Button();
            this.cbInFolders = new System.Windows.Forms.ComboBox();
            this.dtpInDocDate = new System.Windows.Forms.DateTimePicker();
            this.dtpInGetDate = new System.Windows.Forms.DateTimePicker();
            this.tbInToText = new System.Windows.Forms.TextBox();
            this.tbInSummary = new System.Windows.Forms.TextBox();
            this.tbInProeleusi = new System.Windows.Forms.TextBox();
            this.tbInDocNum = new System.Windows.Forms.TextBox();
            this.tbInProtokoloNum = new System.Windows.Forms.TextBox();
            this.lblInToText = new System.Windows.Forms.Label();
            this.lblInSummary = new System.Windows.Forms.Label();
            this.lblInProeleusi = new System.Windows.Forms.Label();
            this.lblInFolderId = new System.Windows.Forms.Label();
            this.lblInDocDate = new System.Windows.Forms.Label();
            this.lblInDocNum = new System.Windows.Forms.Label();
            this.lblInGetDate = new System.Windows.Forms.Label();
            this.lblInProtokoloNum = new System.Windows.Forms.Label();
            this.lblInPanelTitle = new System.Windows.Forms.Label();
            this.panelOutbox = new System.Windows.Forms.Panel();
            this.btnOutOpenFile = new System.Windows.Forms.Button();
            this.btnOutRemoveAll = new System.Windows.Forms.Button();
            this.btnOutRemoveFile = new System.Windows.Forms.Button();
            this.btnOutAddFiles = new System.Windows.Forms.Button();
            this.lvOutAttachedFiles = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpOutSetDate = new System.Windows.Forms.DateTimePicker();
            this.tbOutSummary = new System.Windows.Forms.TextBox();
            this.tbOutKateuth = new System.Windows.Forms.TextBox();
            this.tbOutDocNum = new System.Windows.Forms.TextBox();
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
            // panelInbox
            // 
            this.panelInbox.Controls.Add(this.btnInOpenFile);
            this.panelInbox.Controls.Add(this.btnInRemoveAll);
            this.panelInbox.Controls.Add(this.btnInRemoveFile);
            this.panelInbox.Controls.Add(this.btnInAddFiles);
            this.panelInbox.Controls.Add(this.lvInAttachedFiles);
            this.panelInbox.Controls.Add(this.btnNewFolders);
            this.panelInbox.Controls.Add(this.cbInFolders);
            this.panelInbox.Controls.Add(this.dtpInDocDate);
            this.panelInbox.Controls.Add(this.dtpInGetDate);
            this.panelInbox.Controls.Add(this.tbInToText);
            this.panelInbox.Controls.Add(this.tbInSummary);
            this.panelInbox.Controls.Add(this.tbInProeleusi);
            this.panelInbox.Controls.Add(this.tbInDocNum);
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
            this.panelInbox.Location = new System.Drawing.Point(12, 12);
            this.panelInbox.Name = "panelInbox";
            this.panelInbox.Size = new System.Drawing.Size(560, 560);
            this.panelInbox.TabIndex = 3;
            // 
            // btnInOpenFile
            // 
            this.btnInOpenFile.Location = new System.Drawing.Point(183, 459);
            this.btnInOpenFile.Name = "btnInOpenFile";
            this.btnInOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnInOpenFile.TabIndex = 15;
            this.btnInOpenFile.Text = "Open File";
            this.btnInOpenFile.UseVisualStyleBackColor = true;
            this.btnInOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnInRemoveAll
            // 
            this.btnInRemoveAll.Location = new System.Drawing.Point(183, 517);
            this.btnInRemoveAll.Name = "btnInRemoveAll";
            this.btnInRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnInRemoveAll.TabIndex = 14;
            this.btnInRemoveAll.Text = "Remove All";
            this.btnInRemoveAll.UseVisualStyleBackColor = true;
            this.btnInRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnInRemoveFile
            // 
            this.btnInRemoveFile.Location = new System.Drawing.Point(183, 488);
            this.btnInRemoveFile.Name = "btnInRemoveFile";
            this.btnInRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnInRemoveFile.TabIndex = 13;
            this.btnInRemoveFile.Text = "Remove File";
            this.btnInRemoveFile.UseVisualStyleBackColor = true;
            this.btnInRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnInAddFiles
            // 
            this.btnInAddFiles.Location = new System.Drawing.Point(183, 430);
            this.btnInAddFiles.Name = "btnInAddFiles";
            this.btnInAddFiles.Size = new System.Drawing.Size(75, 23);
            this.btnInAddFiles.TabIndex = 12;
            this.btnInAddFiles.Text = "Add File(s)";
            this.btnInAddFiles.UseVisualStyleBackColor = true;
            this.btnInAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // lvInAttachedFiles
            // 
            this.lvInAttachedFiles.AllowDrop = true;
            this.lvInAttachedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvInAttachedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lvInAttachedFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInAttachedFiles.Location = new System.Drawing.Point(264, 420);
            this.lvInAttachedFiles.MultiSelect = false;
            this.lvInAttachedFiles.Name = "lvInAttachedFiles";
            this.lvInAttachedFiles.Size = new System.Drawing.Size(280, 120);
            this.lvInAttachedFiles.TabIndex = 11;
            this.lvInAttachedFiles.UseCompatibleStateImageBehavior = false;
            this.lvInAttachedFiles.View = System.Windows.Forms.View.Details;
            this.lvInAttachedFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvAttachedFiles_DragDrop);
            this.lvInAttachedFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvAttachedFiles_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Συνημμένα Αρχεία";
            this.columnHeader1.Width = 250;
            // 
            // btnNewFolders
            // 
            this.btnNewFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNewFolders.Location = new System.Drawing.Point(519, 184);
            this.btnNewFolders.Name = "btnNewFolders";
            this.btnNewFolders.Size = new System.Drawing.Size(25, 27);
            this.btnNewFolders.TabIndex = 6;
            this.btnNewFolders.Text = "*";
            this.btnNewFolders.UseVisualStyleBackColor = true;
            this.btnNewFolders.Click += new System.EventHandler(this.btnNewFolders_Click);
            // 
            // cbInFolders
            // 
            this.cbInFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbInFolders.FormattingEnabled = true;
            this.cbInFolders.Location = new System.Drawing.Point(264, 186);
            this.cbInFolders.Name = "cbInFolders";
            this.cbInFolders.Size = new System.Drawing.Size(251, 24);
            this.cbInFolders.TabIndex = 5;
            // 
            // dtpInDocDate
            // 
            this.dtpInDocDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpInDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpInDocDate.Location = new System.Drawing.Point(264, 148);
            this.dtpInDocDate.Name = "dtpInDocDate";
            this.dtpInDocDate.Size = new System.Drawing.Size(280, 23);
            this.dtpInDocDate.TabIndex = 10;
            // 
            // dtpInGetDate
            // 
            this.dtpInGetDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpInGetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpInGetDate.Location = new System.Drawing.Point(264, 78);
            this.dtpInGetDate.Name = "dtpInGetDate";
            this.dtpInGetDate.Size = new System.Drawing.Size(280, 23);
            this.dtpInGetDate.TabIndex = 9;
            // 
            // tbInToText
            // 
            this.tbInToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbInToText.Location = new System.Drawing.Point(264, 354);
            this.tbInToText.Multiline = true;
            this.tbInToText.Name = "tbInToText";
            this.tbInToText.Size = new System.Drawing.Size(280, 50);
            this.tbInToText.TabIndex = 9;
            // 
            // tbInSummary
            // 
            this.tbInSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbInSummary.Location = new System.Drawing.Point(264, 288);
            this.tbInSummary.Multiline = true;
            this.tbInSummary.Name = "tbInSummary";
            this.tbInSummary.Size = new System.Drawing.Size(280, 50);
            this.tbInSummary.TabIndex = 8;
            // 
            // tbInProeleusi
            // 
            this.tbInProeleusi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbInProeleusi.Location = new System.Drawing.Point(264, 222);
            this.tbInProeleusi.Multiline = true;
            this.tbInProeleusi.Name = "tbInProeleusi";
            this.tbInProeleusi.Size = new System.Drawing.Size(280, 50);
            this.tbInProeleusi.TabIndex = 7;
            // 
            // tbInDocNum
            // 
            this.tbInDocNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbInDocNum.Location = new System.Drawing.Point(264, 114);
            this.tbInDocNum.Name = "tbInDocNum";
            this.tbInDocNum.Size = new System.Drawing.Size(280, 23);
            this.tbInDocNum.TabIndex = 3;
            // 
            // tbInProtokoloNum
            // 
            this.tbInProtokoloNum.Enabled = false;
            this.tbInProtokoloNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbInProtokoloNum.Location = new System.Drawing.Point(264, 42);
            this.tbInProtokoloNum.Name = "tbInProtokoloNum";
            this.tbInProtokoloNum.Size = new System.Drawing.Size(280, 23);
            this.tbInProtokoloNum.TabIndex = 1;
            this.tbInProtokoloNum.Visible = false;
            // 
            // lblInToText
            // 
            this.lblInToText.AutoSize = true;
            this.lblInToText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInToText.Location = new System.Drawing.Point(8, 357);
            this.lblInToText.Name = "lblInToText";
            this.lblInToText.Size = new System.Drawing.Size(257, 17);
            this.lblInToText.TabIndex = 8;
            this.lblInToText.Text = "Παράδοση για ενέργεια / Παρατηρήσεις";
            // 
            // lblInSummary
            // 
            this.lblInSummary.AutoSize = true;
            this.lblInSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInSummary.Location = new System.Drawing.Point(8, 291);
            this.lblInSummary.Name = "lblInSummary";
            this.lblInSummary.Size = new System.Drawing.Size(68, 17);
            this.lblInSummary.TabIndex = 7;
            this.lblInSummary.Text = "Περίληψη";
            // 
            // lblInProeleusi
            // 
            this.lblInProeleusi.AutoSize = true;
            this.lblInProeleusi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInProeleusi.Location = new System.Drawing.Point(8, 225);
            this.lblInProeleusi.Name = "lblInProeleusi";
            this.lblInProeleusi.Size = new System.Drawing.Size(79, 17);
            this.lblInProeleusi.TabIndex = 6;
            this.lblInProeleusi.Text = "Προέλευση";
            // 
            // lblInFolderId
            // 
            this.lblInFolderId.AutoSize = true;
            this.lblInFolderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInFolderId.Location = new System.Drawing.Point(8, 189);
            this.lblInFolderId.Name = "lblInFolderId";
            this.lblInFolderId.Size = new System.Drawing.Size(173, 17);
            this.lblInFolderId.TabIndex = 5;
            this.lblInFolderId.Text = "Αριθμός Φακέλου Αρχείου";
            // 
            // lblInDocDate
            // 
            this.lblInDocDate.AutoSize = true;
            this.lblInDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInDocDate.Location = new System.Drawing.Point(8, 153);
            this.lblInDocDate.Name = "lblInDocDate";
            this.lblInDocDate.Size = new System.Drawing.Size(153, 17);
            this.lblInDocDate.TabIndex = 4;
            this.lblInDocDate.Text = "Ημερομηνία Έκδοδσης";
            // 
            // lblInDocNum
            // 
            this.lblInDocNum.AutoSize = true;
            this.lblInDocNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInDocNum.Location = new System.Drawing.Point(8, 117);
            this.lblInDocNum.Name = "lblInDocNum";
            this.lblInDocNum.Size = new System.Drawing.Size(219, 17);
            this.lblInDocNum.TabIndex = 3;
            this.lblInDocNum.Text = "Αριθμός Εισερχομένου Εγγράφου";
            // 
            // lblInGetDate
            // 
            this.lblInGetDate.AutoSize = true;
            this.lblInGetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInGetDate.Location = new System.Drawing.Point(8, 81);
            this.lblInGetDate.Name = "lblInGetDate";
            this.lblInGetDate.Size = new System.Drawing.Size(129, 17);
            this.lblInGetDate.TabIndex = 2;
            this.lblInGetDate.Text = "Ημερομηνία Λήψης";
            // 
            // lblInProtokoloNum
            // 
            this.lblInProtokoloNum.AutoSize = true;
            this.lblInProtokoloNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInProtokoloNum.Location = new System.Drawing.Point(8, 45);
            this.lblInProtokoloNum.Name = "lblInProtokoloNum";
            this.lblInProtokoloNum.Size = new System.Drawing.Size(195, 17);
            this.lblInProtokoloNum.TabIndex = 1;
            this.lblInProtokoloNum.Text = "Αύξων Αριθμός Πρωτοκόλλου";
            this.lblInProtokoloNum.Visible = false;
            // 
            // lblInPanelTitle
            // 
            this.lblInPanelTitle.AutoSize = true;
            this.lblInPanelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInPanelTitle.Location = new System.Drawing.Point(212, 9);
            this.lblInPanelTitle.Name = "lblInPanelTitle";
            this.lblInPanelTitle.Size = new System.Drawing.Size(136, 24);
            this.lblInPanelTitle.TabIndex = 0;
            this.lblInPanelTitle.Text = "Εισερχόμενα";
            // 
            // panelOutbox
            // 
            this.panelOutbox.Controls.Add(this.btnOutOpenFile);
            this.panelOutbox.Controls.Add(this.btnOutRemoveAll);
            this.panelOutbox.Controls.Add(this.btnOutRemoveFile);
            this.panelOutbox.Controls.Add(this.btnOutAddFiles);
            this.panelOutbox.Controls.Add(this.lvOutAttachedFiles);
            this.panelOutbox.Controls.Add(this.dtpOutSetDate);
            this.panelOutbox.Controls.Add(this.tbOutSummary);
            this.panelOutbox.Controls.Add(this.tbOutKateuth);
            this.panelOutbox.Controls.Add(this.tbOutDocNum);
            this.panelOutbox.Controls.Add(this.tbOutProtokoloNum);
            this.panelOutbox.Controls.Add(this.lblOutSummary);
            this.panelOutbox.Controls.Add(this.lblOutKateuth);
            this.panelOutbox.Controls.Add(this.lblOutDocNum);
            this.panelOutbox.Controls.Add(this.lblOutSetDate);
            this.panelOutbox.Controls.Add(this.lblOutProtokoloNum);
            this.panelOutbox.Controls.Add(this.lblOutPanelTitle);
            this.panelOutbox.Location = new System.Drawing.Point(578, 12);
            this.panelOutbox.Name = "panelOutbox";
            this.panelOutbox.Size = new System.Drawing.Size(560, 560);
            this.panelOutbox.TabIndex = 6;
            // 
            // btnOutOpenFile
            // 
            this.btnOutOpenFile.Location = new System.Drawing.Point(183, 321);
            this.btnOutOpenFile.Name = "btnOutOpenFile";
            this.btnOutOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOutOpenFile.TabIndex = 16;
            this.btnOutOpenFile.Text = "Open File";
            this.btnOutOpenFile.UseVisualStyleBackColor = true;
            this.btnOutOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnOutRemoveAll
            // 
            this.btnOutRemoveAll.Location = new System.Drawing.Point(183, 379);
            this.btnOutRemoveAll.Name = "btnOutRemoveAll";
            this.btnOutRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnOutRemoveAll.TabIndex = 15;
            this.btnOutRemoveAll.Text = "Remove All";
            this.btnOutRemoveAll.UseVisualStyleBackColor = true;
            this.btnOutRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnOutRemoveFile
            // 
            this.btnOutRemoveFile.Location = new System.Drawing.Point(183, 350);
            this.btnOutRemoveFile.Name = "btnOutRemoveFile";
            this.btnOutRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnOutRemoveFile.TabIndex = 14;
            this.btnOutRemoveFile.Text = "Remove File";
            this.btnOutRemoveFile.UseVisualStyleBackColor = true;
            this.btnOutRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnOutAddFiles
            // 
            this.btnOutAddFiles.Location = new System.Drawing.Point(183, 292);
            this.btnOutAddFiles.Name = "btnOutAddFiles";
            this.btnOutAddFiles.Size = new System.Drawing.Size(75, 23);
            this.btnOutAddFiles.TabIndex = 13;
            this.btnOutAddFiles.Text = "Add File(s)";
            this.btnOutAddFiles.UseVisualStyleBackColor = true;
            this.btnOutAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // lvOutAttachedFiles
            // 
            this.lvOutAttachedFiles.AllowDrop = true;
            this.lvOutAttachedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvOutAttachedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lvOutAttachedFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOutAttachedFiles.Location = new System.Drawing.Point(264, 282);
            this.lvOutAttachedFiles.MultiSelect = false;
            this.lvOutAttachedFiles.Name = "lvOutAttachedFiles";
            this.lvOutAttachedFiles.Size = new System.Drawing.Size(280, 120);
            this.lvOutAttachedFiles.TabIndex = 12;
            this.lvOutAttachedFiles.UseCompatibleStateImageBehavior = false;
            this.lvOutAttachedFiles.View = System.Windows.Forms.View.Details;
            this.lvOutAttachedFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvAttachedFiles_DragDrop);
            this.lvOutAttachedFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvAttachedFiles_DragEnter);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Συνημμένα Αρχεία";
            this.columnHeader2.Width = 250;
            // 
            // dtpOutSetDate
            // 
            this.dtpOutSetDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpOutSetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpOutSetDate.Location = new System.Drawing.Point(264, 78);
            this.dtpOutSetDate.Name = "dtpOutSetDate";
            this.dtpOutSetDate.Size = new System.Drawing.Size(280, 23);
            this.dtpOutSetDate.TabIndex = 10;
            // 
            // tbOutSummary
            // 
            this.tbOutSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbOutSummary.Location = new System.Drawing.Point(264, 216);
            this.tbOutSummary.Multiline = true;
            this.tbOutSummary.Name = "tbOutSummary";
            this.tbOutSummary.Size = new System.Drawing.Size(280, 50);
            this.tbOutSummary.TabIndex = 5;
            // 
            // tbOutKateuth
            // 
            this.tbOutKateuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbOutKateuth.Location = new System.Drawing.Point(264, 150);
            this.tbOutKateuth.Multiline = true;
            this.tbOutKateuth.Name = "tbOutKateuth";
            this.tbOutKateuth.Size = new System.Drawing.Size(280, 50);
            this.tbOutKateuth.TabIndex = 4;
            // 
            // tbOutDocNum
            // 
            this.tbOutDocNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbOutDocNum.Location = new System.Drawing.Point(264, 114);
            this.tbOutDocNum.Name = "tbOutDocNum";
            this.tbOutDocNum.Size = new System.Drawing.Size(280, 23);
            this.tbOutDocNum.TabIndex = 3;
            // 
            // tbOutProtokoloNum
            // 
            this.tbOutProtokoloNum.Enabled = false;
            this.tbOutProtokoloNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.tbOutProtokoloNum.Location = new System.Drawing.Point(264, 42);
            this.tbOutProtokoloNum.Name = "tbOutProtokoloNum";
            this.tbOutProtokoloNum.Size = new System.Drawing.Size(280, 23);
            this.tbOutProtokoloNum.TabIndex = 1;
            this.tbOutProtokoloNum.Visible = false;
            // 
            // lblOutSummary
            // 
            this.lblOutSummary.AutoSize = true;
            this.lblOutSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOutSummary.Location = new System.Drawing.Point(8, 219);
            this.lblOutSummary.Name = "lblOutSummary";
            this.lblOutSummary.Size = new System.Drawing.Size(68, 17);
            this.lblOutSummary.TabIndex = 7;
            this.lblOutSummary.Text = "Περίληψη";
            // 
            // lblOutKateuth
            // 
            this.lblOutKateuth.AutoSize = true;
            this.lblOutKateuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOutKateuth.Location = new System.Drawing.Point(8, 153);
            this.lblOutKateuth.Name = "lblOutKateuth";
            this.lblOutKateuth.Size = new System.Drawing.Size(86, 17);
            this.lblOutKateuth.TabIndex = 6;
            this.lblOutKateuth.Text = "Κατεύθυνση";
            // 
            // lblOutDocNum
            // 
            this.lblOutDocNum.AutoSize = true;
            this.lblOutDocNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOutDocNum.Location = new System.Drawing.Point(8, 117);
            this.lblOutDocNum.Name = "lblOutDocNum";
            this.lblOutDocNum.Size = new System.Drawing.Size(109, 17);
            this.lblOutDocNum.TabIndex = 3;
            this.lblOutDocNum.Text = "Σχετικοί Αριθμοί";
            // 
            // lblOutSetDate
            // 
            this.lblOutSetDate.AutoSize = true;
            this.lblOutSetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOutSetDate.Location = new System.Drawing.Point(8, 81);
            this.lblOutSetDate.Name = "lblOutSetDate";
            this.lblOutSetDate.Size = new System.Drawing.Size(158, 17);
            this.lblOutSetDate.TabIndex = 2;
            this.lblOutSetDate.Text = "Ημερομηνία Αποστολής";
            // 
            // lblOutProtokoloNum
            // 
            this.lblOutProtokoloNum.AutoSize = true;
            this.lblOutProtokoloNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOutProtokoloNum.Location = new System.Drawing.Point(8, 45);
            this.lblOutProtokoloNum.Name = "lblOutProtokoloNum";
            this.lblOutProtokoloNum.Size = new System.Drawing.Size(195, 17);
            this.lblOutProtokoloNum.TabIndex = 1;
            this.lblOutProtokoloNum.Text = "Αύξων Αριθμός Πρωτοκόλλου";
            this.lblOutProtokoloNum.Visible = false;
            // 
            // lblOutPanelTitle
            // 
            this.lblOutPanelTitle.AutoSize = true;
            this.lblOutPanelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOutPanelTitle.Location = new System.Drawing.Point(215, 9);
            this.lblOutPanelTitle.Name = "lblOutPanelTitle";
            this.lblOutPanelTitle.Size = new System.Drawing.Size(129, 24);
            this.lblOutPanelTitle.TabIndex = 0;
            this.lblOutPanelTitle.Text = "Εξερχόμενα";
            // 
            // InboxOutboxPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 600);
            this.Controls.Add(this.panelOutbox);
            this.Controls.Add(this.panelInbox);
            this.Name = "InboxOutboxPanels";
            this.Text = "InboxOutboxPanels";
            this.panelInbox.ResumeLayout(false);
            this.panelInbox.PerformLayout();
            this.panelOutbox.ResumeLayout(false);
            this.panelOutbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelInbox;
        private System.Windows.Forms.Label lblInToText;
        private System.Windows.Forms.Label lblInSummary;
        private System.Windows.Forms.Label lblInProeleusi;
        private System.Windows.Forms.Label lblInFolderId;
        private System.Windows.Forms.Label lblInDocDate;
        private System.Windows.Forms.Label lblInDocNum;
        private System.Windows.Forms.Label lblInGetDate;
        private System.Windows.Forms.Label lblInProtokoloNum;
        private System.Windows.Forms.Label lblInPanelTitle;
        private System.Windows.Forms.Label lblOutSummary;
        private System.Windows.Forms.Label lblOutKateuth;
        private System.Windows.Forms.Label lblOutDocNum;
        private System.Windows.Forms.Label lblOutSetDate;
        private System.Windows.Forms.Label lblOutProtokoloNum;
        private System.Windows.Forms.Label lblOutPanelTitle;
        public System.Windows.Forms.Panel panelOutbox;
        public System.Windows.Forms.TextBox tbInToText;
        public System.Windows.Forms.TextBox tbInSummary;
        public System.Windows.Forms.TextBox tbInProeleusi;
        public System.Windows.Forms.TextBox tbInDocNum;
        public System.Windows.Forms.TextBox tbInProtokoloNum;
        public System.Windows.Forms.TextBox tbOutSummary;
        public System.Windows.Forms.TextBox tbOutKateuth;
        public System.Windows.Forms.TextBox tbOutDocNum;
        public System.Windows.Forms.TextBox tbOutProtokoloNum;
        public System.Windows.Forms.DateTimePicker dtpInGetDate;
        public System.Windows.Forms.DateTimePicker dtpOutSetDate;
        public System.Windows.Forms.DateTimePicker dtpInDocDate;
        public System.Windows.Forms.ComboBox cbInFolders;
        public System.Windows.Forms.Button btnNewFolders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnInAddFiles;
        private System.Windows.Forms.Button btnOutAddFiles;
        private System.Windows.Forms.Button btnInOpenFile;
        private System.Windows.Forms.Button btnInRemoveAll;
        private System.Windows.Forms.Button btnInRemoveFile;
        private System.Windows.Forms.Button btnOutOpenFile;
        private System.Windows.Forms.Button btnOutRemoveAll;
        private System.Windows.Forms.Button btnOutRemoveFile;
        public System.Windows.Forms.ListView lvInAttachedFiles;
        public System.Windows.Forms.ListView lvOutAttachedFiles;
    }
}