namespace Protocol
{
    partial class Statistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.lblchartMonthly = new System.Windows.Forms.Label();
            this.lblchartYearly = new System.Windows.Forms.Label();
            this.lblMonthlyChart = new System.Windows.Forms.Label();
            this.lblYearlyChart = new System.Windows.Forms.Label();
            this.chartMonthly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartYearly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearly)).BeginInit();
            this.SuspendLayout();
            // 
            // lblchartMonthly
            // 
            this.lblchartMonthly.AutoSize = true;
            this.lblchartMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblchartMonthly.Location = new System.Drawing.Point(415, 354);
            this.lblchartMonthly.Name = "lblchartMonthly";
            this.lblchartMonthly.Size = new System.Drawing.Size(164, 17);
            this.lblchartMonthly.TabIndex = 14;
            this.lblchartMonthly.Text = "(Δε βρέθηκαν εγγραφές)";
            this.lblchartMonthly.Visible = false;
            // 
            // lblchartYearly
            // 
            this.lblchartYearly.AutoSize = true;
            this.lblchartYearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblchartYearly.Location = new System.Drawing.Point(95, 354);
            this.lblchartYearly.Name = "lblchartYearly";
            this.lblchartYearly.Size = new System.Drawing.Size(164, 17);
            this.lblchartYearly.TabIndex = 13;
            this.lblchartYearly.Text = "(Δε βρέθηκαν εγγραφές)";
            this.lblchartYearly.Visible = false;
            // 
            // lblMonthlyChart
            // 
            this.lblMonthlyChart.AutoSize = true;
            this.lblMonthlyChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMonthlyChart.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMonthlyChart.Location = new System.Drawing.Point(403, 91);
            this.lblMonthlyChart.Name = "lblMonthlyChart";
            this.lblMonthlyChart.Size = new System.Drawing.Size(158, 20);
            this.lblMonthlyChart.TabIndex = 12;
            this.lblMonthlyChart.Text = "Πρωτόκολλα Μήνα";
            // 
            // lblYearlyChart
            // 
            this.lblYearlyChart.AutoSize = true;
            this.lblYearlyChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYearlyChart.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblYearlyChart.Location = new System.Drawing.Point(98, 91);
            this.lblYearlyChart.Name = "lblYearlyChart";
            this.lblYearlyChart.Size = new System.Drawing.Size(168, 20);
            this.lblYearlyChart.TabIndex = 11;
            this.lblYearlyChart.Text = "Πρωτόκολλα Έτους";
            // 
            // chartMonthly
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMonthly.ChartAreas.Add(chartArea1);
            this.chartMonthly.Location = new System.Drawing.Point(352, 114);
            this.chartMonthly.Name = "chartMonthly";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.IsValueShownAsLabel = true;
            series1.Name = "Series1";
            series1.ToolTip = "#VALX (#VAL)";
            this.chartMonthly.Series.Add(series1);
            this.chartMonthly.Size = new System.Drawing.Size(260, 240);
            this.chartMonthly.TabIndex = 10;
            this.chartMonthly.Text = "chart1";
            // 
            // chartYearly
            // 
            chartArea2.Name = "ChartArea1";
            this.chartYearly.ChartAreas.Add(chartArea2);
            this.chartYearly.Location = new System.Drawing.Point(52, 114);
            this.chartYearly.Name = "chartYearly";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.IsValueShownAsLabel = true;
            series2.Name = "Series1";
            series2.ToolTip = "#VALX (#VAL)";
            this.chartYearly.Series.Add(series2);
            this.chartYearly.Size = new System.Drawing.Size(260, 240);
            this.chartYearly.TabIndex = 9;
            this.chartYearly.Text = "chart1";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 462);
            this.Controls.Add(this.lblchartMonthly);
            this.Controls.Add(this.lblchartYearly);
            this.Controls.Add(this.lblMonthlyChart);
            this.Controls.Add(this.lblYearlyChart);
            this.Controls.Add(this.chartMonthly);
            this.Controls.Add(this.chartYearly);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(680, 500);
            this.MinimumSize = new System.Drawing.Size(680, 500);
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Στατιστικά";
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblchartMonthly;
        private System.Windows.Forms.Label lblchartYearly;
        private System.Windows.Forms.Label lblMonthlyChart;
        private System.Windows.Forms.Label lblYearlyChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonthly;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYearly;
    }
}