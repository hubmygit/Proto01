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
    public partial class UsersSelect : Form
    {
        public UsersSelect()
        {
            InitializeComponent();

            chlbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
            cbUser.Items.AddRange(GetObjAppUsers());
        }

        public static ComboboxItem[] GetObjAppUsers()
        {
            List<AppUsers> AppUsers = new List<AppUsers>();
            List<ComboboxItem> cbAppUsers = new List<ComboboxItem>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id, WinUser, FullName, EmailAddress, InsDate FROM [dbo].[AppUsers] ORDER BY WinUser ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppUsers.Add(new AppUsers() { Id = Convert.ToInt32(reader["Id"].ToString()), WinUser = reader["WinUser"].ToString(),
                        FullName = reader["FullName"].ToString(), EmailAddress = reader["EmailAddress"].ToString(), InsDate = reader["InsDate"].ToString() });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            foreach (AppUsers user in AppUsers)
            {
                cbAppUsers.Add(new ComboboxItem() { Value = user, Text = user.WinUser });
            }

            return cbAppUsers.ToArray<ComboboxItem>();
        }
        
        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFullName.Text = ((AppUsers)((ComboboxItem)((ComboBox)sender).SelectedItem).Value).FullName;
            txtEmail.Text = ((AppUsers)((ComboboxItem)((ComboBox)sender).SelectedItem).Value).EmailAddress;
            txtInsDt.Text = ((AppUsers)((ComboboxItem)((ComboBox)sender).SelectedItem).Value).InsDate;

            int UserId = ((AppUsers)((ComboboxItem)((ComboBox)sender).SelectedItem).Value).Id;

            List<int> coms = UserInfo.Get_User_Assigned_Companies(UserId);

            for (int i = 0; i < chlbCompany.Items.Count; i++)
            {
                chlbCompany.SetItemChecked(i, false);
            }

            List<int> chlbIndexes = new List<int>();
            foreach (var thisItem in chlbCompany.Items)
            {
                int comId = ((Company)((ComboboxItem)thisItem).Value).Id;
                if (coms.Exists(i => i.Equals(comId)))
                {
                    chlbIndexes.Add(chlbCompany.Items.IndexOf(thisItem));
                }
            }

            foreach (int thisIndex in chlbIndexes)
            {
                chlbCompany.SetItemChecked(thisIndex, true);
            }

        }
    }
}
