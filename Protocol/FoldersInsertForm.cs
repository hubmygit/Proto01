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
    public partial class FoldersInsertForm : Form
    {
        public FoldersInsertForm()
        {
            InitializeComponent();

            NewRecord = false;
        }

        public bool NewRecord;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Όνομα Φακέλου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string InsSt = "INSERT INTO [dbo].[Folders] (id, name, descr) VALUES ((select isnull(max(id), 0) + 1 from [dbo].[Folders]), @name, @descr) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@descr", txtDescr.Text.Trim());
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                NewRecord = true;

                MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
    }
}
