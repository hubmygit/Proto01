using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

namespace Protocol
{
    public partial class ProtokoloUpdateForm : Form
    {
        public ProtokoloUpdateForm()
        {
            InitializeComponent();
            
            ShowDataToListView(lvRep);            
        }

        public void ShowDataToListView(ListView lvReport)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT P.Sn, P.Year, PR.Name as ProcedName, C.Name as CompanyName, convert(varchar, P.DocumentDate, 104) as _DocumentDate, " +
                                     "convert(varchar, P.DocumentGetSetDate, 104) as _DocumentGetSetDate, P.DocumentNumber, P.ProeleusiKateuth, P.Summary, P.ToText, F.Name, P.Id, " +
                                     "(select count(*) from [dbo].[ProtokPdf] PA where PA.ProtokId = P.id) as Att, " +
                                     "(select count(*) from [dbo].[ReceiverList] RL where RL.ProtokId = P.id) as Mails " +
                              "FROM [dbo].[Protok] P left outer join [dbo].[Proced] PR on PR.id = P.ProcedureId " +
                              "left outer join [dbo].[Company] C on C.id = P.CompanyId " +
                              "left outer join [dbo].[Folders] F on F.id = P.FolderId " + //and F.CompanyId = P.CompanyId and F.ProcedId = P.ProcedureId " +
                              //"WHERE month(P.DocumentGetSetDate) = month(getdate()) and isnull(P.deleted, 0) = 0 ";
                              "WHERE year(P.DocumentGetSetDate) = year(getdate()) and isnull(P.deleted, 0) = 0 and isnull(P.updated, 0) = 0 " +

                              " and C.id in (" + UserInfo.CompaniesAsCsvString + ") " +

                              "ORDER BY C.Name, P.Year, PR.Name, P.Sn ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = { reader[11].ToString(), //id
                                     reader[3].ToString(), //com
                                     reader[1].ToString(), //year
                                     reader[2].ToString(), //kat. prwt - proced
                                     reader[0].ToString(), //Sn
                                     reader[5].ToString(), //hm. lipsis - DocGetSetDate
                                     reader[4].ToString(), //hm. ekdosis - docdate
                                     reader[6].ToString(), //docNum
                                     reader[7].ToString(), //proeleusi
                                     reader[8].ToString(), //perilipsi
                                     reader[9].ToString(), //paratiriseis
                                     reader[10].ToString(), //folder
                                     reader[12].ToString(), //att
                                     reader[13].ToString()}; //mails

                    ListViewItem listViewItem = new ListViewItem(row);
                    lvReport.Items.Add(listViewItem);
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = reader;

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            
        }

        public void ShowDataToListView(ListView lvReport, string selectStatement_where_part)
        {
            lvReport.Items.Clear();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT P.Sn, P.Year, PR.Name as ProcedName, C.Name as CompanyName, convert(varchar, P.DocumentDate, 104) as _DocumentDate, " +
                                     "convert(varchar, P.DocumentGetSetDate, 104) as _DocumentGetSetDate, P.DocumentNumber, P.ProeleusiKateuth, P.Summary, P.ToText, F.Name, P.Id, " +
                                     "(select count(*) from [dbo].[ProtokPdf] PA where PA.ProtokId = P.id) as Att, " +
                                     "(select count(*) from [dbo].[ReceiverList] RL where RL.ProtokId = P.id) as Mails " +
                              "FROM [dbo].[Protok] P left outer join [dbo].[Proced] PR on PR.id = P.ProcedureId " +
                              "left outer join [dbo].[Company] C on C.id = P.CompanyId " +
                              "left outer join [dbo].[Folders] F on F.id = P.FolderId " + //and F.CompanyId = P.CompanyId and F.ProcedId = P.ProcedureId " +
                              selectStatement_where_part +

                              " and C.id in (" + UserInfo.CompaniesAsCsvString + ") " +

                              "ORDER BY C.Name, P.Year, PR.Name, P.Sn ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = { reader[11].ToString(), //id
                                     reader[3].ToString(), //com
                                     reader[1].ToString(), //year
                                     reader[2].ToString(), //kat. prwt - proced
                                     reader[0].ToString(), //Sn
                                     reader[5].ToString(), //hm. lipsis - DocGetSetDate
                                     reader[4].ToString(), //hm. ekdosis - docdate
                                     reader[6].ToString(), //docNum
                                     reader[7].ToString(), //proeleusi
                                     reader[8].ToString(), //perilipsi
                                     reader[9].ToString(), //paratiriseis
                                     reader[10].ToString(), //folder
                                     reader[12].ToString(), //att
                                     reader[13].ToString()}; //mails

                    ListViewItem listViewItem = new ListViewItem(row);
                    lvReport.Items.Add(listViewItem);
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = reader;

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }


        }


        public string[] getSavedAttachments(int ProtokId)
        {
            List<string> ret = new List<string>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT pdftext FROM [dbo].[ProtokPdf] WHERE ProtokId = " + ProtokId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ret.Add(reader["pdftext"].ToString().Trim());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret.ToArray();
        }

        List<string> saveAttachmentsLocally(int Id)
        {
            List<string> ret = new List<string>(); 
            string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
            try
            {
                if (!Directory.Exists(tempPath))
                {
                    MessageBox.Show("Σφάλμα. Παρακαλώ ελέγξτε τα δικαιώματά σας στο " + tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }
            
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT [PdfText], [FileCont] FROM [dbo].[ProtokPdf] WHERE ProtokId = @ProtokId";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@ProtokId", Id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + reader["PdfText"]);
                    File.WriteAllBytes(tempFile, (byte[])reader["FileCont"]);

                    //ret.Add(reader["PdfText"]);
                    ret.Add(tempFile);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            return ret;
        }

        void addTmpFilesIntoListView(ListView myListView, List<string> fileNames)
        {
            foreach (string thisFile in fileNames)
            {
                System.IO.FileInfo newFile = new System.IO.FileInfo(thisFile);

                foreach (ListViewItem lvi in myListView.Items)
                {
                    if (lvi.SubItems[0].Text.ToUpper() == newFile.Name.ToUpper())
                    {
                        break;
                    }
                }

                ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName });
                myListView.Items.Add(lvItem);
            }
        }

        private void lvRep_DoubleClick(object sender, EventArgs e)
        {
            ProtokoloInsertForm updScreen = new ProtokoloInsertForm();

            updScreen.btnInsert.Click -= new System.EventHandler(updScreen.btnInsert_Click);
            updScreen.btnInsert.Click += new System.EventHandler(updScreen.btnUpdate_Click);

            ListViewItem.ListViewSubItemCollection lvic = new ListViewItem.ListViewSubItemCollection(lvRep.SelectedItems[0]);

            string proced = lvic[3].Text;
            string company = lvic[1].Text;
            
            updScreen.Text = "Μεταβολή";
            updScreen.btnInsert.Text = "Μεταβολή";
            //updScreen.btnInsert.Enabled = false;
            //updScreen.btnCancel.Enabled = false;

            updScreen.cbProtokoloKind.SelectedIndex = updScreen.cbProtokoloKind.FindStringExact(proced);
            updScreen.cbCompany.SelectedIndex = updScreen.cbCompany.FindStringExact(company);

            updScreen.Protok_Id_For_Updates = Convert.ToInt32(lvic[0].Text);
                      
            if (Convert.ToInt32(lvic[13].Text) > 0)
            {
                updScreen.chbSendMail.Checked = true;
                //updScreen.btnShowRecipients.Enabled = true;
            }
            //updScreen.chbSendMail.AutoCheck = false;

            if (proced == "Εισερχόμενα")
            {
                ((DateTimePicker)updScreen.Controls["panelInbox"].Controls["dtpInGetDate"]).Value = DateTime.Parse(lvic[5].Text);
                updScreen.Controls["panelInbox"].Controls["tbInDocNum"].Text = lvic[7].Text;
                ((DateTimePicker)updScreen.Controls["panelInbox"].Controls["dtpInDocDate"]).Value = DateTime.Parse(lvic[6].Text);
                ((ComboBox)updScreen.Controls["panelInbox"].Controls["cbInFolders"]).SelectedIndex = ((ComboBox)updScreen.Controls["panelInbox"].Controls["cbInFolders"]).FindStringExact(lvic[11].Text);
                updScreen.Controls["panelInbox"].Controls["tbInProeleusi"].Text = lvic[8].Text;
                updScreen.Controls["panelInbox"].Controls["tbInSummary"].Text = lvic[9].Text;
                updScreen.Controls["panelInbox"].Controls["tbInToText"].Text = lvic[10].Text;

                updScreen.Controls["panelInbox"].Controls["lblInProtokolo"].Visible = true;
                updScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Visible = true;
                updScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Text = lvic[4].Text;
                updScreen.Controls["panelInbox"].Controls["tbInYear"].Visible = true;
                updScreen.Controls["panelInbox"].Controls["tbInYear"].Text = lvic[2].Text;

                //updScreen.Controls["panelInbox"].Controls["btnInAddFiles"].Enabled = false;
                //updScreen.Controls["panelInbox"].Controls["btnInRemoveFile"].Enabled = false;
                //updScreen.Controls["panelInbox"].Controls["btnInRemoveAll"].Enabled = false;
                
                //get 'Attachments' from ProtokPdf and extract files to Temp
                List<string> AttFilesPath = saveAttachmentsLocally(Convert.ToInt32(lvic[0].Text));
                //add files to listView
                addTmpFilesIntoListView(((ListView)updScreen.Controls["panelInbox"].Controls["lvInAttachedFiles"]), AttFilesPath);

                //updScreen.Controls["panelInbox"].Controls["dtpInGetDate"].Enabled = false;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInDocNum"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInDocNum"]).BackColor = Color.White;
                //updScreen.Controls["panelInbox"].Controls["dtpInDocDate"].Enabled = false;
                //updScreen.Controls["panelInbox"].Controls["cbInFolders"].Enabled = false;
                //updScreen.Controls["panelInbox"].Controls["btnInNewFolders"].Enabled = false;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInProeleusi"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInProeleusi"]).BackColor = Color.White;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInSummary"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInSummary"]).BackColor = Color.White;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInToText"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInToText"]).BackColor = Color.White;
                //updScreen.Controls["panelInbox"].Controls["lvInAttachedFiles"].AllowDrop = false;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"]).BackColor = Color.White;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInYear"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelInbox"].Controls["tbInYear"]).BackColor = Color.White;
            }
            else if (proced == "Εξερχόμενα")
            {
                ((DateTimePicker)updScreen.Controls["panelOutbox"].Controls["dtpOutSetDate"]).Value = DateTime.Parse(lvic[5].Text);
                ((ComboBox)updScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).SelectedIndex = ((ComboBox)updScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).FindStringExact(lvic[11].Text);
                updScreen.Controls["panelOutbox"].Controls["tbOutKateuth"].Text = lvic[8].Text;
                updScreen.Controls["panelOutbox"].Controls["tbOutSummary"].Text = lvic[9].Text; //
                updScreen.Controls["panelOutbox"].Controls["tbOutToText"].Text = lvic[10].Text;

                updScreen.Controls["panelOutbox"].Controls["lblOutProtokolo"].Visible = true;
                updScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Visible = true;
                updScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Text = lvic[4].Text;
                updScreen.Controls["panelOutbox"].Controls["tbOutYear"].Visible = true;
                updScreen.Controls["panelOutbox"].Controls["tbOutYear"].Text = lvic[2].Text;

                //updScreen.Controls["panelOutbox"].Controls["btnOutAddFiles"].Enabled = false;
                //updScreen.Controls["panelOutbox"].Controls["btnOutRemoveFile"].Enabled = false;
                //updScreen.Controls["panelOutbox"].Controls["btnOutRemoveAll"].Enabled = false;

                //get 'Attachments' from ProtokPdf and extract files to Temp
                List<string> AttFilesPath = saveAttachmentsLocally(Convert.ToInt32(lvic[0].Text));
                //add files to listView
                addTmpFilesIntoListView(((ListView)updScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"]), AttFilesPath);

                //updScreen.Controls["panelOutbox"].Controls["dtpOutSetDate"].Enabled = false;
                //updScreen.Controls["panelOutbox"].Controls["cbOutFolders"].Enabled = false;
                //updScreen.Controls["panelOutbox"].Controls["btnOutNewFolders"].Enabled = false;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutKateuth"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutKateuth"]).BackColor = Color.White;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutSummary"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutSummary"]).BackColor = Color.White;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutToText"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutToText"]).BackColor = Color.White;
                //updScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"].AllowDrop = false;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"]).BackColor = Color.White;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutYear"]).ReadOnly = true;
                //((TextBox)updScreen.Controls["panelOutbox"].Controls["tbOutYear"]).BackColor = Color.White;
            }

            updScreen.tsStatusLblInsUser.Text = "Χρήστης Μεταβολής: " + UserInfo.WindowsUser + " - " + UserInfo.FullName;

            updScreen.ShowDialog();

            //send or show mail
            if (updScreen.successfulInsertion && updScreen.chbSendMail.Checked)
            {
                if (updScreen.IOBoxPanel.Name.ToUpper() == "PANELINBOX")
                {
                    try
                    {
                        //Show Contacts...
                        outlookForms oF = new outlookForms();
                        oF.showContacts();

                        if (oF.RecipientsList.Count > 0)
                        {
                            //Show Mail... 
                            //oF.ShowMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Save Mail... 
                            //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Send Mail... 
                            oF.SendMail(updScreen.myEmail.ProtokId, updScreen.myEmail.Subject, updScreen.myEmail.Body, updScreen.AttFilesList);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMess = ex.Message; //do nothing - constructor catches the exception
                        MessageBox.Show("The following error occurred: " + exMess);
                    }
                }
                else if (updScreen.IOBoxPanel.Name.ToUpper() == "PANELOUTBOX")
                {
                    //temporarily hide 'dieuthinsiografo' and replace with outlook address book
                    /*
                    //Show ContactsToEmail Form
                    ContactsToEmail cteFrm = new ContactsToEmail();
                    cteFrm.ShowDialog();

                    try
                    {
                        if (cteFrm.frmSaved) //check if recipients.count > 0
                        {
                            outlookForms oF = new outlookForms();
                            oF.fillRecipientList(cteFrm.txtRecipientsTo.Text, cteFrm.txtRecipientsCc.Text, cteFrm.txtRecipientsBcc.Text);

                            //Show Mail... 
                            oF.ShowMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Save Mail... 
                            //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Send Mail... 
                            //oF.SendMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMess = ex.Message; //do nothing - constructor catches the exception
                        //MessageBox.Show(exMess);
                    }
                    */

                    try
                    {
                        //Show Contacts...
                        outlookForms oF = new outlookForms();
                        oF.showContacts();

                        if (oF.RecipientsList.Count > 0)
                        {
                            //Show Mail... 
                            oF.ShowMail(updScreen.myEmail.ProtokId, updScreen.myEmail.Subject, updScreen.myEmail.Body, updScreen.AttFilesList);

                            //Save Mail... 
                            //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Send Mail... 
                            //oF.SendMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMess = ex.Message; //do nothing - constructor catches the exception
                        MessageBox.Show("The following error occurred: " + exMess);
                    }

                }
            }
            
            //?????????????????
            if (FiltersFrm == null)
            {
                //no filters
                ShowDataToListView(lvRep);
            }
            else
            {
                //get filters
                ShowDataToListView(lvRep, FiltersFrm.whereStr);
            }
        }
                
        ProtokFiltersForm FiltersFrm; 
        private void btnFilters_Click(object sender, EventArgs e)
        {
            if (FiltersFrm == null)//first time
            {
                FiltersFrm = new ProtokFiltersForm(); // ("WHERE month(P.DocumentGetSetDate) = month(getdate()) and isnull(P.deleted, 0) = 0 ");
                //set initial values
                //FiltersFrm.saveFilters = false; //no need to initialize
                FiltersFrm.savedFilters.Clear();//not needed right now
                FiltersFrm.savedFilters.Add(new Filter("chbDeleted", "false"));
                
                FiltersFrm.savedFilters.Add(new Filter("dtpGetSetDate_From", new DateTime(DateTime.Now.Year, 1, 1).ToString("dd-MM-yyyy")));
                FiltersFrm.savedFilters.Add(new Filter("dtpGetSetDate_To", new DateTime(DateTime.Now.Year, 12, 31).ToString("dd-MM-yyyy")));

                FiltersFrm.savedFilters.Add(new Filter("dtp_DocDate_From", new DateTime(DateTime.Now.Year, 1, 1).ToString("dd-MM-yyyy")));
                FiltersFrm.savedFilters.Add(new Filter("dtp_DocDate_To", new DateTime(DateTime.Now.Year, 12, 31).ToString("dd-MM-yyyy")));

                //set where... 
                //FiltersFrm.whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") + 
                //                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 ";
                FiltersFrm.whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 and isnull(P.updated, 0) = 0 " +
                                      " and isnull(P.DocumentDate, '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") + "') between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' ";

                //FiltersFrm.JoinFiltersWithControls();
            }
            else //change filters
            {
                FiltersFrm.saveFilters = false;

                List<Filter> SavedControls = FiltersFrm.savedFilters;
                string SavedWhereStr = FiltersFrm.whereStr;

                FiltersFrm = new ProtokFiltersForm();
                FiltersFrm.savedFilters = SavedControls;
                FiltersFrm.whereStr = SavedWhereStr;

                //set initial values
                //FiltersFrm.savedFilters.Clear();
                //FiltersFrm.savedFilters.Add(new Filter("chbDeleted", "true"));

                //FiltersFrm.JoinFiltersWithControls();
            }

            FiltersFrm.JoinFiltersWithControls();

            FiltersFrm.ShowDialog();

            if (FiltersFrm.saveFilters == true)
            {
                btnFilters.Font = new Font(btnFilters.Font, FontStyle.Underline);

                FiltersFrm.saveFilters = false;
                //FiltersFrm.JoinFiltersWithControls(); //now is closed - draw controls only before showDialog

                ShowDataToListView(lvRep, FiltersFrm.whereStr);
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            if (FiltersFrm != null)
            {
                FiltersFrm.savedFilters.Clear();//not needed right now
                FiltersFrm.savedFilters.Add(new Filter("chbDeleted", "false"));

                FiltersFrm.savedFilters.Add(new Filter("dtpGetSetDate_From", new DateTime(DateTime.Now.Year, 1, 1).ToString("dd-MM-yyyy")));
                FiltersFrm.savedFilters.Add(new Filter("dtpGetSetDate_To", new DateTime(DateTime.Now.Year, 12, 31).ToString("dd-MM-yyyy")));

                FiltersFrm.savedFilters.Add(new Filter("dtp_DocDate_From", new DateTime(DateTime.Now.Year, 1, 1).ToString("dd-MM-yyyy")));
                FiltersFrm.savedFilters.Add(new Filter("dtp_DocDate_To", new DateTime(DateTime.Now.Year, 12, 31).ToString("dd-MM-yyyy")));

                //set where... 
                //FiltersFrm.whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                //                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 ";
                FiltersFrm.whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 and isnull(P.updated, 0) = 0 " +
                                      " and isnull(P.DocumentDate, '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") + "') between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' ";

                btnFilters.Font = new Font(btnFilters.Font, FontStyle.Regular);

                ShowDataToListView(lvRep, FiltersFrm.whereStr);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printings lvPrintings = new Printings();

            //if (FiltersFrm != null)
            //{
            //    lvPrintings.printProtocols(lvRep, FiltersFrm.savedFilters);
            //}
            //else
            {
                //lvPrintings.printProtocols(lvRep, new List<Filter>());

                List<Filter> FiltersForm__savedFilters = new List<Filter>();
                if (FiltersFrm != null)
                {
                    FiltersForm__savedFilters.AddRange(FiltersFrm.savedFilters);
                }
                lvPrintings.printProtocols(lvRep, FiltersForm__savedFilters);
            }

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                excelForms eF = new excelForms();
                eF.ExportProtocolListViewToExcel(lvRep, true, true);
                eF.Visible = true;
            }
            catch(Exception ex)
            {
                string exMess = ex.Message; //do nothing - constructor catches the exception
                //MessageBox.Show(exMess);
            }
        }

    }

}
