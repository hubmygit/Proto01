using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Protocol
{
    public static class DBInfo
    {
        static DBInfo()
        {
            //default values
            server = "AVINDOMC\\SQLSERVERR2";
            database = "GramV3-Dev";
            username = "GramV3";
            password = "8093570";

            string configFile_Path = @"dbconfig.txt";
            List<string> ConfigLines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(configFile_Path))
                {
                    while (true)
                    {
                        string line = sr.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        ConfigLines.Add(line);
                    }

                    if (ConfigLines.Count >= 4)
                    {
                        server = ConfigLines[0];
                        database = ConfigLines[1];
                        username = ConfigLines[2];
                        password = ConfigLines[3];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Config file could not be read:" + e.Message);
            }
        }

        public static string server { get; set; }
        public static string database { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public static class AppVer
    {

        public static bool IsLatestVersion() //Compare app version with db version
        {
            bool ret = true;
            int CurrentVersion = getCurrentAppVersion();
            int LatestVersion = getLatestAppVersionFromDB();

            if (CurrentVersion < LatestVersion)
            {
                ret = false;
                MessageBox.Show("Η έκδοση της εφαρμογής σας είναι παλαιότερη από την τρέχουσα! \r\nΕίναι απαραίτητο να γίνει αναβάθμιση για να συνεχίσετε.");
            }

            return ret;
        }

        public static int getCurrentAppVersion()
        {
            //this is 'File Version' - for 'Assembly Version' use System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() 
            int ret = 0;
            string appVer = Application.ProductVersion.Replace(".", "");
            bool succeeded = Int32.TryParse(appVer, out ret);

            return ret;
        }

        public static int getLatestAppVersionFromDB()
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
            string SelectSt = "SELECT Num FROM [dbo].[TableIds] WHERE tablename = 'VersionInfo' ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Num"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
    }
}
