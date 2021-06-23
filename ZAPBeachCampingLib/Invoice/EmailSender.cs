using System.Net;
using System.Net.Mail;

namespace ZAPBeachCampingLib.Invoice
{
    public class EmailSender
    {
        private string clientEmail;
        private SmtpClient smtpServer;

        public EmailSender(string clientEmail, string clientPassword)
        {
            this.clientEmail = clientEmail;
            smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential(clientEmail, clientPassword);
            smtpServer.EnableSsl = true;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        /// <summary>
        /// Used to send email
        /// </summary>
        public void SendEmail(string customerEmail, string subject, string message)
        {
            MailMessage mail = CreateEmail(customerEmail, subject, message);
            smtpServer.Send(mail);
            mail.Dispose();
        }

        /// <summary>
        /// Used to send image with attachement
        /// </summary>
        public void SendEmailAttachement(string customerEmail, string subject, string message, string attachmentPath)
        {
            MailMessage mail = CreateEmail(customerEmail, subject, message);
            mail.Attachments.Add(new Attachment(attachmentPath));
            smtpServer.Send(mail);
            mail.Dispose();
        }

        /// <summary>
        /// Used to creates default template for email
        /// </summary>
        private MailMessage CreateEmail(string customerEmail, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(clientEmail);
            mail.To.Add(new MailAddress(customerEmail));
            mail.Subject = subject;
            mail.Body = message;
            return mail;
        }
    }
}
