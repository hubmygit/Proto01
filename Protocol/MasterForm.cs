using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
//using System.Windows.Forms.DataVisualization.Charting;

namespace Protocol
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();

            tsStatusLblUser.Text = "User: " + UserInfo.WindowsUser + " - " + UserInfo.FullName;

            //arrangeChart(chartYearly, new string[] { "Motor Oil", "AVIN", "LPC", "Test" }, new int[] { 230, 40, 40, 10 });
            //arrangeChart(chartMonthly, new string[] { "Motor Oil", "AVIN" }, new int[] { 94, 40 });

            //arrangeChart(chartYearly, new string[] { }, new int[] { });
            //arrangeChart(chartMonthly, new string[] { }, new int[] { });

            /*
            ChartData chYData = getChartYearlyData();
            ChartData chMData = getChartMonthlyData();
            arrangeChart(chartYearly, chYData.company, chYData.value);
            arrangeChart(chartMonthly, chMData.company, chMData.value);
            */
        }


        //private void InsertTSMenuItem_Click(object sender, EventArgs e)
        //{
        //}

        private void UpdateTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokoloUpdateForm frmProtoUpd = new ProtokoloUpdateForm();
            frmProtoUpd.ShowDialog();
        }

        private void DeleteTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokoloDeleteForm frmProtoDel = new ProtokoloDeleteForm();
            frmProtoDel.ShowDialog();
        }

        private void InsertProtocol_Click(object sender, EventArgs e)
        {
            ProtokoloInsertForm frmProtoIns = new ProtokoloInsertForm();
            frmProtoIns.ShowDialog();

            if (frmProtoIns.successfulInsertion && frmProtoIns.chbSendMail.Checked)
            {
                if (frmProtoIns.IOBoxPanel.Name.ToUpper() == "PANELINBOX")
                {
                    try
                    {
                        //Show Contacts...
                        outlookForms oF = new outlookForms();
                        oF.showContacts();

                        if (oF.RecipientsList.Count > 0)
                        {
                            //Show Mail... 
                            //oF.ShowMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Save Mail... 
                            //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Send Mail... 
                            oF.SendMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMess = ex.Message; //do nothing - constructor catches the exception
                        //MessageBox.Show(exMess);
                    }
                }
                else if (frmProtoIns.IOBoxPanel.Name.ToUpper() == "PANELOUTBOX")
                {
                    //temporarily hide 'dieuthinsiografo' and replace with outlook address book
                    /*
                    //Show ContactsToEmail Form
                    ContactsToEmail cteFrm = new ContactsToEmail();
                    cteFrm.ShowDialog();

                    try
                    {
                        if (cteFrm.frmSaved) //check if recipients.count > 0
                        {
                            outlookForms oF = new outlookForms();
                            oF.fillRecipientList(cteFrm.txtRecipientsTo.Text, cteFrm.txtRecipientsCc.Text, cteFrm.txtRecipientsBcc.Text);

                            //Show Mail... 
                            oF.ShowMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Save Mail... 
                            //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Send Mail... 
                            //oF.SendMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMess = ex.Message; //do nothing - constructor catches the exception
                        //MessageBox.Show(exMess);
                    }
                    */

                    try
                    {
                        //Show Contacts...
                        outlookForms oF = new outlookForms();
                        oF.showContacts();

                        if (oF.RecipientsList.Count > 0)
                        {
                            //Show Mail... 
                            oF.ShowMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Save Mail... 
                            //oF.SaveMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);

                            //Send Mail... 
                            //oF.SendMail(frmProtoIns.myEmail.ProtokId, frmProtoIns.myEmail.Subject, frmProtoIns.myEmail.Body, frmProtoIns.AttFilesList);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMess = ex.Message; //do nothing - constructor catches the exception
                        //MessageBox.Show(exMess);
                    }

                }
            }
            //else if (frmProtoIns.successfulInsertion == false && frmProtoIns.chbSendMail.Checked == true)
            //{
            //    MessageBox.Show("Λόγω σφάλματος κατά την καταχώρηση, δεν θα αποσταλεί e-mail!");
            //}
        }

        //private void InsertToolStripBtn_Click(object sender, EventArgs e)
        //{
        //}

        private void UpdateToolStripBtn_Click(object sender, EventArgs e)
        {
            ProtokoloUpdateForm frmProtoUpd = new ProtokoloUpdateForm();
            frmProtoUpd.ShowDialog();
        }

        private void DeleteToolStripBtn_Click(object sender, EventArgs e)
        {
            ProtokoloDeleteForm frmProtoDel = new ProtokoloDeleteForm();
            frmProtoDel.ShowDialog();
        }

        private void FolderInsTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersInsertForm FoldersInsForm = new FoldersInsertForm();
            FoldersInsForm.ShowDialog();
        }

        private void FolderDelTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersDeleteForm FoldersDelForm = new FoldersDeleteForm();
            FoldersDelForm.ShowDialog();
        }

        private void FolderUpdTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersUpdateForm FoldersUpdForm = new FoldersUpdateForm();
            FoldersUpdForm.ShowDialog();
        }

        private void FolderToProtokTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokPerFolderForm ProtokPerFolderForm = new ProtokPerFolderForm();
            ProtokPerFolderForm.ShowDialog();
        }

        private void UserInfoTSMenuItem_Click(object sender, EventArgs e)
        {
            AboutUserInfoForm UserInfoForm = new AboutUserInfoForm();
            UserInfoForm.ShowDialog();
        }

        private void SelectTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtokoloSelectForm frmProtoSel = new ProtokoloSelectForm();
            frmProtoSel.ShowDialog();
        }

        private void SelectToolStripBtn_Click(object sender, EventArgs e)
        {
            ProtokoloSelectForm frmProtoSel = new ProtokoloSelectForm();
            frmProtoSel.ShowDialog();
        }

        private void FolderSelTSMenuItem_Click(object sender, EventArgs e)
        {
            FoldersSelectForm FoldersSelForm = new FoldersSelectForm();
            FoldersSelForm.ShowDialog();
        }

        private void VersionTSMenuItem_Click(object sender, EventArgs e)
        {
            ProtocolAboutBox pAboutBox = new ProtocolAboutBox();
            pAboutBox.ShowDialog();
        }

        private void ContactsTSMenuItem_Click(object sender, EventArgs e)
        {
            Contacts ContactsForm = new Contacts();
            ContactsForm.ShowDialog();
        }


        //Chart chartDoughnut(string[] names, int[] counters, string chTitle, Point chLocation)
        //{
        //    Chart chart = new Chart();
        //    //chart.Titles.Add(chTitle);

        //    chart.ChartAreas.Add(new ChartArea("Area"));
            
        //    chart.Series.Add(new Series("Data"));
        //    chart.Series["Data"].ChartType = SeriesChartType.Doughnut;
        //    chart.Series["Data"]["PieLabelStyle"] = "Outside";
        //    chart.Series["Data"]["PieLineColor"] = "Black";
                        
        //    if (counters.Count() == 0)
        //    {
        //        counters = new int[] { 1 };
        //        names = new string[] { "Καμία εγγραφή" };
        //        //chart.Series["Data"].Label = "";
        //        chart.Series["Data"].Points.DataBindY(counters);
        //    }
        //    else
        //    {
        //        //chart.Series["Data"].Label = "#VALX #PERCENT{P0}";
        //        //chart.Series["Data"].Label = "#PERCENT\n#VALX";
        //        //chart.Series["Data"].Label = "#VALX: #VALY";

        //        chart.Series["Data"].Label = "#VALX: #VALY";
        //        chart.Series["Data"].Points.DataBindXY(names, counters);

        //        //chart.Series["Data"].Points.DataBindXY(
        //        //    data.Select(data => data.Name.ToString()).ToArray(),
        //        //    data.Select(data => data.Count).ToArray());
        //    }
            
        //    chart.Location = chLocation;

        //    chart.BackColor = this.BackColor;
        //    chart.ChartAreas[0].BackColor = this.BackColor;
        //    //chart.Legends[0].BackColor = this.BackColor;

        //    chart.Size = new Size(300, 300);

        //    return chart;
        //}

        /*
        void arrangeChart(Chart myChart, string[] names, int[] counters)
        {
            // myChart.Series["Series1"].ChartType = SeriesChartType.Doughnut;
           // myChart.Series["Series1"]["PieLabelStyle"] = "Outside";
           // myChart.Series["Series1"]["PieLineColor"] = "Black";

            //if (counters.Count() == 0)
            //{
            //    counters = new int[] { 1 };
            //    names = new string[] { "Καμία εγγραφή" };
            //    myChart.Series["Series1"].Label = "0";
            //    myChart.Series["Series1"].Points.DataBindY(counters);

            //}
            //else
            //{
            //myChart.Series["Series1"].Label = "#VALX #PERCENT{P0}";
            //myChart.Series["Series1"].Label = "#PERCENT\n#VALX";
            //myChart.Series["Series1"].Label = "#VALX: #VALY";

            //myChart.Series["Series1"].Label = "#VALX: #VALY";
            myChart.Series["Series1"].Label = "#VALX (#VALY)";
            //myChart.Series["Series1"].Label = "";
            myChart.Series["Series1"].Points.DataBindXY(names, counters);

                //myChart.Series[0].LegendText = "#VALX";

            //myChart.Series["Series1"].Points.DataBindXY(
            //    data.Select(data => data.Name.ToString()).ToArray(),
            //    data.Select(data => data.Count).ToArray());
            //}

            myChart.BackColor = this.BackColor;
            myChart.ChartAreas[0].BackColor = this.BackColor;
            //myChart.Legends[0].BackColor = this.BackColor;

            if (counters.Count() == 0)
            {
                Controls.Remove(myChart);

                string lblName = "lbl" + myChart.Name;
                Controls[lblName].Visible = true;
                Controls[lblName].Location = new Point(myChart.Location.X + 50, myChart.Location.Y + 60);
            }
            

        }

        private ChartData getChartYearlyData()
        {
            ChartData yearlyData = new ChartData();

            List<string> companyList = new List<string>();
            List<int> valueList = new List<int>();            

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT year(P.InsDT) as curYear, C.Name, count(*) as Cnt " + 
                "FROM[dbo].[Protok] P left outer join[dbo].[Company] C on C.id = P.CompanyId " +
                "WHERE isnull(P.deleted, 0) = 0 and year(P.InsDT) = year(getdate()) " +

                " and C.id in (" + UserInfo.CompaniesAsCsvString + ") " +

                "GROUP BY year(P.InsDT), C.Name " +
                "ORDER BY C.Name";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    companyList.Add(reader["Name"].ToString());
                    valueList.Add(Convert.ToInt32(reader["Cnt"].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            yearlyData.company = companyList.ToArray();
            yearlyData.value = valueList.ToArray();

            return yearlyData;
        }

        private ChartData getChartMonthlyData()
        {
            ChartData yearlyData = new ChartData();

            List<string> companyList = new List<string>();
            List<int> valueList = new List<int>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT year(P.InsDT) as curYear, month(P.InsDT) as curMonth, C.Name, count(*) as Cnt " +
                              "FROM[dbo].[Protok] P left outer join[dbo].[Company] C on C.id = P.CompanyId " +
                              "WHERE isnull(P.deleted, 0) = 0 and year(P.InsDT) = year(getdate()) and month(P.InsDT) = month(getdate()) " +

                              " and C.id in (" + UserInfo.CompaniesAsCsvString + ") " +

                              "GROUP BY year(P.InsDT), month(P.InsDT), C.Name " +
                              "ORDER BY C.Name";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    companyList.Add(reader["Name"].ToString());
                    valueList.Add(Convert.ToInt32(reader["Cnt"].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            yearlyData.company = companyList.ToArray();
            yearlyData.value = valueList.ToArray();

            return yearlyData;
        }
        */

        //test and delete!!!
        void TestReader()
        {
            string connectionString = "Persist Security Info=False; User ID=" + "GramV3" + "; Password=" + "8093570" + "; Initial Catalog=" + "GramV3-Dev" + "; Server=" + "AVINDOMC\\SQLSERVERR2";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            string SelectSt = "SELECT * FROM [dbo].[Protok] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable Schemadt = reader.GetSchemaTable();

//                while (reader.Read())
//                {
//                    string aaaa = reader["Name"].ToString();
//
//                    string aa = reader["Name"].GetType().ToString();
//                }
                
                var dotNetType = reader.GetFieldType(0);
                var sqlType = reader.GetDataTypeName(0);

                frmFilter a = new frmFilter();
                a.PopulateForm(reader, Schemadt);
                a.ShowDialog();

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestReader();
        }

        private void YMStatsTSMenuItem_Click(object sender, EventArgs e)
        {
            Statistics frmStatistics = new Statistics();
            frmStatistics.ShowDialog();
        }

        private void ManualTSMenuItem_Click(object sender, EventArgs e)
        {
            //insert manual
            /*
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Doc] (DocType, DocName, DocCont) VALUES ('Manual', 'ProtocolManual.pdf', @DocCont) ";
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\Tests\\ProtocolManual.pdf");
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.Add("@DocCont", SqlDbType.VarBinary).Value = fileBytes;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            */


            ////Open Manual
            //string lvPath = "";
            //string ext = "";
            //string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\                                   
            //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
            //try
            //{
            //    //if (!Directory.Exists(Application.StartupPath + "\\Temp\\"))
            //    if (!Directory.Exists(tempPath))
            //    {
            //        //Directory.CreateDirectory(Application.StartupPath + "\\Temp\\");
            //        MessageBox.Show("Σφάλμα. Παρακαλώ ελέγξτε τα δικαιώματά σας στο " + tempPath);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("The following error occurred: " + ex.Message);
            //    return;
            //}

            //SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            //string SelectSt = "SELECT [FileCont] FROM [dbo].[ProtokPdf] WHERE ProtokId = @ProtokId and PdfText = @PdfText";
            //SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            //try
            //{
            //    sqlConn.Open();

            //    ProtokoloInsertForm pif = (ProtokoloInsertForm)ctrl.FindForm();

            //    cmd.Parameters.AddWithValue("@ProtokId", pif.Protok_Id_For_Updates);
            //    cmd.Parameters.AddWithValue("@PdfText", lv.SelectedItems[0].SubItems[0].Text);

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        string fname = lv.SelectedItems[0].SubItems[0].Text;
            //        ext = fname.Substring(fname.LastIndexOf("."));
            //        lvPath = tempFile + ext;
            //        //reader["FileCont"].ToString()
            //        File.WriteAllBytes(tempFile + ext, (byte[])reader["FileCont"]);
            //    }
            //    reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("The following error occurred: " + ex.Message);
            //    return;
            //}

            //System.Diagnostics.Process.Start(lvPath);
        }
    }

    /*
    public class ChartData
    {
        public string [] company { get; set; }
        public int [] value { get; set; }        
    }
    */

}
