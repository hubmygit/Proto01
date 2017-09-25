﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;

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

            connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;

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

                        connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;
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
        public static string connectionString { get; set; }
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

    public class UpdatedId
    {
        public UpdatedId()
        {
            deleted = 0;
            inserted = 0;
        }

        public UpdatedId(int oldValue, int newValue)
        {
            deleted = oldValue;
            inserted = newValue;
        }

        public int deleted { get; set; }
        public int inserted { get; set; }
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

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
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

    public static class UserInfo
    {
        static UserInfo()
        {
            WindowsUser = Environment.UserName;
            EmailAddress = UserPrincipal.Current.EmailAddress;
            FullName = UserPrincipal.Current.DisplayName;
            //DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);
        }
        public static string FullName { get; set; }
        public static string EmailAddress { get; set; }
        public static string WindowsUser { get; set; }
        public static int DB_AppUser_Id
        {
            get { return Get_DB_AppUser_Id(Environment.UserName); }

            set { }
        }
        private static int Get_DB_AppUser_Id(string UserName)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[AppUsers] WHERE WinUser = '" + UserName + "'";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
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

    //public enum Procedure { Inbox = 1, Outbox = 2 };
    //++++++++++++ Company ?????? ++++++++++++
    //public class Ids
    //{

    //    public Ids()
    //    {

    //    }
    //    public Ids(Procedure procedure)
    //    {
    //        //year = 0;
    //        proced = procedure;

    //        tableMaxId = getTableMaxId();
    //        tableNextId = tableMaxId + 1;

    //        protocolMaxId = getProtocolMaxId(procedure);
    //        protocolNextId = protocolMaxId + 1;
    //    }

    //    public int year { get; set; }
    //    public Procedure proced { get; set; }
    //    public int tableMaxId { get; set; }
    //    public int tableNextId { get; set; }
    //    public int protocolMaxId { get; set; }
    //    public int protocolNextId { get; set; }

    //    public int getTableMaxId()
    //    {
    //        int ret = 0;

    //        SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
    //        string SelectSt = "SELECT isnull(max(id), 0) AS TableId FROM [dbo].[Protok] ";
    //        SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
    //        try
    //        {
    //            sqlConn.Open();
    //            SqlDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                ret = Convert.ToInt32(reader["TableId"].ToString());
    //            }
    //            reader.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("The following error occurred: " + ex.Message);
    //        }

    //        return ret;
    //    }

    //    public int getProtocolMaxId(Procedure proced)
    //    {
    //        int ret = 0;

    //        this.proced = proced;

    //        SqlConnection sqlConn = new SqlConnection("Persist Security Info=False; User ID=" + DBInfo.username + "; Password=" + DBInfo.password + "; Initial Catalog=" + DBInfo.database + "; Server=" + DBInfo.server);
    //        string SelectSt = "SELECT isnull(max(id), 0) AS TableId, year(getdate()) AS CurrentYear FROM [dbo].[Protok] WHERE [Year] = year(getdate()) AND [ProcedureId] = " + ((int)proced).ToString();
    //        SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
    //        try
    //        {
    //            sqlConn.Open();
    //            SqlDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                ret = Convert.ToInt32(reader["TableId"].ToString());
    //                year = Convert.ToInt32(reader["CurrentYear"].ToString());
    //            }
    //            reader.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("The following error occurred: " + ex.Message);
    //        }

    //        return ret;
    //    }
    //}
}
