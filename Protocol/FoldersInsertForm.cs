﻿using System;
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

            cbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
            ProtokoloInsertForm.IfUniqueSelectIt(cbCompany);

            cbProced.Items.AddRange(ProtokoloInsertForm.GetObjProtocolKind());
            
            NewRecord = false;

            cbCompany.Select();
        }

        public FoldersInsertForm(Company company, Proced proced)
        {
            InitializeComponent();
            
            cbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
            cbProced.Items.AddRange(ProtokoloInsertForm.GetObjProtocolKind());

            cbCompany.SelectedIndex = cbCompany.FindStringExact(company.Name);
            cbProced.SelectedIndex = cbProced.FindStringExact(proced.Name);

            //cbCompany.SelectedIndex = cbCompany.FindStringExact(company.Name);
            //cbCompany.SelectedIndex = cbCompany.Items.IndexOf(new ComboboxItem() { Text = company.Name, Value = company });

            cbCompany.Enabled = false;
            cbProced.Enabled = false;
            
            NewRecord = false;
        }

        public bool NewRecord;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cbCompany.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Εταιρία'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbProced.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Κατηγορία Πρωτοκόλλου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Όνομα Φακέλου'!", "Προσοχή!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //update mode...
            if (txtId.Text.Trim() != "")
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string UpdSt = "UPDATE [dbo].[Folders] SET name = @name, descr = @description WHERE Id = @Id ";

                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@description", txtDescr.Text.Trim());
                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Η εγγραφή ενημερώθηκε επιτυχώς!");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }
            else //insert mode...
            {
                SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[Folders] (id, companyId, ProcedId, name, descr) VALUES ((select isnull(max(id), 0) + 1 from [dbo].[Folders]), @company, @proced, @name, @descr) ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@company", ((Company)((ComboboxItem)cbCompany.SelectedItem).Value).Id);
                    cmd.Parameters.AddWithValue("@proced", ((Proced)((ComboboxItem)cbProced.SelectedItem).Value).Id);
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

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCompany.Enabled = false;
        }

        private void cbProced_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProced.Enabled = false;
        }
    }
}
