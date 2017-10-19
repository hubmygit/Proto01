using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Protocol
{
    public partial class AboutUserInfoForm : Form
    {
        public AboutUserInfoForm()
        {
            InitializeComponent();

            txtUserId.Text = UserInfo.DB_AppUser_Id.ToString();
            txtWinUser.Text = UserInfo.WindowsUser;
            txtFullName.Text = UserInfo.FullName;
            txtEmail.Text = UserInfo.EmailAddress;

            txtMachine.Text = UserInfo.MachineName;
            txtDomain.Text = UserInfo.DomainName;
            txtOs.Text = UserInfo.OsVersion;

            ShowAssignedCompaniesToListView(lvRep);
        }

        public void ShowAssignedCompaniesToListView(ListView lvReport)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            //string SelectSt = "SELECT Id, Name FROM [dbo].[Company] WHERE Id in (" + UserInfo.CompaniesAsCsvString + ") ORDER BY Name";
            string SelectSt = "SELECT Name FROM [dbo].[Company] WHERE Id in (" + UserInfo.CompaniesAsCsvString + ") ORDER BY Name";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //string[] row = { reader["Id"].ToString(), reader["Name"].ToString()};
                    string[] row = { reader["Name"].ToString() };

                    ListViewItem listViewItem = new ListViewItem(row);
                    lvReport.Items.Add(listViewItem);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }


        }

    }
}
