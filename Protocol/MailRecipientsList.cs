using System;
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
    public partial class MailRecipientsList : Form
    {
        public MailRecipientsList()
        {
            InitializeComponent();
        }

        public MailRecipientsList(int ProtokolId)
        {
            InitializeComponent();

            ShowRecipientsToListView(lvRep, ProtokolId);

            /*
            string RecipientsTo = "";
            string RecipientsCc = "";
            string RecipientsBcc = "";

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT R.ToCcBcc, T.Name, R.MailAddress, R.ExchName " +
                "FROM [dbo].[ReceiverList] R left outer join [dbo].[ToCcBcc] T on T.Id = R.ToCcBcc WHERE R.ProtokId = " + Protok_Id_For_Updates;
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

            mailRec.txtRecipientsTo.Text = RecipientsTo;
            mailRec.txtRecipientsCc.Text = RecipientsCc;
            mailRec.txtRecipientsBcc.Text = RecipientsBcc;
*/
        }

        public void ShowRecipientsToListView(ListView lvReport, int ProtokolId)
        {
            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT R.ToCcBcc, T.Name, R.MailAddress, R.ExchName " +
                "FROM [dbo].[ReceiverList] R left outer join [dbo].[ToCcBcc] T on T.Id = R.ToCcBcc " + 
                "WHERE R.ProtokId = " + ProtokolId + 
                " ORDER BY R.ToCcBcc ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = { reader["Name"].ToString(), reader["MailAddress"].ToString(), reader["ExchName"].ToString() };

                    ListViewItem listViewItem = new ListViewItem(row);
                    lvReport.Items.Add(listViewItem);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public List<Recipient> FillRecList(int ProtokolId)
        {
            List<Recipient> ret = new List<Recipient>();

            SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
            string SelectSt = "SELECT R.ToCcBcc, T.Name, R.MailAddress, R.ExchName " +
                "FROM [dbo].[ReceiverList] R left outer join [dbo].[ToCcBcc] T on T.Id = R.ToCcBcc " +
                "WHERE R.ProtokId = " + ProtokolId +
                " ORDER BY R.ToCcBcc ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    ret.Add(new Recipient() { ExchName = reader["ExchName"].ToString(), ExchTypeStr = reader["Name"].ToString() });
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
