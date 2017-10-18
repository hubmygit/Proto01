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
                              "WHERE year(P.DocumentGetSetDate) = year(getdate()) and isnull(P.deleted, 0) = 0 " +
                              "ORDER BY C.Name, P.Year, PR.Name, P.Sn ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = { reader[0].ToString(),
                                     reader[1].ToString(),
                                     reader[2].ToString(),
                                     reader[3].ToString(),
                                     reader[4].ToString(),
                                     reader[5].ToString(),
                                     reader[6].ToString(),
                                     reader[7].ToString(),
                                     reader[8].ToString(),
                                     reader[9].ToString(),
                                     reader[10].ToString(),
                                     reader[11].ToString(),
                                     reader[12].ToString(),
                                     reader[13].ToString()};

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

        string[] getSavedAttachments(int ProtokId)
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
            ProtokoloInsertForm updScreen = new ProtokoloInsertForm();
            //updScreen.cbProtokoloKind.Text = "Εισερχόμενα";

            ListViewItem.ListViewSubItemCollection lvic = new ListViewItem.ListViewSubItemCollection(lvRep.SelectedItems[0]);
            string proced = lvic[2].Text;
            string company = lvic[3].Text;

            updScreen.Text = "Μεταβολή";
            updScreen.btnInsert.Text = "Μεταβολή";

            updScreen.cbProtokoloKind.SelectedIndex = updScreen.cbProtokoloKind.FindStringExact(proced);
            updScreen.cbCompany.SelectedIndex = updScreen.cbCompany.FindStringExact(company);

            updScreen.Protok_Id_For_Updates = Convert.ToInt32(lvic[11].Text);

            //updScreen.cbCompany.Font = new Font(updScreen.cbCompany.Font, FontStyle.Bold);
            updScreen.cbCompany.Enabled = false;

            if (proced == "Εισερχόμενα")
            {
                ((DateTimePicker)updScreen.Controls["panelInbox"].Controls["dtpInGetDate"]).Value = DateTime.Parse(lvic[5].Text);
                updScreen.Controls["panelInbox"].Controls["tbInDocNum"].Text = lvic[6].Text;
                ((DateTimePicker)updScreen.Controls["panelInbox"].Controls["dtpInDocDate"]).Value = DateTime.Parse(lvic[4].Text);
                ((ComboBox)updScreen.Controls["panelInbox"].Controls["cbInFolders"]).SelectedIndex = ((ComboBox)updScreen.Controls["panelInbox"].Controls["cbInFolders"]).FindStringExact(lvic[10].Text);
                updScreen.Controls["panelInbox"].Controls["tbInProeleusi"].Text = lvic[7].Text;
                updScreen.Controls["panelInbox"].Controls["tbInSummary"].Text = lvic[8].Text;
                updScreen.Controls["panelInbox"].Controls["tbInToText"].Text = lvic[9].Text;

                updScreen.Controls["panelInbox"].Controls["lblInProtokolo"].Visible = true;
                updScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Visible = true;
                updScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Text = lvic[0].Text;
                updScreen.Controls["panelInbox"].Controls["tbInYear"].Visible = true;
                updScreen.Controls["panelInbox"].Controls["tbInYear"].Text = lvic[1].Text;

                updScreen.Controls["panelInbox"].Controls["btnInAddFiles"].Enabled = false;
                updScreen.Controls["panelInbox"].Controls["btnInRemoveFile"].Enabled = false;
                updScreen.Controls["panelInbox"].Controls["btnInRemoveAll"].Enabled = false;
                //get results as string array
                string[] fileNames = getSavedAttachments(Convert.ToInt32(lvic[11].Text));
                //fill listview
                foreach (string thisFileName in fileNames)
                {
                    ((ListView)updScreen.Controls["panelInbox"].Controls["lvInAttachedFiles"]).Items.Add(new ListViewItem(thisFileName));
                }
            }
            else if (proced == "Εξερχόμενα")
            {
                ((DateTimePicker)updScreen.Controls["panelOutbox"].Controls["dtpOutSetDate"]).Value = DateTime.Parse(lvic[5].Text);
                //updScreen.Controls["panelOutbox"].Controls["tbOutDocNum"].Text = lvic[6].Text;
                ((ComboBox)updScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).SelectedIndex = ((ComboBox)updScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).FindStringExact(lvic[10].Text);
                updScreen.Controls["panelOutbox"].Controls["tbOutKateuth"].Text = lvic[7].Text;
                updScreen.Controls["panelOutbox"].Controls["tbOutSummary"].Text = lvic[8].Text;

                updScreen.Controls["panelOutbox"].Controls["lblOutProtokolo"].Visible = true;
                updScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Visible = true;
                updScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Text = lvic[0].Text;
                updScreen.Controls["panelOutbox"].Controls["tbOutYear"].Visible = true;
                updScreen.Controls["panelOutbox"].Controls["tbOutYear"].Text = lvic[1].Text;

                updScreen.Controls["panelOutbox"].Controls["btnOutAddFiles"].Enabled = false;
                updScreen.Controls["panelOutbox"].Controls["btnOutRemoveFile"].Enabled = false;
                updScreen.Controls["panelOutbox"].Controls["btnOutRemoveAll"].Enabled = false;
                //get results as string array
                string[] fileNames = getSavedAttachments(Convert.ToInt32(lvic[11].Text));
                //fill listview
                foreach (string thisFileName in fileNames)
                {
                    ((ListView)updScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"]).Items.Add(new ListViewItem(thisFileName));
                }
            }


            updScreen.ShowDialog();

            //refresh listView - ToDo: Not always. Only after real insert
            lvRep.Items.Clear();
            ShowDataToListView(lvRep);
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            //Do something with Filters
        }
    }
}
