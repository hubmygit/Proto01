using System;
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

        public Printings()
        {
            //
        }

        public void printProtocols(ListView ProtocolsListView)
        {
            lvRep = ProtocolsListView;

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
            ListViewItem lviColumnHeader = new ListViewItem(new string[] { "ΑΑ Πρωτ.", "Έτος", "Κατ.Πρωτοκ.", "Εταιρία", "Ημ/νία Έκδοσης", "Ημ.Λήψης/ Αποστολής", "Αρ.Εισερχ/ Σχετ.Αρ.",
                "Προέλευση/ Κατεύθυνση", "Περίληψη", "Παρ.για ενέργεια/ Παρατηρήσεις", "Αρ.Φακέλου Αρχείου", "Id", "Αρχεία", "Emails" });

            Graphics gf = e.Graphics;
            SizeF sf;

            Font HeaderFont = new Font("Arial", 9, FontStyle.Bold);
            Font myFont = new Font("Arial", 9);
            SolidBrush HeaderBackColor = new SolidBrush(Color.LightGray);

            float maxHeight = 0;
            List<float> lvWidth = new List<float>();
            List<float> lvHeight = new List<float>();

            float PageSpaceX = 16; //12
            float PageSpaceY = 80;
            float StartingPtX = 16; //12
            float StartingPtY = 92;
            float ptX = StartingPtX;
            float ptY = StartingPtY;
            
            //*************Header*************
            Font GeneralHeaderFont = new Font("Arial", 14, FontStyle.Bold);
            gf.DrawString("ΠΡΩΤΟΚΟΛΛΟ ΕΙΣΕΡΧΟΜΕΝΩΝ / ΕΞΕΡΧΟΜΕΝΩΝ ΕΓΓΡΑΦΩΝ", GeneralHeaderFont, Brushes.Brown, new Point(256, 48));

            //*************Column Headers*************
            for (int i = 0; i < 14; i++)
            {
                if (i == 11)//Id: hidden column!!!
                {
                    lvWidth.Add(0);
                    continue;
                }

                sf = gf.MeasureString(lviColumnHeader.SubItems[i].Text, HeaderFont, new SizeF(500, 500));//delete sizeF ??for varchar(max)

                if (i == 0) //aa
                {
                    sf.Width -= 21;
                    sf.Height = sf.Height * 2;
                }
                if (i == 1) //etos
                {
                    sf.Width += 2;
                }
                //if (i == 2) //kat.prwtok
                //{
                //    sf.Width -= 1;
                //}
                if (i == 4) //im.ekd
                {
                    sf.Width -= 29;
                    sf.Height = sf.Height * 2;
                }
                if (i == 5) //im.lipsis/apost
                {
                    sf.Width -= 66;
                    sf.Height = sf.Height * 2;
                }
                if (i == 6) //ar.eis
                {
                    sf.Width -= 26;
                    sf.Height = sf.Height * 2;
                }
                if (i == 7) //proel
                {
                    sf.Width -= 50;
                    sf.Height = sf.Height * 2;
                }
                if (i == 8) //perilipsi
                {
                    sf.Width += 158;
                }
                if (i == 9) //parat
                {
                    sf.Width -= 74;
                    sf.Height = sf.Height * 2;
                }
                if (i == 10) //ar.fakelou
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
                if (i == 11)//Id: hidden column!!!
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
                    if (i == 11)//hidden column!!!
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
                
                if (ptY + lvHeight[lvIndex] > e.PageBounds.Height - PageSpaceY)
                {
                    //go to next page
                    e.HasMorePages = true;
                    forCounter = k;

                    //*************Footer*************

                    gf.DrawString("Ημερομηνία Εκτύπωσης: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), myFont, Brushes.Black, new Point(Convert.ToInt32(StartingPtX), 740));

                    gf.DrawString("Σελίδα " + currentPage.ToString() + " / " + pageCount.ToString(), myFont, Brushes.Black, new Point(550, 740));
                    currentPage++;
                    return;
                }

                //lvIndex++;
                for (int i = 0; i < 14; i++)
                {
                    if (i == 11)//Id: hidden column!!!
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

            gf.DrawString("Ημερομηνία Εκτύπωσης: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), myFont, Brushes.Black, new Point(Convert.ToInt32(StartingPtX), 740));

            gf.DrawString("Σελίδα " + currentPage.ToString() + " / " + pageCount.ToString(), myFont, Brushes.Black, new Point(550, 740));

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
}
