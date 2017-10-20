using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Protocol
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();

            ChartData chYData = getChartYearlyData();
            ChartData chMData = getChartMonthlyData();
            arrangeChart(chartYearly, chYData.company, chYData.value);
            arrangeChart(chartMonthly, chMData.company, chMData.value);
        }


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
                Controls[lblName].Location = new Point(myChart.Location.X + 85, myChart.Location.Y + 60);
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




    }

    public class ChartData
    {
        public string[] company { get; set; }
        public int[] value { get; set; }
    }


}
