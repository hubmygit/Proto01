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
                }
                if (thisFilter.FieldName == "dtpGetSetDate_From")
                {
                    dtpGetSetDate_From.Value = Convert.ToDateTime(thisFilter.FieldValue);
                }
                if (thisFilter.FieldName == "dtpGetSetDate_To")
                {
                    dtpGetSetDate_To.Value = Convert.ToDateTime(thisFilter.FieldValue);
                }
                if (thisFilter.FieldName == "chlbProced")
                {
                    foreach (string str in thisFilter.FieldMultipleValues)
                    {
                        int error = chlbProced.Items.IndexOf(str);
                        ComboboxItem cbi = new ComboboxItem();
                        cbi.Text = str;
                        Proced proced = new Proced();
                        proced.Id = 0; //??????????????????????????????????
                        proced.Name = str;
                        cbi.Value = proced;
                        chlbProced.SetItemChecked(chlbProced.Items.IndexOf(cbi), true);

                        //chlbProced.SetItemChecked(chlbProced.Items.IndexOf(str), true);

                        //or .... foreach(Proced pro in (Comboboxitem)chlbProced.Items)
                    }
                }
                if (thisFilter.FieldName == "chlbCompany")
                {
                    foreach (string str in thisFilter.FieldMultipleValues)
                    {
                        chlbProced.SetItemChecked(chlbCompany.Items.IndexOf(str), true);
                    }
                }
            }
        }

        private void btnSaveFilters_Click(object sender, EventArgs e)
        {
            saveFilters = true;

            savedFilters.Clear();//not needed right now
            whereStr = "WHERE ";

            //foreach( in Controls)
            savedFilters.Add(new Filter("chbDeleted", chbDeleted.Checked.ToString()));
            whereStr += " isnull(P.deleted, 0) = 0 ";

            savedFilters.Add(new Filter("dtpGetSetDate_From", dtpGetSetDate_From.Value.ToString("dd-MM-yyyy")));
            savedFilters.Add(new Filter("dtpGetSetDate_To", dtpGetSetDate_To.Value.ToString("dd-MM-yyyy")));
            whereStr += " AND P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
                                     "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' ";

            List<string> checkedItems = new List<string>();
            string whereItems = "";
            foreach (ComboboxItem thisItem in chlbProced.CheckedItems)
            {
                checkedItems.Add(thisItem.Text);
                whereItems += ("'" + thisItem.Text + "',");
            }
            whereItems = whereItems.Substring(0, whereItems.Length - 1);
            savedFilters.Add(new Filter("chlbProced", checkedItems.ToArray()));
            whereStr += " AND PR.Name in (" + whereItems + ") ";




            //if (Control.Text.Trim() != "") ...




            //whereStr = "WHERE P.DocumentGetSetDate between '" + new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyyMMdd") +
            //                          "' and '" + new DateTime(DateTime.Now.Year, 12, 31).ToString("yyyyMMdd") + "' and isnull(P.deleted, 0) = 0 ";


            saveFilters = true;
            Close();
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

        public Filter(string fieldName, string fieldValue, Control fieldControl)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            FieldControl = fieldControl;
        }

        public Control FieldControl { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string [] FieldMultipleValues { get; set; }

    }
}
