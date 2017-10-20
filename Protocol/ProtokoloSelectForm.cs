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

namespace Protocol
{
    public partial class ProtokoloSelectForm : Form
    {
        public ProtokoloSelectForm()
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
                              "WHERE year(P.DocumentGetSetDate) = year(getdate()) and isnull(P.deleted, 0) = 0 " +

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

        private void lvRep_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("ΑΑ Πρωτοκόλλου: " + lvRep.SelectedItems[0].SubItems[0].Text + ", Έτος: " + lvRep.SelectedItems[0].SubItems[1].Text);

            //todo: new constructor ProtokoloInsertForm(object Protokolo)
            ProtokoloInsertForm selScreen = new ProtokoloInsertForm();
            //updScreen.cbProtokoloKind.Text = "Εισερχόμενα";

            ListViewItem.ListViewSubItemCollection lvic = new ListViewItem.ListViewSubItemCollection(lvRep.SelectedItems[0]);

            string proced = lvic[3].Text;
            string company = lvic[1].Text;

            selScreen.Text = "Εμφάνιση";
            //selScreen.formCRUDMode = CRUD_Mode.SELECT;

            selScreen.btnInsert.Enabled = false;
            selScreen.btnCancel.Enabled = false;

            selScreen.cbProtokoloKind.SelectedIndex = selScreen.cbProtokoloKind.FindStringExact(proced);
            selScreen.cbCompany.SelectedIndex = selScreen.cbCompany.FindStringExact(company);

            selScreen.Protok_Id_For_Updates = Convert.ToInt32(lvic[0].Text);
                      
            if (Convert.ToInt32(lvic[13].Text) > 0)
            {
                selScreen.chbSendMail.Checked = true;
                selScreen.btnShowRecipients.Enabled = true;
            }
            //selScreen.chbSendMail.Enabled = false;
            selScreen.chbSendMail.AutoCheck = false;

            if (proced == "Εισερχόμενα")
            {
                ((DateTimePicker)selScreen.Controls["panelInbox"].Controls["dtpInGetDate"]).Value = DateTime.Parse(lvic[5].Text);
                selScreen.Controls["panelInbox"].Controls["tbInDocNum"].Text = lvic[7].Text;
                ((DateTimePicker)selScreen.Controls["panelInbox"].Controls["dtpInDocDate"]).Value = DateTime.Parse(lvic[6].Text);
                ((ComboBox)selScreen.Controls["panelInbox"].Controls["cbInFolders"]).SelectedIndex = ((ComboBox)selScreen.Controls["panelInbox"].Controls["cbInFolders"]).FindStringExact(lvic[11].Text);
                selScreen.Controls["panelInbox"].Controls["tbInProeleusi"].Text = lvic[8].Text;
                selScreen.Controls["panelInbox"].Controls["tbInSummary"].Text = lvic[9].Text;
                selScreen.Controls["panelInbox"].Controls["tbInToText"].Text = lvic[10].Text;

                selScreen.Controls["panelInbox"].Controls["lblInProtokolo"].Visible = true;
                selScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Visible = true;
                selScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Text = lvic[4].Text;
                selScreen.Controls["panelInbox"].Controls["tbInYear"].Visible = true;
                selScreen.Controls["panelInbox"].Controls["tbInYear"].Text = lvic[2].Text;

                selScreen.Controls["panelInbox"].Controls["btnInAddFiles"].Enabled = false;
                selScreen.Controls["panelInbox"].Controls["btnInRemoveFile"].Enabled = false;
                selScreen.Controls["panelInbox"].Controls["btnInRemoveAll"].Enabled = false;
                //get results as string array
                string[] fileNames = getSavedAttachments(Convert.ToInt32(lvic[0].Text));
                //fill listview
                foreach (string thisFileName in fileNames)
                {
                    ((ListView)selScreen.Controls["panelInbox"].Controls["lvInAttachedFiles"]).Items.Add(new ListViewItem(thisFileName));
                }

                selScreen.Controls["panelInbox"].Controls["dtpInGetDate"].Enabled = false;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInDocNum"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInDocNum"]).BackColor = Color.White;
                selScreen.Controls["panelInbox"].Controls["dtpInDocDate"].Enabled = false;
                selScreen.Controls["panelInbox"].Controls["cbInFolders"].Enabled = false;
                selScreen.Controls["panelInbox"].Controls["btnInNewFolders"].Enabled = false;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInProeleusi"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInProeleusi"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInSummary"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInSummary"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInToText"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInToText"]).BackColor = Color.White;
                selScreen.Controls["panelInbox"].Controls["lvInAttachedFiles"].AllowDrop = false;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInYear"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelInbox"].Controls["tbInYear"]).BackColor = Color.White;
            }
            else if (proced == "Εξερχόμενα")
            {
                ((DateTimePicker)selScreen.Controls["panelOutbox"].Controls["dtpOutSetDate"]).Value = DateTime.Parse(lvic[5].Text);
                //selScreen.Controls["panelOutbox"].Controls["tbOutDocNum"].Text = lvic[7].Text;
                ((ComboBox)selScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).SelectedIndex = ((ComboBox)selScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).FindStringExact(lvic[11].Text);
                selScreen.Controls["panelOutbox"].Controls["tbOutKateuth"].Text = lvic[8].Text;
                selScreen.Controls["panelOutbox"].Controls["tbOutSummary"].Text = lvic[9].Text; //
                selScreen.Controls["panelOutbox"].Controls["tbOutToText"].Text = lvic[10].Text;

                selScreen.Controls["panelOutbox"].Controls["lblOutProtokolo"].Visible = true;
                selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Visible = true;
                selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Text = lvic[4].Text;
                selScreen.Controls["panelOutbox"].Controls["tbOutYear"].Visible = true;
                selScreen.Controls["panelOutbox"].Controls["tbOutYear"].Text = lvic[2].Text;

                selScreen.Controls["panelOutbox"].Controls["btnOutAddFiles"].Enabled = false;
                selScreen.Controls["panelOutbox"].Controls["btnOutRemoveFile"].Enabled = false;
                selScreen.Controls["panelOutbox"].Controls["btnOutRemoveAll"].Enabled = false;
                //get results as string array
                string[] fileNames = getSavedAttachments(Convert.ToInt32(lvic[0].Text));
                //fill listview
                foreach (string thisFileName in fileNames)
                {
                    ((ListView)selScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"]).Items.Add(new ListViewItem(thisFileName));
                }

                selScreen.Controls["panelOutbox"].Controls["dtpOutSetDate"].Enabled = false;
                //((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutDocNum"]).ReadOnly = true;
                //((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutDocNum"]).BackColor = Color.White;
                selScreen.Controls["panelOutbox"].Controls["cbOutFolders"].Enabled = false;
                selScreen.Controls["panelOutbox"].Controls["btnOutNewFolders"].Enabled = false;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutKateuth"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutKateuth"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutSummary"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutSummary"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutToText"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutToText"]).BackColor = Color.White;
                selScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"].AllowDrop = false;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutYear"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutYear"]).BackColor = Color.White;
            }

            InsUser InsUsr = getInsUserInfos(Convert.ToInt32(lvic[0].Text));
            selScreen.tsStatusLblInsUser.Text = "Χρήστης Καταχώρησης: " + InsUsr.WindowsUser + " - " + InsUsr.FullName;

            selScreen.ShowDialog();
            //select mode(!) - don't refresh listview
            //lvRep.Items.Clear();
            //ShowDataToListView(lvRep);
        }

        public InsUser getInsUserInfos(int ProtocolId)
        {
            InsUser ret = new InsUser();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT P.Id, P.InsUsr, U.WinUser, U.FullName " +
                "FROM [dbo].[Protok] P left outer join [dbo].[AppUsers] U on U.Id = P.InsUsr " +
                "WHERE P.id = " + ProtocolId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = new InsUser { WindowsUser = reader["WinUser"].ToString(), FullName = reader["FullName"].ToString() };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
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

                //set where... 
                FiltersFrm.whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") + 
                                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 ";

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

                //set where... 
                FiltersFrm.whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                                      "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 ";

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
                lvPrintings.printProtocols(lvRep, new List<Filter>());
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

        //private void lvRep_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        //{
        //    e.Graphics.FillRectangle(Brushes.Pink, e.Bounds);
        //    e.DrawText();
        //}
    }

    public class InsUser
    {
        //public InsUser()
        //{
        //    //
        //}
        
        public string WindowsUser { get; set; }
        public string FullName { get; set; }
    }
}
