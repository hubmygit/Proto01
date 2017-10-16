using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Protocol
{
    public partial class AboutUserInfoForm : Form
    {
        public AboutUserInfoForm()
        {
            InitializeComponent();

            txtUserId.Text = UserInfo.DB_AppUser_Id.ToString();
            txtWinUser.Text = UserInfo.WindowsUser;
            txtFullName.Text = UserInfo.FullName;
            txtEmail.Text = UserInfo.EmailAddress;

            txtMachine.Text = UserInfo.MachineName;
            txtDomain.Text = UserInfo.DomainName;
            txtOs.Text = UserInfo.OsVersion;

        }

        public AboutUserInfoForm(int UserId)
        {
            InitializeComponent();

            txtUserId.Text = UserInfo.DB_AppUser_Id.ToString();
            txtWinUser.Text = UserInfo.WindowsUser;
            txtFullName.Text = UserInfo.FullName;
            txtEmail.Text = UserInfo.EmailAddress;
            
        }

        //public AboutUserInfoForm(string [] UserInfos)
    }
}
