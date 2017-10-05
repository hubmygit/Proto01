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
    public partial class FoldersFiltersForm : Form
    {
        public FoldersFiltersForm()
        {
            InitializeComponent();

            chlbProced.Items.AddRange(ProtokoloInsertForm.GetObjProtocolKind());
            chlbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
        }

        public bool saveFilters = false;
        public List<Filter> savedFilters = new List<Filter>();
        public string whereStr;
        public string havingStr;
                
        public void JoinFiltersWithControls()
        {
            foreach (Filter thisFilter in savedFilters)
            {
                if (thisFilter.FieldName == "chlbProced")
                {
                    foreach (ComboboxItem cbiStr in thisFilter.FieldMultipleComboBoxItems)
                    {
                        chlbProced.SetItemChecked(chlbProced.Items.IndexOf(cbiStr), true);
                    }
                    continue;
                }
                if (thisFilter.FieldName == "chlbCompany")
                {
                    foreach (ComboboxItem cbiStr in thisFilter.FieldMultipleComboBoxItems)
                    {
                        chlbCompany.SetItemChecked(chlbCompany.Items.IndexOf(cbiStr), true);
                    }
                    continue;
                }
                if (thisFilter.FieldName == "txtDescr")
                {
                    txtDescr.Text = thisFilter.FieldValue;
                    continue;
                }
                if (thisFilter.FieldName == "txtFolderName")
                {
                    txtFolderName.Text = thisFilter.FieldValue;
                    continue;
                }
                if (thisFilter.FieldName == "chbHasProtocols")
                {
                    chbHasProtocols.Checked = Convert.ToBoolean(thisFilter.FieldValue);
                    continue;
                }

            }
        }

        private void btnSaveFilters_Click(object sender, EventArgs e)
        {
            saveFilters = true;

            savedFilters.Clear();//not needed right now
            whereStr = "WHERE 1=1 ";

            List<ComboboxItem> CheckedItems = new List<ComboboxItem>();
            string whereItems = "";
            foreach (ComboboxItem thisItem in chlbProced.CheckedItems)
            {
                CheckedItems.Add(thisItem);
                whereItems += ((Proced)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);

                savedFilters.Add(new Filter("chlbProced", CheckedItems.ToArray<ComboboxItem>()));
                whereStr += " AND F.ProcedId in (" + whereItems + ") ";
            }

            CheckedItems = new List<ComboboxItem>();
            whereItems = "";
            foreach (ComboboxItem thisItem in chlbCompany.CheckedItems)
            {
                CheckedItems.Add(thisItem);
                whereItems += ((Company)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);

                savedFilters.Add(new Filter("chlbCompany", CheckedItems.ToArray<ComboboxItem>()));
                whereStr += " AND F.CompanyId in (" + whereItems + ") ";
            }

            if (txtDescr.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtDescr", txtDescr.Text));
                whereStr += " AND F.Descr like '%" + txtDescr.Text + "%' ";
            }            
            if (txtFolderName.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtFolderName", txtFolderName.Text));
                whereStr += " AND F.Name = " + txtFolderName.Text;
            }
            if (chbHasProtocols.Checked)
            {
                savedFilters.Add(new Filter("chbHasProtocols", chbHasProtocols.Checked.ToString()));
                havingStr = " HAVING count(P.FolderId) > 0 ";
            }

            saveFilters = true;
            Close();
        }

    }

    
}
