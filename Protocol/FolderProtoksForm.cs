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
    public partial class FolderProtoksForm : Form
    {
        public FolderProtoksForm(int FolderId)
        {
            InitializeComponent();
            
            ShowDataToListView(lvRep, FolderId);
        }

        public void ShowDataToListView(ListView lvReport, int FolderId)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT P.Sn, P.Year, PR.Name as ProcedName, C.Name as CompanyName, convert(varchar, P.DocumentDate, 104) as _DocumentDate, " +
                                     "convert(varchar, P.DocumentGetSetDate, 104) as _DocumentGetSetDate, P.DocumentNumber, P.ProeleusiKateuth, P.Summary, P.ToText, F.Name, P.Id, " +
                                     "(select count(*) from [dbo].[ProtokPdf] PA where PA.ProtokId = P.id) as Att, " +
                                     "(select count(*) from [dbo].[ReceiverList] RL where RL.ProtokId = P.id) as Mails " +
                              "FROM [dbo].[Protok] P left outer join [dbo].[Proced] PR on PR.id = P.ProcedureId " +
                              "left outer join [dbo].[Company] C on C.id = P.CompanyId " +
                              "left outer join [dbo].[Folders] F on F.id = P.FolderId " + //and F.CompanyId = P.CompanyId and F.ProcedId = P.ProcedureId " +
                              //"WHERE month(P.DocumentGetSetDate) = month(getdate()) and isnull(P.deleted, 0) = 0 and F.id = " + FolderId.ToString();
                              "WHERE year(P.DocumentGetSetDate) = year(getdate()) and isnull(P.deleted, 0) = 0 and F.id = " + FolderId.ToString() +

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



        private void lvRep_DoubleClick(object sender, EventArgs e)
        {
            //use functions from 'ProtokoloSelectForm'
            ProtokoloSelectForm ProtocolSelFrm = new ProtokoloSelectForm();

            ProtokoloInsertForm selScreen = new ProtokoloInsertForm();
            ListViewItem.ListViewSubItemCollection lvic = new ListViewItem.ListViewSubItemCollection(lvRep.SelectedItems[0]);

            string proced = lvic[3].Text;
            string company = lvic[1].Text;

            selScreen.Text = "Εμφάνιση";

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
                string[] fileNames = ProtocolSelFrm.getSavedAttachments(Convert.ToInt32(lvic[0].Text));
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
                selScreen.Controls["panelOutbox"].Controls["tbOutSummary"].Text = lvic[9].Text; // ?
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
                
                string[] fileNames = ProtocolSelFrm.getSavedAttachments(Convert.ToInt32(lvic[0].Text));
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

            InsUser InsUsr = ProtocolSelFrm.getInsUserInfos(Convert.ToInt32(lvic[0].Text));
            selScreen.tsStatusLblInsUser.Text = "Χρήστης Καταχώρησης: " + InsUsr.WindowsUser + " - " + InsUsr.FullName;

            selScreen.ShowDialog();
        }

        //private void btnFilters_Click(object sender, EventArgs e)
        //{
        //    //not needed here...
        //}
    }
}
