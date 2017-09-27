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
    public partial class ProtokPerFolderForm : Form
    {
        public ProtokPerFolderForm()
        {
            InitializeComponent();
            
            ShowDataToListView(lvRep);
        }

        public void ShowDataToListView(ListView lvReport)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT F.Name as Folder, C.Name as Company, PR.Name as Proced, F.Descr, count(P.FolderId) as Cnt, F.Id " +
                              "FROM[dbo].[Folders] F left outer join[dbo].[Company] C on C.Id = F.CompanyId " +
                                  "left outer join Proced PR on PR.Id = F.ProcedId " + 
                                  "left outer join [dbo].[Protok] P on P.FolderId = F.Id and isnull(P.deleted, 0) = 0 " +
                              "GROUP BY C.Name, PR.Name, F.Name, F.Descr, F.Id " +
                              "ORDER BY F.Name ";
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
                                     reader[5].ToString()};

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
            string lvRowCnt = lvRep.SelectedItems[0].SubItems[4].Text;
            //string lvRowFolder = lvRep.SelectedItems[0].SubItems[2].Text;
            string lvRowId = lvRep.SelectedItems[0].SubItems[5].Text;
            //string lvRowEisEx = lvRep.SelectedItems[0].SubItems[1].Text;
            //string lvRowCompany = lvRep.SelectedItems[0].SubItems[0].Text;

            if (Convert.ToInt32(lvRowCnt) > 0)
            {
                FolderProtoksForm folderProtoklsd = new FolderProtoksForm(Convert.ToInt32(lvRowId));
                folderProtoklsd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν Πρωτόκολλα που να έχουν αναφορά σε αυτό το Φάκελο!");
            }
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            //Do something with Filters
        }
    }
}
