using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocol
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (AppVer.IsLatestVersion()) //check version
            {
                UserInfo.UserLogIn();
                UserInfo.DB_AppUser_Id = 5;
                if (UserInfo.DB_AppUser_Id == 0)//user not found (& not inserted)
                {
                    MessageBox.Show("Ο χρήστης δεν έχει τα κατάλληλα δικαιώματα για εισαγωγή στην εφαρμογή!");
                    return;
                }
                
                Application.Run(new MasterForm());
            }            
        }
    }
}
