using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class EmailSendService
    {
        public EmailSendService() { }

        public string subject;

        public string body;

        private ErrorMessage error= new();

        private SuccessMessage success = new();
        public void Send() 
        {

            using var message = new MailMessage(MailSenderData.Sender, MailSenderData.Receiver);
            message.Subject = subject;
            message.Body = body;

            //message.Attachments.Add(new Attachment());

            using var client = new SmtpClient(MailSenderData.SmtpServer, MailSenderData.SmtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = WpfMailSender.UserName,
                    SecurePassword = WpfMailSender.SecurePassword,
                }
            };

            try
            {
                client.Send(message);
                success.ShowDialog();
            }
            catch (SmtpException smtp_exception)
            {
                error.errorMsg.Text= smtp_exception.Message;
                error.ShowDialog();
                //MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
