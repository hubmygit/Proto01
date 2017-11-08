using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Proced
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Folders
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Company Com { get; set; }

        public Proced Proc { get; set; }

        //public string Description { get; set; }
    }

    public class Email
    {
        public int ProtokId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public void addRecipientsToBody(List<Recipient> RecipientsList)
        {
            string AttnTo = "";
            string OthersCC = "";
            foreach (Recipient rec in RecipientsList)
            {
                if (rec.ExchTypeStr.ToUpper() == "TO")
                {
                    AttnTo += rec.ExchName + ",";
                }
                else if (rec.ExchTypeStr.ToUpper() == "CC")
                {
                    OthersCC += rec.ExchName + ",";
                }
            }
            if (AttnTo.Length > 0)
            {
                AttnTo = AttnTo.Substring(0, AttnTo.Length - 1);
            }
            else
            {
                AttnTo = "-";
            }
            if (OthersCC.Length > 0)
            {
                OthersCC = OthersCC.Substring(0, OthersCC.Length - 1);
            }
            else
            {
                OthersCC = "-";
            }

            this.Body += "\r\n" + "Αρμόδιος: " + AttnTo + "\r\n" + "Κυκλοφορία: " + OthersCC;
        }

        public void addRecipientsToBody()
        {
            //this.Body += "\r\n" + "Αρμόδιος: " + "-" + "\r\n" + "Κυκλοφορία: " + "-";
            this.Body += "\r\nΑρμόδιος: -\r\nΚυκλοφορία: -";
        }
    }

    public class AppUsers
    {
        public int Id { get; set; }
        public string WinUser { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string InsDate { get; set; }
    }
}
