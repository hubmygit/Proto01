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
            }
        }

        private void btnSaveFilters_Click(object sender, EventArgs e)
        {
            saveFilters = true;

            //savedFilters.Clear();//not needed right now
            //
            //foreach( in Controls)
            //
            savedFilters.Add(new Filter("chbDeleted", chbDeleted.Checked.ToString()));
            savedFilters.Add(new Filter("dtpGetSetDate_From", dtpGetSetDate_From.Value.ToString("yyyyMMdd")));
            savedFilters.Add(new Filter("dtpGetSetDate_To", dtpGetSetDate_To.Value.ToString("yyyyMMdd")));

            //where
            whereStr = "set new WHERE here...";

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

        public Filter(string fieldName, string fieldValue, Control fieldControl)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            FieldControl = fieldControl;
        }

        public Control FieldControl { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

    }
}
