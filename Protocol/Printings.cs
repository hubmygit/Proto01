﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Protocol
{
    class Printings
    {
        private int forCounter = 0;
        private int currentPage = 1;
        private int pageCount = 0;
        private ListView lvRep = new ListView();

        List<Filter> filterControls = new List<Filter>();

        

        public Printings()
        {
            //
        }

        

        public void printProtocols(ListView ProtocolsListView, List<Filter> savedFilterControls)
        {
            lvRep = ProtocolsListView;
            filterControls = savedFilterControls;

            if (lvRep.Items.Count <= 0)
            {
                MessageBox.Show("Δεν υπάρχουν εγγραφές για εκτύπωση!");
                return;
            }

            PrintDialog printDlg = new PrintDialog();
            PrintDocument document = new PrintDocument();
            document.DocumentName = "Print Protocol";

            document.PrintPage += new PrintPageEventHandler(this.Protocol_Document_PrintText);
            printDlg.Document = document;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                if (lvRep.Items.Count > 0)
                {
                    document.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    document.DefaultPageSettings.Landscape = true;

                    PrintController pCtrl = document.PrintController; //save controller
                    pageCount = GetPageCount(document); //changes controller - preview state / loses settings
                    document.PrintController = pCtrl; //get previous controller

                    document.Print();
                }
            }
        }

        private void Protocol_Document_PrintText(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;

            //*************Column Header Titles*************
            //ListViewItem lviColumnHeader = new ListViewItem(new string[] { "ΑΑ Πρωτ.", "Έτος", "Κατ.Πρωτοκ.", "Εταιρία", "Ημ/νία Έκδοσης", "Ημ.Λήψης/ Αποστολής", "Αρ.Εισερχ/ Σχετ.Αρ.",
            //    "Προέλευση/ Κατεύθυνση", "Περίληψη", "Παρ.για ενέργεια/ Παρατηρήσεις", "Αρ.Φακέλου Αρχείου", "Id", "Αρχεία", "Emails" });

            //ListViewItem lviColumnHeader = new ListViewItem(new string[] { "Id", "Εταιρία", "Έτος", "Κατ.Πρωτοκ.", "ΑΑ Πρωτ.", "Ημ.Λήψης/ Αποστολής", "Ημ/νία Έκδοσης", "Αρ.Εισερχ/ Σχετ.Αρ.",
            ListViewItem lviColumnHeader = new ListViewItem(new string[] { "Id", "Εταιρία", "Έτος", "Κατ.Πρωτοκ.", "ΑΑ Πρωτ.", "Ημ.Λήψης/ Αποστολής", "Ημ/νία Έκδοσης", "Αρ.Εισερχ. Εγγράφου",
                "Προέλευση/ Κατεύθυνση", "Περίληψη", "Παρ.για ενέργεια/ Παρατηρήσεις", "Αρ.Φακέλου Αρχείου", "Αρχεία", "Emails" });

            Graphics gf = e.Graphics;
            SizeF sf;

            Font HeaderFont = new Font("Arial", 9, FontStyle.Bold);
            Font myFont = new Font("Arial", 9);
            SolidBrush HeaderBackColor = new SolidBrush(Color.LightGray);

            float maxHeight = 0;
            List<float> lvWidth = new List<float>();
            List<float> lvHeight = new List<float>();

            float PageSpaceX = 16; //12
            float PageSpaceY = 82; //80
            float StartingPtX = 16; //12
            float StartingPtY = 92; //92
            float ptX = StartingPtX;
            float ptY = StartingPtY;


            
            //*************Header*************
            Font GeneralHeaderFont = new Font("Arial", 14, FontStyle.Bold);
            gf.DrawString("ΠΡΩΤΟΚΟΛΛΟ ΕΙΣΕΡΧΟΜΕΝΩΝ / ΕΞΕΡΧΟΜΕΝΩΝ ΕΓΓΡΑΦΩΝ", GeneralHeaderFont, Brushes.Brown, new Point(256, 38));

            //*************Filters*************
            if (currentPage == 1)
            {
                //if ( ((PrintDocument)sender).PrintController.IsPreview)
                //{

                FiltersToPrint PrintFilters = new FiltersToPrint(filterControls);

                string filterNames = "ΕΠΙΛΕΓΜΕΝΑ ΦΙΛΤΡΑ: \r\n\r\n" + PrintFilters.filterNames;
                string filterValues = "\r\n\r\n" + PrintFilters.filterValues;

                //string filtersToStr = "ΕΠΙΛΕΓΜΕΝΑ ΦΙΛΤΡΑ: \r\n\r\n" + 
                //                      filtersToString(filterControls);
                //    MessageBox.Show(filtersToStr);
                //}
                sf = gf.MeasureString(filterNames, HeaderFont, new SizeF(500, 500));
                gf.DrawString(filterNames, HeaderFont, Brushes.DarkBlue, new RectangleF(new PointF(ptX, ptY), new SizeF(sf.Width, sf.Height)));

                sf = gf.MeasureString(filterValues, HeaderFont, new SizeF(500, 500));
                gf.DrawString(filterValues, HeaderFont, Brushes.DarkBlue, new RectangleF(new PointF(ptX + 300, ptY), new SizeF(sf.Width, sf.Height)));

                //___Footer___
                gf.DrawString("Ημερομηνία Εκτύπωσης: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " / Χρήστης: " + UserInfo.WindowsUser,
                    myFont, Brushes.Black, new Point(Convert.ToInt32(StartingPtX), 746)); //font size: 16
                gf.DrawString("Σελίδα " + currentPage.ToString() + " / " + pageCount.ToString(), myFont, Brushes.Black, new Point(550, 746));

                currentPage++;

                e.HasMorePages = true;
                return;
            }
            //*************Column Headers*************
            for (int i = 0; i < 14; i++)
            {
                if (i == 0)//Id: hidden column!!! //11
                {
                    lvWidth.Add(0);
                    continue;
                }

                sf = gf.MeasureString(lviColumnHeader.SubItems[i].Text, HeaderFont, new SizeF(500, 500));//delete sizeF ??for varchar(max)

                if (i == 4) //aa //0
                {
                    sf.Width -= 21;
                    sf.Height = sf.Height * 2;
                }

                if (i == 1) //com
                {
                    sf.Width += 4;
                }

                if (i == 2) //etos //1
                {
                    sf.Width += 2;
                }
                //if (i == 3) //kat.prwtok //2
                //{
                //    sf.Width -= 1;
                //}
                if (i == 6) //im.ekd //4
                {
                    sf.Width -= 29;
                    sf.Height = sf.Height * 2;
                }
                if (i == 5) //im.lipsis/apost //5
                {
                    sf.Width -= 66;
                    sf.Height = sf.Height * 2;
                }
                if (i == 7) //ar.eis //6
                {
                    sf.Width -= 52; //26
                    sf.Height = sf.Height * 2;
                }
                if (i == 8) //proel //7
                {
                    sf.Width -= 50;
                    sf.Height = sf.Height * 2;
                }
                if (i == 9) //perilipsi //8
                {
                    sf.Width += 158;
                }
                if (i == 10) //parat //9
                {
                    sf.Width -= 74;
                    sf.Height = sf.Height * 2;
                }
                if (i == 11) //ar.fakelou //10
                {
                    sf.Width -= 30;
                    sf.Height = sf.Height * 2;
                }
                
                lvWidth.Add(sf.Width);
                if (maxHeight < sf.Height)
                {
                    maxHeight = sf.Height;
                }
            }
            lvHeight.Add(maxHeight);
            
            for (int i = 0; i < 14; i++)
            {
                if (i == 0)//Id: hidden column!!! //11
                {
                    ptX += lvWidth[i];
                    continue;
                }
                //---------
                e.Graphics.FillRectangle(HeaderBackColor, ptX, ptY, lvWidth[i], lvHeight[0]);
                //---------
                gf.DrawString(lviColumnHeader.SubItems[i].Text, HeaderFont, Brushes.DarkBlue, new RectangleF(new PointF(ptX, ptY), new SizeF(lvWidth[i], ptY + lvHeight[0])));
                e.Graphics.DrawRectangle(Pens.Black, ptX, ptY, lvWidth[i], lvHeight[0]);
                ptX += lvWidth[i];
            }

            int lvIndex = 0;

            //*************Lines*************
            for (int k = forCounter; k < lvRep.Items.Count; k++)
            {
                maxHeight = 0;
                ptX = PageSpaceX;
                ptY += lvHeight[lvIndex];

                for (int i = 0; i < 14; i++)
                {
                    if (i == 0)//hidden column!!! //11
                    {
                        continue;
                    }

                    sf = gf.MeasureString(lvRep.Items[k].SubItems[i].Text, myFont, new SizeF(lvWidth[i], 500));//delete sizeF ??for varchar(max)

                    if (maxHeight < sf.Height)
                    {
                        maxHeight = sf.Height;
                    }
                }
                lvHeight.Add(maxHeight);

                //if (ptY + lvHeight[lvIndex] > e.PageBounds.Height - PageSpaceY)
                if (ptY + lvHeight[lvIndex+1] > e.PageBounds.Height - PageSpaceY)
                {
                    //go to next page
                    e.HasMorePages = true;
                    forCounter = k;

                    //*************Footer*************

                    gf.DrawString("Ημερομηνία Εκτύπωσης: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " / Χρήστης: " + UserInfo.WindowsUser, 
                        myFont, Brushes.Black, new Point(Convert.ToInt32(StartingPtX), 746)); //font size: 16

                    gf.DrawString("Σελίδα " + currentPage.ToString() + " / " + pageCount.ToString(), myFont, Brushes.Black, new Point(550, 746));
                    currentPage++;
                    return;
                }

                //lvIndex++;
                for (int i = 0; i < 14; i++)
                {
                    if (i == 0)//Id: hidden column!!! //11
                    {
                        ptX += lvWidth[i];
                        continue;
                    }

                    gf.DrawString(lvRep.Items[k].SubItems[i].Text, myFont, Brushes.Black, new RectangleF(new PointF(ptX, ptY), new SizeF(lvWidth[i], ptY + lvHeight[lvIndex + 1])));
                    e.Graphics.DrawRectangle(Pens.Black, ptX, ptY, lvWidth[i], lvHeight[lvIndex + 1]);
                    ptX += lvWidth[i];
                }
                lvIndex++;
            }

            //*************Footer*************

            gf.DrawString("Ημερομηνία Εκτύπωσης: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " / Χρήστης: " + UserInfo.WindowsUser, 
                myFont, Brushes.Black, new Point(Convert.ToInt32(StartingPtX), 746)); //font size: 16

            gf.DrawString("Σελίδα " + currentPage.ToString() + " / " + pageCount.ToString(), myFont, Brushes.Black, new Point(550, 746));

            //*************Finish*************
            //Init global vars
            forCounter = 0;
            pageCount = 0;
            currentPage = 1;          
        }

        public static int GetPageCount(PrintDocument printDocument)
        {
            int count = 0;
            printDocument.PrintController = new PreviewPrintController();
            printDocument.PrintPage += (sender, e) => count++;
            printDocument.Print();
            return count;
        }
    }

    class FiltersToPrint
    {
        //string filtersToString(List<Filter> savedFilterControls)
        public FiltersToPrint(List<Filter> savedFilterControls)
        {
            filterNames = "";
            filterValues = "";

            if (savedFilterControls.Count <= 0) //no filters - get default filters
            {
                //ret = "Ημ.Λήψης/Αποστ.: " + new DateTime(DateTime.Now.Year, 1, 1).ToString("dd.MM.yyyy") + "-" + new DateTime(DateTime.Now.Year, 12, 31).ToString("dd.MM.yyyy");
                filterNames = "Ημ.Λήψης/Αποστ.:";
                filterValues = new DateTime(DateTime.Now.Year, 1, 1).ToString("dd.MM.yyyy") + "-" + new DateTime(DateTime.Now.Year, 12, 31).ToString("dd.MM.yyyy");
            }
            else
            {
                foreach (Filter thisFilter in savedFilterControls)
                {
                    if (thisFilter.FieldName == "chlbCompany")
                    {
                        string FCom = "";
                        foreach (string thisVal in thisFilter.FieldCheckedValues)
                        {
                            FCom += thisVal + ",";
                        }
                        if (FCom.Length > 0)
                        {
                            FCom = FCom.Substring(0, FCom.Length - 1);
                        }

                        //ret += "Εταιρία: " + FCom;
                        //ret += "\r\n";
                        filterNames += "Εταιρία:\r\n";
                        filterValues += FCom + "\r\n";

                        continue; // na valw else...anti continue...??
                    }

                    if (thisFilter.FieldName == "chlbProced")
                    {
                        string FProced = "";
                        foreach (string thisVal in thisFilter.FieldCheckedValues)
                        {
                            FProced += thisVal + ",";
                        }
                        if (FProced.Length > 0)
                        {
                            FProced = FProced.Substring(0, FProced.Length - 1);
                        }

                        //ret += "Κατηγ. Πρωτοκόλλου: " + FProced;
                        //ret += "\r\n";
                        filterNames += "Κατηγ. Πρωτοκόλλου:\r\n";
                        filterValues += FProced + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "txtSn")
                    {
                        //ret += "Αρ. Πρωτοκόλλου: " + thisFilter.FieldValue;
                        //ret += "\r\n";
                        filterNames += "Αρ. Πρωτοκόλλου:\r\n";
                        filterValues += thisFilter.FieldValue + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "dtpGetSetDate_From") //"dtpGetSetDate_To"
                    {
                        //ret += "Ημ.Λήψης/Αποστ.: " + DateTime.Parse(thisFilter.FieldValue).ToString("dd.MM.yyyy") + "-" + DateTime.Parse(savedFilterControls.Find(x => x.FieldName == "dtpGetSetDate_To").FieldValue).ToString("dd.MM.yyyy");
                        //ret += "\r\n";
                        filterNames += "Ημ.Λήψης/Αποστ.:\r\n";
                        filterValues += DateTime.Parse(thisFilter.FieldValue).ToString("dd.MM.yyyy") + "-" + DateTime.Parse(savedFilterControls.Find(x => x.FieldName == "dtpGetSetDate_To").FieldValue).ToString("dd.MM.yyyy") + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "dtp_DocDate_From") //"dtp_DocDate_To"
                    {
                        //ret += "Ημ.Έκδοσης: " + DateTime.Parse(thisFilter.FieldValue).ToString("dd.MM.yyyy") + "-" + DateTime.Parse(savedFilterControls.Find(x => x.FieldName == "dtp_DocDate_To").FieldValue).ToString("dd.MM.yyyy");
                        //ret += "\r\n";
                        filterNames += "Ημ.Έκδοσης:\r\n";
                        filterValues += DateTime.Parse(thisFilter.FieldValue).ToString("dd.MM.yyyy") + "-" + DateTime.Parse(savedFilterControls.Find(x => x.FieldName == "dtp_DocDate_To").FieldValue).ToString("dd.MM.yyyy") + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "txtDocNum")
                    {
                        //ret += "Αρ.Εισερχ.Εγγράφου: " + thisFilter.FieldValue;
                        //ret += "\r\n";
                        filterNames += "Αρ.Εισερχ.Εγγράφου:\r\n";
                        filterValues += thisFilter.FieldValue + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "txtProelKateuth")
                    {
                        //ret += "Προέλευση/Κατεύθυνση: " + thisFilter.FieldValue;
                        //ret += "\r\n";
                        filterNames += "Προέλευση/Κατεύθυνση:\r\n";
                        filterValues += thisFilter.FieldValue + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "txtSummary")
                    {
                        //ret += "Περίληψη: " + thisFilter.FieldValue;
                        //ret += "\r\n";
                        filterNames += "Περίληψη:\r\n";
                        filterValues += thisFilter.FieldValue + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "txtToText")
                    {
                        //ret += "Παρ.για ενέργεια/Παρατηρήσεις: " + thisFilter.FieldValue;
                        //ret += "\r\n";
                        filterNames += "Παρ.για ενέργεια/Παρατηρήσεις:\r\n";
                        filterValues += thisFilter.FieldValue + "\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "chlbFolder")
                    {
                        string FFolder = "";
                        foreach (string thisVal in thisFilter.FieldCheckedValues)
                        {
                            FFolder += thisVal + ",";
                        }
                        if (FFolder.Length > 0)
                        {
                            FFolder = FFolder.Substring(0, FFolder.Length - 1);
                        }

                        //ret += "Αρ.Φακέλου Αρχείου: " + FFolder;
                        //ret += "\r\n";
                        filterNames += "Αρ.Φακέλου Αρχείου:\r\n";
                        filterValues += FFolder + "\r\n";

                        continue; // na valw else...anti continue...??
                    }

                    if (thisFilter.FieldName == "chbHasAtt")
                    {
                        //ret += "Περιέχει Αρχεία: Ναι";
                        //ret += "\r\n";
                        filterNames += "Περιέχει Αρχεία:\r\n";
                        filterValues += "Ναι\r\n";

                        continue;
                    }

                    if (thisFilter.FieldName == "chbMailSent")
                    {
                        //ret += "Εστάλη Email: Ναι";
                        //ret += "\r\n";
                        filterNames += "Εστάλη Email:\r\n";
                        filterValues += "Ναι\r\n";

                        continue;
                    }

                }
            }
        }

        public string filterNames { get; set; }
        public string filterValues { get; set; }
    }
}
