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
    public partial class Contacts : Form
    {
        List<SavedDatasources> LstSDS;
        bool InsertState;
        public List<String> ReturnEmailList;
        public Contacts()
        {
            InitializeComponent();
            SetMenuState("Browse");
            UpdateHeader(dataGridView1);
            tabControl1.ItemSize = new System.Drawing.Size(1, 1);

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            viewDistCompanyTableAdapter.Fill(this._GramV3_DevDataSet_Contact.ViewDistCompany);
            foreach (DataRow Nam in this._GramV3_DevDataSet_Contact.ViewDistCompany.Rows)
            {
                col.Add((String)Nam[0]);
            }

            SearchText2.AutoCompleteCustomSource = col;
            textBoxCompany.AutoCompleteCustomSource = col;
            textSelectedMails.Visible = false;

            LstSDS = new List<SavedDatasources>();
            StoreBinding();
        }
        public Contacts(string DummyState):this()
        {

            if ((ReturnEmailList is null) || (ReturnEmailList.Count == 0))
            {
                ReturnEmailList = new List<String>();
            }
            dataGridView1.MultiSelect = true;
            textSelectedMails.Visible = true;
            SetMenuState("Selection");
            textSelectedMails.Visible = true;
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_GramV3_DevDataSet_Contact.Contacts' table. You can move, or remove it, as needed.
            this.contactsTableAdapter.Fill(this._GramV3_DevDataSet_Contact.Contacts);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFilter a = new frmFilter();
            a.PopulateForm(dataGridView1);
            a.Show();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertState = true;
            tabControl1.SelectedTab = tabPage2;
            SetMenuState("Update");
            ClearBinding();
        }
        private void updToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            SetMenuState("Update");
            RestoreBinding();
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label10.Focus();
            if (textFirstName.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Δεν έχει γίνει καταχώρηση στο πεδίο");
                textFirstName.Focus();
                return;
            }

            if (textLastName.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Δεν έχει γίνει καταχώρηση στο πεδίο");
                textLastName.Focus();
                return;
            }

            if (textemail.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Δεν έχει γίνει καταχώρηση στο πεδίο");
                textemail.Focus();
                return;
            }


            if (InsertState)
            {
                BindingSource bs = (BindingSource)dataGridView1.DataSource;
                DataSet dsTempDataTable = (DataSet)bs.DataSource;
                DataTable dt = dsTempDataTable.Tables[0]; // use table index/name to get the exact table
                DataRow dr = dt.NewRow();
                //DataRow NewRow = new Contacts.Rows.Add;

                foreach (SavedDatasources lsd in LstSDS)
                {
                    dr[lsd.DBField] = lsd.FormField.Text;
                    //                lsd.FormField.DataBindings.Add(lsd.BindingProc);
                }
                int NumId = GetTableKey("Contacts");
                dr["id"] = NumId;
                dt.Rows.Add(dr);
                contactsTableAdapter.Update(dr);
                RestoreBinding();
            }
            else
            {
                BindingSource bs = (BindingSource)dataGridView1.DataSource;
                DataSet dsTempDataTable = (DataSet)bs.DataSource;
                DataTable dt = dsTempDataTable.Tables[0]; // use table index/name to get the exact table

                foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
                {
                    //dt.Rows[drrow.Index]
                    contactsTableAdapter.Update(
                                                drrow.Cells["Company"].Value.ToString(),
                                                drrow.Cells["LastName"].Value.ToString(),
                                                drrow.Cells["FirstName"].Value.ToString(),
                                                drrow.Cells["email"].Value.ToString(),
                                                drrow.Cells["JobTitle"].Value.ToString(),
                                                drrow.Cells["BusinessPhone"].Value.ToString(),
                                                drrow.Cells["MobilePhone"].Value.ToString(),
                                                drrow.Cells["Address"].Value.ToString(),
                                                drrow.Cells["City"].Value.ToString(),
                                                drrow.Cells["ZIP"].Value.ToString(),
                                                drrow.Cells["Country"].Value.ToString(),
                                                drrow.Cells["Notes"].Value.ToString(),
                                                drrow.Cells["Category"].Value.ToString(),
                                                (int)drrow.Cells["Id"].Value);
                }

                //dataGridView1.CurrentRow["id"];

                //BindingSource bs = (BindingSource)dataGridView1.DataSource;
                //DataSet dsTempDataTable = (DataSet)bs.DataSource;
                //DataTable dt = dsTempDataTable.Tables[0]; // use table index/name to get the exact table
                //string aaaa = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                //DataRow dr = dt.NewRow();
                //dr = ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row;
                //dr["id"] = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                //DRV.Row;
                //contactsTableAdapter.Update(dr);
                //dt.AcceptChanges();

                //foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                //{
                //datar = dt.Rows[dr.Index];
                //contactsTableAdapter.Update(datar);
                //}

            }

            tabControl1.SelectedTab = tabPage1;
            SetMenuState("Browse");
            InsertState = false;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            SetMenuState("Browse");
            RestoreBinding();
            InsertState = false;
        }
        private void ClearBinding()
        {
            SavedDatasources sds;

            int x111 = tabControl1.SelectedTab.Controls.Count;
            foreach (Control x in tabControl1.SelectedTab.Controls)
            {
                if (x is TextBox)
                {
                    BindingSource a = (BindingSource)x.DataBindings[0].DataSource;
                    Binding bss = x.DataBindings[0];

                    //                    sds = new SavedDatasources(
                    //                        bss.BindingMemberInfo.BindingField.ToString(), x, bss);
                    //                    LstSDS.Add(sds);

                    //                    MessageBox.Show(bss.BindingMemberInfo.BindingField.ToString());
                    //                    MessageBox.Show(bss.BindingMemberInfo.BindingMember.ToString());
                    //                    MessageBox.Show(bss.BindingMemberInfo.BindingPath.ToString());
                    DataSet ds = (DataSet)a.DataSource;
                    //                    MessageBox.Show(ds.DataSetName);
                    x.DataBindings.Clear();
                    x.Text = "";
                }
            }
        }

        private void StoreBinding()
        {
            SavedDatasources sds;

            int x111 = tabPage2.Controls.Count;
            //MessageBox.Show(x111.ToString());
            foreach (Control x in tabPage2.Controls)
            {
                if (x is TextBox)
                {
                    BindingSource a = (BindingSource)x.DataBindings[0].DataSource;
                    Binding bss = x.DataBindings[0];

                    sds = new SavedDatasources(
                        bss.BindingMemberInfo.BindingField.ToString(), x, bss);
                    LstSDS.Add(sds);
                }
            }
        }

        private void RestoreBinding()
        {
            foreach (SavedDatasources lsd in LstSDS)
            {
                lsd.FormField.DataBindings.Clear();
                lsd.FormField.DataBindings.Add(lsd.BindingProc);
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String aaa;
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            //MessageBox.Show(ff.Name);

            frmFilter a = new frmFilter();
            a.PopulateForm((DataGridView)ff);
            a.ShowDialog();
            aaa=a.KSleo;
            BindingSource BS = (BindingSource)((DataGridView)ff).DataSource;
            if (BS.Filter is null )
                BS.Filter = aaa;
            else
                BS.Filter = BS.Filter + aaa;
        }

       private void button2_Click(object sender, EventArgs e)
        {
/*                        using Microsoft.Office.Interop 
                                    Excel.Application xlApp;
                                    Excel.Workbook xlWorkBook;
                                    Excel.Worksheet xlWorkSheet;
                                    object misValue = System.Reflection.Missing.Value;

                                    xlApp = new Excel.ApplicationClass();
                                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                                    xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";

                                    xlWorkBook.SaveAs("csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                                    xlWorkBook.Close(true, misValue, misValue);
                                    xlApp.Quit();

                                    releaseObject(xlWorkSheet);
                                    releaseObject(xlWorkBook);
                                    releaseObject(xlApp);

                                    MessageBox.Show("Excel file created , you can find the file c:\\csharp-Excel.xls");
            private void button1_Click_1(object sender, EventArgs e)
            {*/
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                //app.Visible = false;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                workbook.SaveAs("Leooutput1.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Visible = true;
            //app.Quit();
            /*                 }
    }


                            private void releaseObject(object obj)
                            {
                                try
                                {
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                                    obj = null;
                                }
                                catch (Exception ex)
                                {
                                    obj = null;
                                    MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                                }
                                finally
                                {
                                    GC.Collect();
                                }*/
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void filterOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            BindingSource BS = (BindingSource)dataGridView1.DataSource;
            BS.Filter = "";

        }

        private void filterExactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            BindingSource BS = (BindingSource)((DataGridView)ff).DataSource;

            int ro =((DataGridView)ff).CurrentCell.RowIndex;
            int co = ((DataGridView)ff).CurrentCell.ColumnIndex;
            string txt = ((DataGridView)ff).CurrentCell.Value.ToString();


            if (BS.Filter is null)
                BS.Filter = ((DataGridView)ff).Columns[co].DataPropertyName.ToString() + " = '" + txt + "'";
            else
                BS.Filter = ((DataGridView)ff).Columns[co].DataPropertyName.ToString() + " = '" + txt + "'";

        }

        private void export2ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            //app.Visible = false;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("Leooutput.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Visible = true;
            app.Quit();
        }

        private BindingSource ReturnBindingSourceMenu(object sender)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            BindingSource BS = (BindingSource)((DataGridView)ff).DataSource;
            return BS;
        }
        private DataGridView ReturnDataGridViewMenu(object sender)
        {
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            var Par = (ContextMenuStrip)Tsmi.GetCurrentParent();
            Control ff = Par.SourceControl;
            DataGridView DGV = (DataGridView)ff;
            return DGV;
        }

        private void SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UpdateHeader(DataGridView Dgv)
        {
            BindingSource bs = (BindingSource)dataGridView1.DataSource;
            DataSet dsTempDataTable = (DataSet)bs.DataSource;
            DataTable dt = dsTempDataTable.Tables[0]; // use table index/name to get the exact table
            int a = 1;
            foreach (DataColumn dc in dt.Columns)
            {
                foreach (DataGridViewColumn gc in dataGridView1.Columns)
                 if (gc.DataPropertyName == dc.ColumnName)
                    {
                        gc.HeaderText = dc.Caption.ToString();
                        gc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    }


            }
        }

        private void SearchText_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "SearchText0")
            {
                if (this.SearchText1.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText1.Select();
                        }
                if (this.SearchText2.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText2.Select();
                }
                if (this.SearchText3.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText3.Select();
                }
            }
            if (((TextBox)sender).Name == "SearchText1")
            {
                if (this.SearchText0.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText0.Select();
                }
                if (this.SearchText2.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText2.Select();
                }
                if (this.SearchText3.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText3.Select();
                }
            }
            if (((TextBox)sender).Name == "SearchText2")
                {
                    if (this.SearchText1.Text.Trim().Length > 0)
                    {
                        MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                        this.SearchText1.Select();
                    }
                    if (this.SearchText0.Text.Trim().Length > 0)
                    {
                        MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                        this.SearchText0.Select();
                    }
                if (this.SearchText3.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText3.Select();
                }

            }
            if (((TextBox)sender).Name == "SearchText3")
            {
                if (this.SearchText0.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText0.Select();
                }
                if (this.SearchText2.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText2.Select();
                }
                if (this.SearchText1.Text.Trim().Length > 0)
                {
                    MessageBox.Show("Υπάρχει καταχώσηση σε άλλο πεδίο εύρεσης");
                    this.SearchText1.Select();
                }
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public int GetTableKey(string TableName)
        { 
         int NewId = 0;
         /*string constr = "Data Source = MSSQL1;Password=8093570;Persist Security Info=True;User ID=GramV3; Initial Catalog=GramV3-Dev;Data Source=avindomc\\sqlserverr2;Initial File Name=''";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = constr;
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateKey", con);

                cmd.Parameters.Add(new SqlParameter("@TableName", "Contacts"));
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MessageBox.Show(rdr[2].ToString());
                    NewId = (int)rdr[2];
                    //Console.WriteLine("Product: {0,-35} Total: {1,12} Total2: {1,12}", rdr[1], rdr[2], rdr[2]);
                }
            */

           updateKeyTableAdapter.Fill(this._GramV3_DevDataSet_Contact.UpdateKey, "Contacts");
           NewId = (int)this._GramV3_DevDataSet_Contact.UpdateKey.Rows[0][2];

            return NewId;
           
         }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingSource bs = (BindingSource)dataGridView1.DataSource;
            DataSet dsTempDataTable = (DataSet)bs.DataSource;
            DataTable dt = dsTempDataTable.Tables[0];
            DataRow   datar;
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                datar = dt.Rows[dr.Index];
                contactsTableAdapter.Delete((int)datar["id"]);
                dt.Rows.Remove(datar);
            }
        }

        private void επιλογήToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((ReturnEmailList is null) ||  (ReturnEmailList.Count == 0))
            { 
               ReturnEmailList = new List<String>();
            }
            dataGridView1.MultiSelect = true;
            textSelectedMails.Visible = true;
            SetMenuState("Selection");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(ReturnEmailList is null))
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    String ro = dr.Cells["email"].Value.ToString();
                    if (ro.Trim().Length < 1)
                    {
                        MessageBox.Show("Η επαφή " + dr.Cells["LastName"].Value.ToString() + " " + dr.Cells["FirstName"].Value.ToString() + " δεν έχει διεύθυνση email.");
                    }
                    else
                    {
                        ReturnEmailList.Add(ro.ToString());
                        //MessageBox.Show(dr.Cells["LastName"].Value.ToString()+" "+ dr.Cells["FirstName"].Value.ToString());
                    }
                }
                    textSelectedMails.Text = string.Join(",", ReturnEmailList);
                this.Text = "Διευθυνσιογράφος (" + ReturnEmailList.Count.ToString()+")" ;
                }
            

        }

        private void επιλεγμέναToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Join(",", ReturnEmailList);
            MessageBox.Show(string.Join(",", ReturnEmailList)); 
            //foreach (String a in ReturnEmailList)
            //{ MessageBox.Show(a); }
        }


        public List<Control> GetAllControls(Control searchWithin, List<Control> returnList)
        {

            foreach (Control ctrlt in searchWithin.Controls)
            {
                if (ctrlt.HasChildren)
                    foreach (Control ctrl in ctrlt.Controls)
                        if (ctrl.HasChildren)
                            GetAllControls(ctrl, returnList);
                        else
                            returnList.Add(ctrl);
                else //if searchWithin.HasChildren = False Then
                    foreach (Control ctrl in ctrlt.Controls)
                        returnList.AddRange(GetAllControls(ctrl, returnList));
            }
            return returnList;
        }


        private void SetMenuState(string TagState)
        {
            List<Control> FormControls = new List<Control>();

            FormControls = GetAllControls(this, FormControls);
            foreach (Control c in FormControls)
                {
                    if (c.GetType().Name.ToUpper() == "MENUSTRIP")
                      foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStrip)c).Items)
                    if (item.Tag.ToString().ToUpper() == TagState.ToUpper())
                            item.Visible = true;
                    else
                            item.Visible = false;
                }
        }

        private void έξοδοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            textSelectedMails.Visible = false;
            SetMenuState("Browse");
        }

        private void SearchTextKeyDown(object sender, KeyEventArgs e)
        {
            BindingSource BS = (BindingSource)(dataGridView1).DataSource;
            String LikeStr = ((TextBox)sender).Tag.ToString();

            if (((TextBox)sender).Text.Trim().Length > 0)
            {
                BS.Filter = LikeStr + " Like '" + ((TextBox)sender).Text.Trim() + "%'";
            }
            else
            {
                BS.Filter = "";
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
