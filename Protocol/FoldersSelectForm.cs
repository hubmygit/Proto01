﻿using System;
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
    public partial class FoldersSelectForm : Form
    {
        public FoldersSelectForm()
        {
            InitializeComponent();
            
            ShowDataToListView(lvRep);
        }

        public void ShowDataToListView(ListView lvReport)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT F.Name as Folder, C.Name as Company, PR.Name as Proced, F.Descr, count(P.FolderId) as Cnt, F.Id " +
                              "FROM [dbo].[Folders] F left outer join [dbo].[Company] C on C.Id = F.CompanyId " +
                                  "left outer join Proced PR on PR.Id = F.ProcedId " +
                                  "left outer join [dbo].[Protok] P on P.FolderId = F.Id and isnull(P.deleted, 0) = 0 and isnull(P.updated, 0) = 0 " +
                              " WHERE 1=1 and C.Id in (" + UserInfo.CompaniesAsCsvString + ") " +
                              "GROUP BY C.Name, PR.Name, F.Name, F.Descr, F.Id " +
                              "ORDER BY F.Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = { reader[5].ToString(), //id
                                     reader[0].ToString(), //
                                     reader[1].ToString(), //com
                                     reader[2].ToString(), //proced
                                     reader[3].ToString(), //
                                     reader[4].ToString()}; 

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

        public void ShowDataToListView(ListView lvReport, string selectStatement_where_part, string selectStatement_having_part)
        {
            lvReport.Items.Clear();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT F.Name as Folder, C.Name as Company, PR.Name as Proced, F.Descr, count(P.FolderId) as Cnt, F.Id " +
                              "FROM [dbo].[Folders] F left outer join [dbo].[Company] C on C.Id = F.CompanyId " +
                                  "left outer join Proced PR on PR.Id = F.ProcedId " +
                                  "left outer join [dbo].[Protok] P on P.FolderId = F.Id and isnull(P.deleted, 0) = 0 and isnull(P.updated, 0) = 0 " +
                                  selectStatement_where_part +

                                  " and C.id in (" + UserInfo.CompaniesAsCsvString + ") " +

                              "GROUP BY C.Name, PR.Name, F.Name, F.Descr, F.Id " +
                              selectStatement_having_part + 
                              "ORDER BY F.Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = { reader[5].ToString(), //id
                                     reader[0].ToString(), //
                                     reader[1].ToString(), //com
                                     reader[2].ToString(), //proced
                                     reader[3].ToString(), //
                                     reader[4].ToString()};

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
            //string lvRowCnt = lvRep.SelectedItems[0].SubItems[4].Text;
            //string lvRowFolder = lvRep.SelectedItems[0].SubItems[2].Text;
            string lvRowId = lvRep.SelectedItems[0].SubItems[0].Text; //5
            string lvRowEisEx = lvRep.SelectedItems[0].SubItems[3].Text; //2
            string lvRowCompany = lvRep.SelectedItems[0].SubItems[2].Text; //1

            //ListViewItem.ListViewSubItemCollection lvic = new ListViewItem.ListViewSubItemCollection(lvRep.SelectedItems[0]);

            FoldersInsertForm updScreen = new FoldersInsertForm(new Company { Name = lvRowCompany }, new Proced { Name = lvRowEisEx });

            updScreen.Text = "Εμφάνιση";
            //updScreen.btnInsert.Text = "Μεταβολή";
            updScreen.lblId.Visible = true;
            updScreen.txtId.Visible = true;
            //updScreen.txtId.Enabled = false;
            updScreen.txtId.Text = lvRowId;

            updScreen.txtName.Text = lvRep.SelectedItems[0].SubItems[1].Text; //2??
            updScreen.txtDescr.Text = lvRep.SelectedItems[0].SubItems[4].Text; //3

            updScreen.btnInsert.Enabled = false;
            updScreen.txtName.ReadOnly = true;
            updScreen.txtName.BackColor = Color.White;
            updScreen.txtDescr.ReadOnly = true;
            updScreen.txtDescr.BackColor = Color.White;

            updScreen.ShowDialog();

            //select mode(!) - don't refresh listview
            //lvRep.Items.Clear();
            //ShowDataToListView(lvRep);
        }

        FoldersFiltersForm FiltersFrm;
        private void btnFilters_Click(object sender, EventArgs e)
        {
            if (FiltersFrm == null)//first time
            {
                FiltersFrm = new FoldersFiltersForm(); // ("WHERE month(P.DocumentGetSetDate) = month(getdate()) and isnull(P.deleted, 0) = 0 ");
                //set initial values
                FiltersFrm.savedFilters.Clear();//not needed right now
            }
            else //change filters
            {
                FiltersFrm.saveFilters = false;

                List<Filter> SavedControls = FiltersFrm.savedFilters;
                string SavedWhereStr = FiltersFrm.whereStr;
                string SavedHavingStr = FiltersFrm.havingStr;

                FiltersFrm = new FoldersFiltersForm();
                FiltersFrm.savedFilters = SavedControls;
                FiltersFrm.whereStr = SavedWhereStr;
                FiltersFrm.havingStr = SavedHavingStr;
            }

            FiltersFrm.JoinFiltersWithControls();

            FiltersFrm.ShowDialog();

            if (FiltersFrm.saveFilters == true)
            {
                btnFilters.Font = new Font(btnFilters.Font, FontStyle.Underline);

                FiltersFrm.saveFilters = false;

                ShowDataToListView(lvRep, FiltersFrm.whereStr, FiltersFrm.havingStr);
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            if (FiltersFrm != null)
            {
                FiltersFrm.savedFilters.Clear();//not needed right now

                //set where... 
                FiltersFrm.whereStr = " WHERE 1=1 ";
                FiltersFrm.havingStr = "";

                btnFilters.Font = new Font(btnFilters.Font, FontStyle.Regular);

                ShowDataToListView(lvRep, FiltersFrm.whereStr, FiltersFrm.havingStr);
            }
        }
    }
}
