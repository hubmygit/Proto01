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
                              "WHERE month(P.DocumentGetSetDate) = month(getdate()) and isnull(P.deleted, 0) = 0 ";

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
            ProtokoloInsertForm selScreen = new ProtokoloInsertForm();
            //updScreen.cbProtokoloKind.Text = "Εισερχόμενα";

            ListViewItem.ListViewSubItemCollection lvic = new ListViewItem.ListViewSubItemCollection(lvRep.SelectedItems[0]);
            string proced = lvic[2].Text;
            string company = lvic[3].Text;

            selScreen.Text = "Εμφάνιση";
            //selScreen.formCRUDMode = CRUD_Mode.SELECT;

            selScreen.btnInsert.Enabled = false;
            selScreen.btnCancel.Enabled = false;

            selScreen.cbProtokoloKind.SelectedIndex = selScreen.cbProtokoloKind.FindStringExact(proced);
            selScreen.cbCompany.SelectedIndex = selScreen.cbCompany.FindStringExact(company);

            selScreen.Protok_Id_For_Updates = Convert.ToInt32(lvic[11].Text);
                      
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
                selScreen.Controls["panelInbox"].Controls["tbInDocNum"].Text = lvic[6].Text;
                ((DateTimePicker)selScreen.Controls["panelInbox"].Controls["dtpInDocDate"]).Value = DateTime.Parse(lvic[4].Text);
                ((ComboBox)selScreen.Controls["panelInbox"].Controls["cbInFolders"]).SelectedIndex = ((ComboBox)selScreen.Controls["panelInbox"].Controls["cbInFolders"]).FindStringExact(lvic[10].Text);
                selScreen.Controls["panelInbox"].Controls["tbInProeleusi"].Text = lvic[7].Text;
                selScreen.Controls["panelInbox"].Controls["tbInSummary"].Text = lvic[8].Text;
                selScreen.Controls["panelInbox"].Controls["tbInToText"].Text = lvic[9].Text;

                selScreen.Controls["panelInbox"].Controls["lblInProtokolo"].Visible = true;
                selScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Visible = true;
                selScreen.Controls["panelInbox"].Controls["tbInProtokoloNum"].Text = lvic[0].Text;
                selScreen.Controls["panelInbox"].Controls["tbInYear"].Visible = true;
                selScreen.Controls["panelInbox"].Controls["tbInYear"].Text = lvic[1].Text;

                selScreen.Controls["panelInbox"].Controls["btnInAddFiles"].Enabled = false;
                selScreen.Controls["panelInbox"].Controls["btnInRemoveFile"].Enabled = false;
                selScreen.Controls["panelInbox"].Controls["btnInRemoveAll"].Enabled = false;
                //get results as string array
                string[] fileNames = getSavedAttachments(Convert.ToInt32(lvic[11].Text));
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
                selScreen.Controls["panelOutbox"].Controls["tbOutDocNum"].Text = lvic[6].Text;
                ((ComboBox)selScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).SelectedIndex = ((ComboBox)selScreen.Controls["panelOutbox"].Controls["cbOutFolders"]).FindStringExact(lvic[10].Text);
                selScreen.Controls["panelOutbox"].Controls["tbOutKateuth"].Text = lvic[7].Text;
                selScreen.Controls["panelOutbox"].Controls["tbOutSummary"].Text = lvic[8].Text;

                selScreen.Controls["panelOutbox"].Controls["lblOutProtokolo"].Visible = true;
                selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Visible = true;
                selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"].Text = lvic[0].Text;
                selScreen.Controls["panelOutbox"].Controls["tbOutYear"].Visible = true;
                selScreen.Controls["panelOutbox"].Controls["tbOutYear"].Text = lvic[1].Text;

                selScreen.Controls["panelOutbox"].Controls["btnOutAddFiles"].Enabled = false;
                selScreen.Controls["panelOutbox"].Controls["btnOutRemoveFile"].Enabled = false;
                selScreen.Controls["panelOutbox"].Controls["btnOutRemoveAll"].Enabled = false;
                //get results as string array
                string[] fileNames = getSavedAttachments(Convert.ToInt32(lvic[11].Text));
                //fill listview
                foreach (string thisFileName in fileNames)
                {
                    ((ListView)selScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"]).Items.Add(new ListViewItem(thisFileName));
                }

                selScreen.Controls["panelOutbox"].Controls["dtpOutSetDate"].Enabled = false;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutDocNum"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutDocNum"]).BackColor = Color.White;
                selScreen.Controls["panelOutbox"].Controls["cbOutFolders"].Enabled = false;
                selScreen.Controls["panelOutbox"].Controls["btnOutNewFolders"].Enabled = false;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutKateuth"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutKateuth"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutSummary"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutSummary"]).BackColor = Color.White;
                selScreen.Controls["panelOutbox"].Controls["lvOutAttachedFiles"].AllowDrop = false;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutProtokoloNum"]).BackColor = Color.White;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutYear"]).ReadOnly = true;
                ((TextBox)selScreen.Controls["panelOutbox"].Controls["tbOutYear"]).BackColor = Color.White;
            }


            selScreen.ShowDialog();

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
