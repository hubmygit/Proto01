using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Data;

namespace Protocol
{
    /*
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
    */


    public static class DBInfo
    {
        static DBInfo()
        {
            //default values
            string server = "AVINDOMC\\SQLSERVERR2";
            string database = "GramV3-Dev";
            string username = "GramV3";
            string password = "8093570";
            connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;
            
            try
            {
                connectionString = Properties.Settings.Default.connString;
            }
            catch (Exception e)
            {
                MessageBox.Show("Config file could not be read:" + e.Message);
            }

        }
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

        /*
        public static bool operator ==(ComboboxItem cbItem1, ComboboxItem cbItem2)
        {
            if (object.ReferenceEquals(cbItem1, cbItem2))
            {
                return true;
            }
            if (object.ReferenceEquals(cbItem1, null))
            {
                return false;
            }
            if (object.ReferenceEquals(cbItem2, null))
            {
                return false;
            }

            return (cbItem1.Text == cbItem2.Text && cbItem1.Value == cbItem2.Value);
        }

        public static bool operator !=(ComboboxItem cbItem1, ComboboxItem cbItem2)
        {
            return !(cbItem1 == cbItem2);
        }

        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            //return (Text == ((ComboboxItem)obj).Text && Value == ((ComboboxItem)obj).Value);
            
            ComboboxItem p = obj as ComboboxItem;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Text == p.Text) && (Value == p.Value);
                        
        }

        public bool Equals(ComboboxItem p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Text == p.Text) && (Value == p.Value);
        }
        */
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
            WindowsUser = "unknown";
            EmailAddress = "";
            FullName = "Unknown";

            DB_AppUser_Id = 0;

            AssignedCompanies = new List<int>();
            CompaniesAsCsvString = "";

            try
            {
                WindowsUser = Environment.UserName;
                                
                EmailAddress = UserPrincipal.Current.EmailAddress;
                if (EmailAddress == null) //if domain infos not found
                {
                    EmailAddress = "";
                }
                
                FullName = UserPrincipal.Current.DisplayName;
                if (FullName == null) //if domain infos not found
                {
                    FullName = "Unknown";
                }       

                DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);

                //MachineName = Environment.MachineName;
                //OsVersion = Environment.OSVersion.VersionString;
                //DomainName = Environment.UserDomainName;

                //AssignedCompanies.AddRange(Get_User_Assigned_Companies(DB_AppUser_Id));
                AssignedCompanies = Get_User_Assigned_Companies(DB_AppUser_Id);
                CompaniesAsCsvString = Get_CompaniesAsCsvString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        public static string FullName { get; set; }
        public static string EmailAddress { get; set; }
        public static string WindowsUser { get; set; }

        public static string MachineName { get { return Environment.MachineName; } set { } }
        public static string OsVersion { get { return Environment.OSVersion.VersionString; } set { } }
        public static string DomainName { get { return Environment.UserDomainName; } set { } }
        
        public static int DB_AppUser_Id { get; set; }
        //public static int DB_AppUser_Id
        //{
        //    get { return Get_DB_AppUser_Id(Environment.UserName); }
        //    set { }
        //}

        public static List<int> AssignedCompanies { get; set; }
        public static string CompaniesAsCsvString { get; set; }

        public static void UserLogIn()
        {
            //select
            if (DB_AppUser_Id != 0) //found
            {
                //update record with last infos
                Update_AppUser();
            }
            else //not found
            {
                //insert new record infos
                Insert_AppUser();

                //select new id
                DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);
            }
        }

        private static void Update_AppUser()
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string UpdSt = "UPDATE [dbo].[AppUsers] SET FullName = @fullName, EmailAddress = @emailAddr, InsDate = getdate() WHERE Id = @id ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                cmd.Parameters.AddWithValue("@id", DB_AppUser_Id);
                cmd.Parameters.AddWithValue("@fullName", FullName);
                cmd.Parameters.AddWithValue("@emailAddr", EmailAddress);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        private static void Insert_AppUser()
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[AppUsers] (WinUser, FullName, EmailAddress, InsDate) VALUES (@winUser, @fullName, @emailAddr, getdate()) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@winUser", WindowsUser);
                cmd.Parameters.AddWithValue("@fullName", FullName);
                cmd.Parameters.AddWithValue("@emailAddr", EmailAddress);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
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

        private static List<int> Get_User_Assigned_Companies(int UserId)
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT CompanyId FROM [dbo].[AppAuth] WHERE UserId = " + UserId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int comId = Convert.ToInt32(reader["CompanyId"].ToString());
                    
                    if (comId == 999) //Show all companies
                    {
                        return GetAllCompanies();
                    }

                    ret.Add(comId);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static string Get_CompaniesAsCsvString()
        {
            string ret = "";

            foreach (int thisCom in AssignedCompanies)
            {
                ret += thisCom.ToString() + ",";
            }

            if (ret.Length > 0)
            {
                ret = ret.Substring(0, ret.Length - 1);
            }
            
            return ret;
        }


        public static List<int> GetAllCompanies() 
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Company] ORDER BY Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ret.Add(Convert.ToInt32(reader["Id"].ToString()));
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
