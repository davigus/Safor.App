using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safor.Services.Models
{
    public class Email
    {
        public EmailAddress From { get; set; }
        public List<EmailAddress> To { get; set; }
        public string DateString { get; set; } = DateTime.Now.ToString();
        public DateTime Date { get
            {
                DateTime.TryParse( DateString, out var date);
                return date;
            } }
        public string Body { get; set; }
        public string Subject { get; set; }
        
    }

    public class EmailAddress
    {
        public string Username { get; }
        public string Domain { get;  }
        public string DisplayName { get; }
        public string CompleteEmailAddress { get; set; }
        public EmailAddress(string emailAddress, string displayName)
        {
            CompleteEmailAddress = emailAddress;
            Username = emailAddress.Split('@')[0];
            Domain = emailAddress.Split('@')[1];
            DisplayName = displayName ?? emailAddress.Split('@')[0];
        }
    }
}
