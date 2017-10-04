using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.SqlClient;
using System.Data;

namespace Protocol
{
    class outlookForms
    {
        public outlookForms()
        {
            try
            {
                //var outlookApplication = new Outlook.Application();
                outlookApplication = new Outlook.Application();
                snd = outlookApplication.Session.GetSelectNamesDialog();

                RecipientsList = new List<Recipient>();

                CurrentUserName = snd.Session.CurrentUser.Name;
                CurrentUserMail = snd.Session.CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        private Outlook.SelectNamesDialog snd;
        private Microsoft.Office.Interop.Outlook.Application outlookApplication;
        private Outlook._MailItem oMailItem;

        public void showContacts()
        {
            snd.SetDefaultDisplayMode(Outlook.OlDefaultSelectNamesDisplayMode.olDefaultMail);
            snd.NumberOfRecipientSelectors = Outlook.OlRecipientSelectors.olShowToCcBcc;

            try
            {
                snd.Display();

                int cnt = snd.Recipients.Count;

                for (int i = 1; i <= cnt; i++)
                {
                    string exchType;
                    if (((Outlook.OlMailRecipientType)snd.Recipients[i].Type) == Outlook.OlMailRecipientType.olTo)
                    {
                        exchType = "To";
                    }
                    else if (((Outlook.OlMailRecipientType)snd.Recipients[i].Type) == Outlook.OlMailRecipientType.olCC)
                    {
                        exchType = "CC";
                    }
                    else if (((Outlook.OlMailRecipientType)snd.Recipients[i].Type) == Outlook.OlMailRecipientType.olBCC)
                    {
                        exchType = "BCC";
                    }
                    else
                    {
                        exchType = ((Outlook.OlMailRecipientType)snd.Recipients[i].Type).ToString();
                    }

                    string exchName = snd.Recipients[i].Name;
                    string exchUser = snd.Recipients[i].AddressEntry.GetExchangeUser().PrimarySmtpAddress;
                    string exchCompany = snd.Recipients[i].AddressEntry.GetExchangeUser().CompanyName;

                    RecipientsList.Add(new Recipient(exchName, exchUser, exchType, exchCompany));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public void fillRecipientList(string RecTo, string RecCc, string RecBcc)
        {
            string[] recs;
            
            if (RecTo.Trim().Length > 0)
            {
                recs = RecTo.Split(';');

                foreach (string thisRec in recs)
                {
                    if (thisRec.Trim().Length > 0)
                    {
                        RecipientsList.Add(new Recipient("", thisRec.Trim(), "To", ""));
                    }
                }
            }

            if (RecCc.Trim().Length > 0)
            {
                recs = RecCc.Split(';');

                foreach (string thisRec in recs)
                {
                    if (thisRec.Trim().Length > 0)
                    {
                        RecipientsList.Add(new Recipient("", thisRec.Trim(), "CC", ""));
                    }
                }
            }

            if (RecBcc.Trim().Length > 0)
            {
                recs = RecBcc.Split(';');

                foreach (string thisRec in recs)
                {
                    if (thisRec.Trim().Length > 0)
                    {
                        RecipientsList.Add(new Recipient("", thisRec.Trim(), "BCC", ""));
                    }
                }
            }

        }

        private void FillMailForm(int protokId, string subject, string body, List<string> attachments)
        {
            ProtokId = protokId;
            Subject = subject;
            Body = body;
            Attachments = attachments;

            oMailItem = (Outlook._MailItem)outlookApplication.CreateItem(Outlook.OlItemType.olMailItem);

            //oMailItem.To = "";
            //oMailItem.CC = "";
            //oMailItem.BCC = "";

            Outlook.Recipients oRecips = oMailItem.Recipients;
            foreach (Recipient thisRec in RecipientsList)
            {
                //string strToAdd = thisRec.ExchUser + "; ";
                if (thisRec.ExchTypeStr == "To")
                {
                    //oMailItem.To += strToAdd;
                    Outlook.Recipient oTORecip = oRecips.Add(thisRec.ExchUser);
                    oTORecip.Type = (int)Outlook.OlMailRecipientType.olTo;
                    oTORecip.Resolve();
                }
                else if (thisRec.ExchTypeStr == "CC")
                {
                    //oMailItem.CC += strToAdd;
                    Outlook.Recipient oCCRecip = oRecips.Add(thisRec.ExchUser);
                    oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecip.Resolve();
                }
                else if (thisRec.ExchTypeStr == "BCC")
                {
                    //oMailItem.BCC += strToAdd;
                    Outlook.Recipient oBCCRecip = oRecips.Add(thisRec.ExchUser);
                    oBCCRecip.Type = (int)Outlook.OlMailRecipientType.olBCC;
                    oBCCRecip.Resolve();
                }
            }

            string test = oMailItem.To;
            test = oMailItem.CC;
            test = oMailItem.BCC;

            oMailItem.Subject = subject;
            oMailItem.Body = body;

            foreach (string attachmentPath in attachments)
            {
                oMailItem.Attachments.Add(attachmentPath);
            }
        }

        public void SaveMail(int ProtokId, string MailSubject, string MailBody, List<string> Attachments)
        {
            FillMailForm(ProtokId, MailSubject, MailBody, Attachments);
            oMailItem.Save(); //drafts
        }

        public void ShowMail(int ProtokId, string MailSubject, string MailBody, List<string> Attachments)
        {
            FillMailForm(ProtokId, MailSubject, MailBody, Attachments);
            oMailItem.Display(true); //show
        }

        public int exchangeTypeToInt(string exchangeType)
        {
            int ret = 0;

            RecipientType recType;



            Enum.TryParse(exchangeType, out recType);




            return ret;
        }

        private bool InertIntoTable_ReceiverList(int protokId) //INSERT [dbo].[ReceiverList]
        {
            bool ret = true;

            if (protokId > 0 && RecipientsList.Count > 0)
            {
                foreach (Recipient thisRec in RecipientsList)
                {
                    SqlConnection sqlConn = new SqlConnection(DBInfo.connectionString);
                    string InsSt = "INSERT INTO [dbo].[ReceiverList] (ProtokId, ToCcBcc, MailAddress, InsDt) VALUES (@ProtokId, @ToCcBcc, @MailAddress, getdate())";
                    try
                    {
                        sqlConn.Open();
                        SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                        cmd.Parameters.AddWithValue("@ProtokId", protokId);
                        cmd.Parameters.AddWithValue("@ToCcBcc", thisRec.ExchTypeInt());
                        cmd.Parameters.AddWithValue("@MailAddress", thisRec.ExchUser); 

                        cmd.CommandType = CommandType.Text;
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ret = false;
                        MessageBox.Show("The following error occurred: " + ex.Message);
                    }
                }
            }

            return ret;
        }

        public void SendMail(int ProtokId, string MailSubject, string MailBody, List<string> Attachments)
        {
            FillMailForm(ProtokId, MailSubject, MailBody, Attachments);
            oMailItem.Send(); //send !!!Asynchronous!!!
            
            //INSERT [dbo].[ReceiverList]
            InertIntoTable_ReceiverList(ProtokId);

            MessageBox.Show("Η αποστολή του email ολοκληρώθηκε!");
        }

        public string CurrentUserName { get; set; }
        public string CurrentUserMail { get; set; }
        public List<Recipient> RecipientsList { get; set; }
        public int ProtokId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Attachments { get; set; }
    }

    public enum RecipientType
    {
        //None...
        To = 1,
        CC = 2,
        BCC = 3
    }

    class Recipient
    {
        public Recipient()
        {
        }
        public Recipient(string exchName, string exchUser, string exchType, string exchCompany)
        {
            ExchName = exchCompany;
            ExchUser = exchUser;
            ExchTypeStr = exchType;
            ExchCompany = exchCompany;
        }
        
        public string ExchName { get; set; }
        public string ExchUser { get; set; }
        public string ExchTypeStr { get; set; } //olTo: To, olCC: CC, olBCC: BCC
        public RecipientType ExchTypeEnum()
        {
            RecipientType ret;

            //Enum.TryParse(ExchTypeStr, out ret);
            ret = (RecipientType)Enum.Parse(typeof(RecipientType), ExchTypeStr);

            return ret;
        }
        public int ExchTypeInt()
        {
            int ret;

            RecipientType recType;
            recType = (RecipientType)Enum.Parse(typeof(RecipientType), ExchTypeStr);

            ret = (int)recType;

            return ret;
        }
        public string ExchCompany { get; set; }
    }
}
