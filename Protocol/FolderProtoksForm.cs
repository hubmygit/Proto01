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
                              "WHERE month(P.DocumentGetSetDate) = month(getdate()) and isnull(P.deleted, 0) = 0 and F.id = " + FolderId.ToString();

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
            //
        }

        //private void btnFilters_Click(object sender, EventArgs e)
        //{
        //    //not needed here...
        //}
    }
}
