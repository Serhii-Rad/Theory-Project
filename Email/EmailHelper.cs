using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using SmtpClient = System.Net.Mail.SmtpClient;
using EAGetMail;
using Attachment = System.Net.Mail.Attachment;
using AttachmentEAMail = EAGetMail.Attachment;
using System.Runtime.Intrinsics.X86;

namespace Email
{
    public static class MailHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailFrom"></param>
        /// <param name="password"></param>
        /// <param name="emailTo"></param>
        /// <param name="subject"></param>
        /// <param name="bodyText"></param>
        /// <param name="filePath"></param>
        /// <param name="smtpClient">gmail or office365 or outlook</param>
        public static void SendEmail(string emailFrom, string password, string emailTo, string subject, string bodyText, string filePath = "", string smtpClient = "outlook")
        {
            MailMessage m = new MailMessage(emailFrom, emailTo, subject, bodyText)
            {
                Subject = subject,
                Body = bodyText
            };
            if (!string.IsNullOrEmpty(filePath))
            {
                m.Attachments.Add(new Attachment(filePath));
            }
            SmtpClient smtp = new SmtpClient($"smtp.{smtpClient}.com", 587)
            {
                Credentials = new NetworkCredential(emailFrom, password),
                EnableSsl = true
            };
            smtp.Send(m);
            m.Dispose();
            smtp.Dispose();
        }
        
        public static string GetTwoFactorCode(string login, string password, string mailServer = "outlook.office365.com", bool ssl = true)
        {
            string text = GetEmailsObjects(login, password, mailServer, ssl).Last().TextBody;
            return text.Substring(text.IndexOf("code is ") + 8, 5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="mailServer">imap.gmail.com // outlook.office365.com </param>
        /// <param name="ssl"></param>
        /// <returns></returns>
        public static List<Email> GetEmailsObjects(string login = "serhiiradsyxsense@outlook.com", string password = "1q2w#E$R5t", string mailServer = "outlook.office365.com", bool ssl = true)
        {
            List<Email> list = new List<Email>();

            MailServer oServer = new MailServer(mailServer, login, password, ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");
            oServer.SSLConnection = ssl;
            oServer.Port = ssl ? 993 : 143;

            oClient.Connect(oServer);
            MailInfo[] infos = oClient.GetMailInfos();

            foreach (MailInfo info in infos)
            {
                Email email = new Email();
                email.From = oClient.GetMail(info).From.ToString();
                email.Time = oClient.GetMail(info).ReceivedDate.ToString();
                email.Subject = oClient.GetMail(info).Subject.ToString();
                email.TextBody = oClient.GetMail(info).TextBody.ToString();
                email.Attachments = oClient.GetMail(info).Attachments.ToList();
                email.RawHTML = oClient.GetMail(info).HtmlBody.ToString();
                email.ReceivedDate = oClient.GetMail(info).ReceivedDate;
                email.Links = new List<string>();

                var links = oClient.GetMail(info).HtmlBody.ToString().Split(new string[] { @"<a href=" }, StringSplitOptions.None).ToList();
                links.RemoveAt(0);
                foreach (string link in links)
                {
                    int first = link.IndexOf(">"); ;
                    if (link.IndexOf(">") > link.IndexOf(" "))
                        first = link.IndexOf(" ");
                    email.Links.Add(link.Substring(1, first - 2));
                }
                list.Add(email);
            }
            return list;
        }

        public static void DeleteAllEmails(string login, string password, string mailServer = "outlook.office365.com", bool ssl = true)
        {
            MailServer oServer = new MailServer(mailServer, login, password, ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");
            oServer.SSLConnection = ssl;
            oServer.Port = ssl ? 993 : 143;

            oClient.Connect(oServer);
            MailInfo[] infos = oClient.GetMailInfos();
            foreach (MailInfo info in infos)
            {
                oClient.Delete(info);
            }
        }
    }

    public class Email
    {
        public string From { get; internal set; }
        public string Time { get; internal set; }
        public string Subject { get; internal set; }
        public string TextBody { get; internal set; }
        public string RawHTML { get; internal set; }
        public List<string> Links { get; internal set; }
        public DateTime ReceivedDate { get; internal set; }
        public List<AttachmentEAMail> Attachments { get; internal set; }
    }

}
