using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Protocol
{
    class excelForms
    {
        public excelForms()
        {
            excelApplication = new Excel.Application();
            //excelApplication.Visible = true;
            wbk = excelApplication.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            wsh = (Excel.Worksheet)excelApplication.ActiveSheet;
        }

        private Excel.Workbook wbk;
        private Excel.Application excelApplication;
        private Excel.Worksheet wsh;

        public bool Visible
        {
            get { return excelApplication.Visible; }
            set { excelApplication.Visible = value; }
        }

        public void ExportListViewToExcel(ListView lv, bool showHeaders)
        {
            int i = 1;
            int j = 1;

            if (showHeaders)
            {
                foreach (ColumnHeader ch in lv.Columns)
                {
                    wsh.Cells[i, j] = ch.Text;
                    j++;
                }
                j = 1;
                i++;
            }

            foreach (ListViewItem comp in lv.Items)
            {
                wsh.Cells[i, j] = comp.Text;

                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {
                    wsh.Cells[i, j] = drv.Text;
                    j++;
                }

                j = 1;
                i++;
            }            
        }
    }
}
