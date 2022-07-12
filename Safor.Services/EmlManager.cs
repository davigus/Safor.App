using System;
using System.IO;
using MsgReader;
using Safor.Services.Models;
using System.Linq;
using System.Collections.Generic;

namespace Safor.Services
{
    public interface IEmlManager
    {
        Email GetEmailInfo();
        void RenameEmail();
    }
    public class EmlManager : IEmlManager
    {
        public string EmailPath { get; set; }

        public EmlManager(string emailPath)
        {
            EmailPath = emailPath;
        }

        public Email GetEmailInfo()
        {
            EmailPath = @"C:\Users\d.gussoni\Desktop\Davide\PersonalWorkspace\[Ticket_TK20181223_24877]_informazioni_privacy.eml";
            var fileInfo = new FileInfo(EmailPath);
            var eml = MsgReader.Mime.Message.Load(fileInfo);

            var email = new Email();

            if (eml.Headers == null)
                return null;
            else if (eml.Headers.To == null)
                return null;
            else if (!eml.Headers.To.Any(f => f.HasValidMailAddress))
                return null;


            foreach (var header in eml.Headers.To)
            {
                if (header.HasValidMailAddress)
                    email.To = new List<EmailAddress>();
                    email.To.Add(new EmailAddress(header.Address, header.DisplayName));
            }

            email.Subject = eml.Headers.Subject;
            email.From = new EmailAddress(eml.Headers.From.MailAddress.Address, eml.Headers.From.DisplayName);
            email.DateString = eml.Headers.Date;
                       
            if (eml.TextBody != null)
            {
                email.Body = System.Text.Encoding.UTF8.GetString(eml.TextBody.Body);
            }
            if (eml.HtmlBody != null)
            {
                email.Body = System.Text.Encoding.UTF8.GetString(eml.HtmlBody.Body);
            }

            return email;
            
        }

        public void RenameEmail()
        { 
            Email email = GetEmailInfo();
            string newName = $"{email.From.Domain}_{email.From.Username}_{email.Date.Year}{email.Date.Month}{email.Date.Day}_{email.Subject}";
            //string newName = $"{email.From.CompleteEmailAddress}_{email.Date.Year}{email.Date.Month}{email.Date.Day}_{email.Subject}";
            newName = newName.Length > 151? newName.Substring(0,150) : newName;
            FIleManager fIleManager = new FIleManager();
            fIleManager.RenameFile(EmailPath, newName);
        }
    }
}
