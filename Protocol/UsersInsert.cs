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
    public partial class UsersInsert : Form
    {
        public UsersInsert()
        {
            InitializeComponent();

            //txtWinUser.Text = UserInfo.WindowsUser;
            //txtFullName.Text = UserInfo.FullName;
            //txtEmail.Text = UserInfo.EmailAddress;
            chlbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
        }

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckedStatus = false;
            if (chlbCompany.Items.Count == chlbCompany.CheckedItems.Count) //all checked
            {
                CheckedStatus = false; //make them false
            }
            else //not all checked
            {
                CheckedStatus = true; //make them true
            }

            for (int i = 0; i < chlbCompany.Items.Count; i++)
            {
                chlbCompany.SetItemChecked(i, CheckedStatus);
            }
        }

        bool InsertUser(string WinUser, string FullName, string EmailAddress)
        {
            bool ret = false;
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[AppUsers] (WinUser, FullName, EmailAddress, InsDate) VALUES (@WinUser, @FullName, @EmailAddress, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@WinUser", WinUser);//((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id);
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                ret = true;

                MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return ret;
        }

        int getUserIdFromAppUser(string WinUser)
        {
            int ret = 0;
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[AppUsers] WHERE WinUser = '" + WinUser + "'";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return ret;
        }

        void deleteUserAuthorizations(int UserId)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string DeleteSt = "DELETE FROM [dbo].[AppAuth] WHERE UserId = @Id ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(DeleteSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", UserId);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        bool InsertUserAuth(int UserId, int CompanyId)
        {
            bool ret = false;
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[AppAuth] (UserId, CompanyId) VALUES (@UserId, @CompanyId) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CompanyId", CompanyId);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                ret = true;

                MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return ret;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertUser(txtWinUser.Text.Trim(), txtFullName.Text.Trim(), txtEmail.Text.Trim());
            //if exists catch error and continue!!! Its Ok!

            int UserId = getUserIdFromAppUser(txtWinUser.Text.Trim());
            if (UserId > 0)
            {
                deleteUserAuthorizations(UserId);

                //insert
                //all companies - insert 1 row: 999
                if (chlbCompany.Items.Count == chlbCompany.CheckedItems.Count) //all checked
                {
                    InsertUserAuth(UserId, 999);
                }
                else //one or some companies - insert x rows
                {
                    List<int> CompaniesList = ProtokFiltersForm.Get_CheckedListBox_Checked_Indexes(chlbCompany);
                    foreach (int thisCom in CompaniesList)
                    {
                        InsertUserAuth(UserId, thisCom);
                    }
                }
            }


        }
    }
}
