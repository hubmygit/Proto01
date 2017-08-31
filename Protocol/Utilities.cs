using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

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
}
