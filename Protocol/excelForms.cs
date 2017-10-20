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
            try
            {
                excelApplication = new Excel.Application();
                //excelApplication.Visible = true; //delay...
                wbk = excelApplication.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
                wsh = (Excel.Worksheet)excelApplication.ActiveSheet;
            }
            catch (Exception ex)
            {
                ExcelExceptionMessage = "Παρουσιάστηκε πρόβλημα κατά το άνοιγμα της εφαρμογής 'Excel'! \r\nΠαρακαλώ ελέγξτε την εγκατάστασή σας...";

                MessageBox.Show(ExcelExceptionMessage + "\r\n\r\n\r\nΠληροφορίες Σφάλματος:\r\n\r\n" + ex.Message);
            }
        }

        private Excel.Workbook wbk;
        private Excel.Application excelApplication;
        private Excel.Worksheet wsh;

        public string ExcelExceptionMessage { get; set; }

        public bool Visible
        {
            get { return excelApplication.Visible; }
            set { excelApplication.Visible = value; }
        }

        public void ExportProtocolListViewToExcel(ListView lv, bool showHeaders, bool formatCellAsText)
        {
            int i = 1;
            int j = 1;

            string prefix = ""; //number as text
            if (formatCellAsText)
            {
                prefix = "'";
            }
            
            if (showHeaders)
            {
                foreach (ColumnHeader ch in lv.Columns)
                {
                    if (lv.Columns[0] == ch) //don't show id
                    {
                        continue;
                    }

                    wsh.Cells[i, j] = prefix + ch.Text;
                    
                    wsh.Cells[i, j].Font.Bold = true;
                    wsh.Cells[i, j].Interior.Color = System.Drawing.Color.LightGray;

                    //wsh.Cells[i, j].Font.Color = System.Drawing.Color.Blue;
                    //wsh.Cells[10, 1].EntireRow.Font.Bold = true;

                    j++;                    
                }
                j = 1;
                i++;
            }

            foreach (ListViewItem comp in lv.Items)
            {
                wsh.Cells[i, j] = prefix + comp.Text;

                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {
                    if (comp.SubItems[0] == drv) //don't show id
                    {
                        continue;
                    }

                    wsh.Cells[i, j] = prefix + drv.Text;
                    j++; 
                }

                j = 1;
                i++;
            }


            //column width
            //for (i = 1; i <= lv.Columns.Count; i++)
            //{
            //    wsh.Columns[i].ColumnWidth = 18;
            //}

            //wsh.Columns[1].ColumnWidth = 16;
            //wsh.Columns[2].ColumnWidth = 8;
            //wsh.Columns[3].ColumnWidth = 18;
            //wsh.Columns[4].ColumnWidth = 18;
            //wsh.Columns[5].ColumnWidth = 16;
            //wsh.Columns[6].ColumnWidth = 18;
            //wsh.Columns[7].ColumnWidth = 21;
            //wsh.Columns[8].ColumnWidth = 24;
            //wsh.Columns[9].ColumnWidth = 30;
            //wsh.Columns[10].ColumnWidth = 30;
            //wsh.Columns[11].ColumnWidth = 22;
            //wsh.Columns[12].ColumnWidth = 12;
            //wsh.Columns[13].ColumnWidth = 6;

            wsh.Columns[4].ColumnWidth = 16;
            wsh.Columns[2].ColumnWidth = 8;
            wsh.Columns[3].ColumnWidth = 18;
            wsh.Columns[1].ColumnWidth = 18;
            wsh.Columns[6].ColumnWidth = 16;
            wsh.Columns[5].ColumnWidth = 18;
            wsh.Columns[7].ColumnWidth = 21;
            wsh.Columns[8].ColumnWidth = 24;
            wsh.Columns[9].ColumnWidth = 30;
            wsh.Columns[10].ColumnWidth = 30;
            wsh.Columns[11].ColumnWidth = 22;
            wsh.Columns[12].ColumnWidth = 12;
            wsh.Columns[13].ColumnWidth = 6;

        }
    }

}

//How to use it...
/*
    excelForms eF = new excelForms();
    eF.ExportListViewToExcel(lvRep, true);
    eF.Visible = true; 
 */
