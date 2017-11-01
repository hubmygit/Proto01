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
    public partial class ProtokFiltersForm : Form
    {
        public ProtokFiltersForm()
        {
            InitializeComponent();

            //cbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
            //cbProced.Items.AddRange(ProtokoloInsertForm.GetObjProtocolKind());

            chlbProced.Items.AddRange(ProtokoloInsertForm.GetObjProtocolKind());
            chlbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
            chlbFolder.Items.AddRange(ProtokoloInsertForm.GetObjFolders());
        }

        public bool saveFilters = false;
        public List<Filter> savedFilters = new List<Filter>();
        public string whereStr;

        //public ProtokFiltersForm(string initialWhere)
        //{
        //    InitializeComponent();

            //saved filters ->to controls
            //JoinFiltersWithControls();
            
            //cbCompany.Items.AddRange(ProtokoloInsertForm.GetObjCompanies());
            //cbProced.Items.AddRange(ProtokoloInsertForm.GetObjProtocolKind());
        //}

        public void JoinFiltersWithControls()
        {
            foreach (Filter thisFilter in savedFilters)
            {
                if (thisFilter.FieldName == "chbDeleted")
                {
                    chbDeleted.Checked = Convert.ToBoolean(thisFilter.FieldValue);
                    continue;
                }
                if (thisFilter.FieldName == "dtpGetSetDate_From")
                {
                    dtpGetSetDate_From.Value = Convert.ToDateTime(thisFilter.FieldValue);
                    continue;
                }
                if (thisFilter.FieldName == "dtpGetSetDate_To")
                {
                    dtpGetSetDate_To.Value = Convert.ToDateTime(thisFilter.FieldValue);
                    continue;
                }
                /*
                if (thisFilter.FieldName == "chlbProced")
                {
                    foreach (ComboboxItem cbiStr in thisFilter.FieldMultipleComboBoxItems)
                    {
                        chlbProced.SetItemChecked(chlbProced.Items.IndexOf(cbiStr), true);
                    }
                    continue;
                }
                */
                if (thisFilter.FieldName == "chlbProced")
                {
                    Set_CheckedListBox_Checked_Indexes(chlbProced, thisFilter.FieldCheckedIndexes);
                    continue;
                }

                /*
                if (thisFilter.FieldName == "chlbCompany")
                {
                    foreach (ComboboxItem cbiStr in thisFilter.FieldMultipleComboBoxItems)
                    {
                        chlbCompany.SetItemChecked(chlbCompany.Items.IndexOf(cbiStr), true);
                    }
                    continue;
                }
                */
                if (thisFilter.FieldName == "chlbCompany")
                {
                    Set_CheckedListBox_Checked_Indexes(chlbCompany, thisFilter.FieldCheckedIndexes);
                    continue;
                }

                if (thisFilter.FieldName == "dtp_DocDate_From")
                {
                    dtp_DocDate_From.Value = Convert.ToDateTime(thisFilter.FieldValue);
                    continue;
                }
                if (thisFilter.FieldName == "dtp_DocDate_To")
                {
                    dtp_DocDate_To.Value = Convert.ToDateTime(thisFilter.FieldValue);
                    continue;
                }
                if (thisFilter.FieldName == "txtProelKateuth")
                {
                    txtProelKateuth.Text = thisFilter.FieldValue;
                    continue;
                }
                if (thisFilter.FieldName == "txtSummary")
                {
                    txtSummary.Text = thisFilter.FieldValue;
                    continue;
                }
                if (thisFilter.FieldName == "txtDocNum")
                {
                    txtDocNum.Text = thisFilter.FieldValue;
                    continue;
                }
                if (thisFilter.FieldName == "txtToText")
                {
                    txtToText.Text = thisFilter.FieldValue;
                    continue;
                }
                /*
                if (thisFilter.FieldName == "chlbFolder")
                {
                    foreach (ComboboxItem cbiStr in thisFilter.FieldMultipleComboBoxItems)
                    {
                        chlbFolder.SetItemChecked(chlbFolder.Items.IndexOf(cbiStr), true);
                    }
                    continue;
                }
                */
                if (thisFilter.FieldName == "chlbFolder")
                {
                    Set_CheckedListBox_Checked_Indexes(chlbFolder, thisFilter.FieldCheckedIndexes);
                    continue;
                }

                if (thisFilter.FieldName == "txtSn")
                {
                    txtSn.Text = thisFilter.FieldValue;
                    continue;
                }
                if (thisFilter.FieldName == "chbHasAtt")
                {
                    chbHasAtt.Checked = Convert.ToBoolean(thisFilter.FieldValue);
                    continue;
                }
                if (thisFilter.FieldName == "chbMailSent")
                {
                    chbMailSent.Checked = Convert.ToBoolean(thisFilter.FieldValue);
                    continue;
                }


            }
        }

        public static List<int> Get_CheckedListBox_Checked_Indexes(CheckedListBox clb)
        {
            List<int> IndexesList = new List<int>();

            int clbItemsCounter = clb.Items.Count;

            for (int i = 0; i < clbItemsCounter; i++)
            {
                if (clb.GetItemCheckState(i) == CheckState.Checked)
                {
                    IndexesList.Add(i);
                }
            }

            return IndexesList;
        }

        public static List<string> Get_CheckedListBox_Checked_Values(CheckedListBox clb)
        {
            List<string> ValuesList = new List<string>();

            int clbItemsCounter = clb.Items.Count;

            for (int i = 0; i < clbItemsCounter; i++)
            {
                if (clb.GetItemCheckState(i) == CheckState.Checked)
                {
                    ValuesList.Add(clb.Items[i].ToString());
                }
            }

            return ValuesList;
        }

        public static void Set_CheckedListBox_Checked_Indexes(CheckedListBox clb, int[] Indexes)
        {
            //SetItemCheckState
            for (int i = 0; i<Indexes.Length; i++)
            {
                clb.SetItemChecked(Indexes[i], true);
            }
        }

        public bool isCheckedListBoxItemChecked(CheckedListBox clb, string strToSearch)
        {
            bool ret = false;
            
            int clbItemsCounter = clb.Items.Count;

            for (int i = 0; i < clbItemsCounter; i++)
            {
                if (((ComboboxItem)clb.Items[i]).Text == strToSearch && clb.GetItemCheckState(i) == CheckState.Checked)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        private void btnSaveFilters_Click(object sender, EventArgs e)
        {
            saveFilters = true;

            savedFilters.Clear();//not needed right now
            whereStr = "WHERE ";

            savedFilters.Add(new Filter("chbDeleted", chbDeleted.Checked.ToString()));
            whereStr += " isnull(P.deleted, 0) = " + Convert.ToInt32(chbDeleted.Checked);

            savedFilters.Add(new Filter("chbUpdated", chbUpdated.Checked.ToString()));
            whereStr += " isnull(P.updated, 0) = " + Convert.ToInt32(chbUpdated.Checked);

            savedFilters.Add(new Filter("dtpGetSetDate_From", dtpGetSetDate_From.Value.ToString("dd-MM-yyyy")));
            savedFilters.Add(new Filter("dtpGetSetDate_To", dtpGetSetDate_To.Value.ToString("dd-MM-yyyy")));
            //whereStr += " AND P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
            //                         "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' ";
            whereStr += " AND P.DocumentGetSetDate between '" + dtpGetSetDate_From.Value.ToString("yyyyMMdd") +
                                     "' and '" + dtpGetSetDate_To.Value.ToString("yyyyMMdd") + "' ";

            /*
            List<ComboboxItem> CheckedItems = new List<ComboboxItem>();
            string whereItems = "";
            foreach (ComboboxItem thisItem in chlbProced.CheckedItems)
            {
                CheckedItems.Add(thisItem);
                //whereItems += ("'" + thisItem.Text + "',");
                whereItems += ((Proced)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);

                savedFilters.Add(new Filter("chlbProced", CheckedItems.ToArray<ComboboxItem>()));
                //whereStr += " AND PR.Name in (" + whereItems + ") ";
                whereStr += " AND P.ProcedureId in (" + whereItems + ") ";
            }
            */
            List<int> CheckedIndexes = new List<int>();
            CheckedIndexes = Get_CheckedListBox_Checked_Indexes(chlbProced);

            List<string> CheckedValues = new List<string>();
            CheckedValues = Get_CheckedListBox_Checked_Values(chlbProced);

            string whereItems = "";
            foreach (ComboboxItem thisItem in chlbProced.CheckedItems)
            {
                whereItems += ((Proced)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);
                savedFilters.Add(new Filter("chlbProced", CheckedIndexes.ToArray<int>(), CheckedValues.ToArray<string>()));
                whereStr += " AND P.ProcedureId in (" + whereItems + ") ";
            }

            /*
            CheckedItems = new List<ComboboxItem>();
            whereItems = "";
            foreach (ComboboxItem thisItem in chlbCompany.CheckedItems)
            {
                CheckedItems.Add(thisItem);
                //whereItems += ("'" + thisItem.Text + "',");
                whereItems += ((Company)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);

                savedFilters.Add(new Filter("chlbCompany", CheckedItems.ToArray<ComboboxItem>()));
                //whereStr += " AND C.Name in (" + whereItems + ") ";
                whereStr += " AND P.CompanyId in (" + whereItems + ") ";
            }
            */
            CheckedIndexes = Get_CheckedListBox_Checked_Indexes(chlbCompany);
            CheckedValues = Get_CheckedListBox_Checked_Values(chlbCompany);
            whereItems = "";
            foreach (ComboboxItem thisItem in chlbCompany.CheckedItems)
            {
                whereItems += ((Company)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);
                savedFilters.Add(new Filter("chlbCompany", CheckedIndexes.ToArray<int>(), CheckedValues.ToArray<string>()));
                whereStr += " AND P.CompanyId in (" + whereItems + ") ";
            }

            savedFilters.Add(new Filter("dtp_DocDate_From", dtp_DocDate_From.Value.ToString("dd-MM-yyyy")));
            savedFilters.Add(new Filter("dtp_DocDate_To", dtp_DocDate_To.Value.ToString("dd-MM-yyyy")));
            if (isCheckedListBoxItemChecked(chlbProced, "Εισερχόμενα") == false && isCheckedListBoxItemChecked(chlbProced, "Εξερχόμενα") == true)
            {
                //don't print filters
            }
            else
            {
                //only inbox can filter this field            
                whereStr += " AND isnull(P.DocumentDate, '" + dtp_DocDate_From.Value.ToString("yyyyMMdd") + "') between '" + dtp_DocDate_From.Value.ToString("yyyyMMdd") +
                                             "' and '" + dtp_DocDate_To.Value.ToString("yyyyMMdd") + "' ";
            }

            if (txtProelKateuth.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtProelKateuth", txtProelKateuth.Text));
                whereStr += " AND P.ProeleusiKateuth like '%" + txtProelKateuth.Text + "%' ";
            }
            if (txtSummary.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtSummary", txtSummary.Text));
                whereStr += " AND P.Summary like '%" + txtSummary.Text + "%' ";
            }
            if (txtDocNum.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtDocNum", txtDocNum.Text));
                whereStr += " AND P.DocumentNumber like '%" + txtDocNum.Text + "%' ";
            }
            if (txtToText.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtToText", txtToText.Text));
                whereStr += " AND P.ToText like '%" + txtToText.Text + "%' ";
            }

            /*
            CheckedItems = new List<ComboboxItem>();
            whereItems = "";
            foreach (ComboboxItem thisItem in chlbFolder.CheckedItems)
            {
                CheckedItems.Add(thisItem);
                //whereItems += ("'" + thisItem.Text + "',");
                whereItems += ((Folders)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);

                savedFilters.Add(new Filter("chlbFolder", CheckedItems.ToArray<ComboboxItem>()));
                //whereStr += " AND F.Name in (" + whereItems + ") ";
                whereStr += " AND P.FolderId in (" + whereItems + ") ";
            }
            */
            CheckedIndexes = Get_CheckedListBox_Checked_Indexes(chlbFolder);
            CheckedValues = Get_CheckedListBox_Checked_Values(chlbFolder);
            whereItems = "";
            foreach (ComboboxItem thisItem in chlbFolder.CheckedItems)
            {
                whereItems += ((Folders)thisItem.Value).Id + ",";
            }
            if (whereItems.Length > 0)
            {
                whereItems = whereItems.Substring(0, whereItems.Length - 1);
                savedFilters.Add(new Filter("chlbFolder", CheckedIndexes.ToArray<int>(), CheckedValues.ToArray<string>()));
                whereStr += " AND P.FolderId in (" + whereItems + ") ";
            }

            if (txtSn.Text.Trim() != "")
            {
                savedFilters.Add(new Filter("txtSn", txtSn.Text));
                whereStr += " AND P.Sn = " + txtSn.Text + " ";
            }

            if (chbHasAtt.Checked)
            {
                savedFilters.Add(new Filter("chbHasAtt", chbHasAtt.Checked.ToString()));
                whereStr += " AND (select count(*) from [dbo].[ProtokPdf] PA where PA.ProtokId = P.id) > 0 ";
            }

            if (chbMailSent.Checked)
            {
                savedFilters.Add(new Filter("chbMailSent", chbMailSent.Checked.ToString()));
                whereStr += " AND (select count(*) from [dbo].[ReceiverList] RL where RL.ProtokId = P.id) > 0 ";
            }

            saveFilters = true;
            Close();
        }

        private void txtSn_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    public class Filter
    {
        public Filter()
        {

        }

        public Filter(Control fieldControl)
        {
            FieldControl = fieldControl;
        }

        public Filter(string fieldName, string fieldValue)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }

        public Filter(string fieldName, string[] fieldMultipleValues)
        {
            FieldName = fieldName;
            FieldMultipleValues = fieldMultipleValues;
        }
        public Filter(string fieldName, ComboboxItem[] fieldMultipleComboBoxItems)
        {
            FieldName = fieldName;
            FieldMultipleComboBoxItems = fieldMultipleComboBoxItems;
        }

        public Filter(string fieldName, int[] fieldCheckedIndexes, string[] fieldCheckedValues)
        {
            FieldName = fieldName;
            FieldCheckedIndexes = fieldCheckedIndexes;
            FieldCheckedValues = fieldCheckedValues;
        }

        public Filter(string fieldName, string fieldValue, Control fieldControl)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            FieldControl = fieldControl;
        }

        public Control FieldControl { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string[] FieldMultipleValues { get; set; }
        public ComboboxItem[] FieldMultipleComboBoxItems { get; set; }
        public int[] FieldCheckedIndexes { get; set; }

        public string[] FieldCheckedValues { get; set; }
    }
}
