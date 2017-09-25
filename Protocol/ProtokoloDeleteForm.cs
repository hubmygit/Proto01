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
    public partial class ProtokoloDeleteForm : Form
    {
        public ProtokoloDeleteForm()
        {
            InitializeComponent();
            
            ShowDataToListView(lvRep);
        }

        public void ShowDataToListView(ListView lvReport)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT P.Sn, P.Year, PR.Name as ProcedName, C.Name as CompanyName, convert(varchar, P.DocumentDate, 104) as _DocumentDate, " +
                                     "convert(varchar, P.DocumentGetSetDate, 104) as _DocumentGetSetDate, P.DocumentNumber, P.ProeleusiKateuth, P.Summary, P.ToText, F.Name, P.Id " +
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
                                     reader[11].ToString()};

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
            string lvRowYear = lvRep.SelectedItems[0].SubItems[1].Text;
            string lvRowProtocol = lvRep.SelectedItems[0].SubItems[0].Text;
            string lvRowId = lvRep.SelectedItems[0].SubItems[11].Text;
            string lvRowEisEx = lvRep.SelectedItems[0].SubItems[2].Text;
            string lvRowCompany = lvRep.SelectedItems[0].SubItems[3].Text;

            //if (lvRowYear.Trim() != "" && lvRowProtocol.Trim() != "")
            if (lvRowId.Trim() != "")
            {
                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να διαγράψετε την εγγραφή του Έτους " + lvRowYear + " με Αριθμό Πρωτοκόλλου " + lvRowProtocol + 
                    " (" + lvRowEisEx + ") της Εταιρίας" + lvRowCompany + ";", "Διαγραφή", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeletionReasonForm delReasonFrm = new DeletionReasonForm();
                    delReasonFrm.ShowDialog();

                    if (delReasonFrm.Successful)
                    {
                        SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                        //string DeleteSt = "UPDATE [dbo].[Protok] SET Deleted = 1, DelDt = getdate() WHERE Sn = @Sn and Year = @Year ";
                        string DeleteSt = "UPDATE [dbo].[Protok] SET Deleted = 1, DelDt = getdate(), DelUsr = @DelUsr, DelReason = @DelReason WHERE Id = @Id ";

                        try
                        {
                            sqlConn.Open();
                            SqlCommand cmd = new SqlCommand(DeleteSt, sqlConn);

                            //cmd.Parameters.AddWithValue("@Sn", lvRowProtocol);
                            //cmd.Parameters.AddWithValue("@Year", lvRowYear);
                            cmd.Parameters.AddWithValue("@Id", lvRowId);
                            cmd.Parameters.AddWithValue("@DelUsr", UserInfo.DB_AppUser_Id);
                            cmd.Parameters.AddWithValue("@DelReason", delReasonFrm.txtDelReason.Text);

                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Η εγγραφή διαγράφηκε επιτυχώς!");
                            Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The following error occurred: " + ex.Message);
                        }

                        Close();
                    }
                }
            }
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            //Do something with Filters
        }
    }
}
