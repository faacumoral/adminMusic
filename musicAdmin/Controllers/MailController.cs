using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace musicAdmin.Controllers
{
    public class MailController
    {
        public void EnviarMail(string asunto, string body)
        {
            try
            {
                if (DataController.areMailPropertiesSet)
                {
                    ArchivoController ac = new ArchivoController();
                    ac.GetProperties();
                }
                if (!DataController.areMailPropertiesSet)
                {
                    // properties no estan seteadas, no se puede enviar mail
                    return;
                }
                SmtpClient smtpServer = new SmtpClient();
                smtpServer.Host = DataController.smtpServer;
                smtpServer.Port = DataController.smtpPort;
                smtpServer.Credentials = new System.Net.NetworkCredential(DataController.fromUsername, DataController.fromPassword);
                smtpServer.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(DataController.fromUsername);
                mail.To.Add(DataController.mailTo);
                mail.Subject = asunto;
                mail.IsBodyHtml = true;
                mail.Body = body;
                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
                ExceptionController.FullException(e, false);
            }
        }
    }
}
