using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

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

        private void FillMailForm(string subject, string body)
        {
            Subject = subject;
            Body = body;

            oMailItem = (Outlook._MailItem)outlookApplication.CreateItem(Outlook.OlItemType.olMailItem);

            //oMailItem.To = "";
            //oMailItem.CC = "";
            //oMailItem.BCC = "";
            foreach (Recipient thisRec in RecipientsList)
            {
                if (thisRec.ExchType == "To")
                {
                    oMailItem.To += thisRec.ExchUser + ";";
                }
                else if (thisRec.ExchType == "CC")
                {
                    oMailItem.CC += thisRec.ExchUser + ";";
                }
                else if (thisRec.ExchType == "BCC")
                {
                    oMailItem.BCC += thisRec.ExchUser + ";";
                }
            }

            oMailItem.Subject = subject;
            oMailItem.Body = body;
            //oMailItem.Attachments

        }

        public void SaveMail(string MailSubject, string MailBody)
        {
            FillMailForm(MailSubject, MailBody);
            oMailItem.Save(); //drafts
        }

        public void ShowMail(string MailSubject, string MailBody)
        {
            FillMailForm(MailSubject, MailBody);
            oMailItem.Display(true); //show
        }

        public string CurrentUserName { get; set; }
        public string CurrentUserMail { get; set; }
        public List<Recipient> RecipientsList { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
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
            ExchType = exchType;
            ExchCompany = exchCompany;
        }

        public string ExchName { get; set; }
        public string ExchUser { get; set; }
        public string ExchType { get; set; } //olTo: To, olCC: CC, olBCC: BCC
        public string ExchCompany { get; set; }
    }
}
