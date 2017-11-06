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
