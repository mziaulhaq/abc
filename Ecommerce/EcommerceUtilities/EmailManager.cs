using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace EcommerceUtilities
{
    public static class EmailManager
    {
        public static void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                var smtp = new SmtpClient
                               {
                                   Host = ConfigurationManager.AppSettings["Host"],
                                   EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"])
                               };
                var networkCred = new System.Net.NetworkCredential
                                      {
                                          UserName = ConfigurationManager.AppSettings["UserName"],
                                          Password = ConfigurationManager.AppSettings["Password"]
                                      };
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mailMessage);
            }
        }

        public static string PopulateBody(string userName, string url, string description, string filePath, string duration=null)
        {
            string body;
            using (var reader = new StreamReader(filePath))
            {
                body = reader.ReadToEnd();
            }
            if (duration != null)
            {
                body = body.Replace("{duration}", duration);
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }
    }
}
