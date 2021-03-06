﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Protocol
{
    public partial class MailRecipients : Form
    {
        public MailRecipients()
        {
            InitializeComponent();
        }

        public int protokId = 0;

        public MailRecipients(int ProtokolId)
        {
            InitializeComponent();

            protokId = ProtokolId;
            btnShowRecLv.Visible = true;

            string RecipientsTo = "";
            string RecipientsCc = "";
            string RecipientsBcc = "";

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT R.ToCcBcc, T.Name, R.MailAddress, R.ExchName " +
                "FROM [dbo].[ReceiverList] R left outer join [dbo].[ToCcBcc] T on T.Id = R.ToCcBcc WHERE R.ProtokId = " + ProtokolId;
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["ToCcBcc"].ToString()) == 1) //to
                    {
                        RecipientsTo += reader["MailAddress"].ToString() + ";";
                    }
                    else if (Convert.ToInt32(reader["ToCcBcc"].ToString()) == 2) //cc
                    {
                        RecipientsCc += reader["MailAddress"].ToString() + ";";
                    }
                    else if (Convert.ToInt32(reader["ToCcBcc"].ToString()) == 3) //bcc
                    {
                        RecipientsBcc += reader["MailAddress"].ToString() + ";";
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            txtRecipientsTo.Text = RecipientsTo;
            txtRecipientsCc.Text = RecipientsCc;
            txtRecipientsBcc.Text = RecipientsBcc;
        }

        private void btnShowRecLv_Click(object sender, EventArgs e)
        {
            MailRecipientsList mailRecList = new MailRecipientsList(protokId);
            mailRecList.ShowDialog();
        }
    }
}
