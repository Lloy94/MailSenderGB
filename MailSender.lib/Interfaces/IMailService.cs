using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using MailSender.Models;
namespace MailSender.Interfaces
{
    public interface IMailService
    {
        void SendEmail(Email _email)
        {
            if (_email==null || _email._message == null || _email._recipient == null||_email._server == null || _email._sender == null) return;
            using var message = new MailMessage(_email._sender.Address, _email._recipient.Address);
            message.Subject = _email._message.Title;
            message.Body = _email._message.Text;
            using var client = new SmtpClient(_email._server.Address,_email._server.Port)
            {
                EnableSsl = _email._server.UseSSL,
                Credentials = new NetworkCredential
                {
                    UserName = _email._server.Login,
                    Password = _email._server.Password,
                }
            };
            try
            {
                client.Send(message);

            }
            catch (SmtpException smtp_exception) { }

        }

        void SendMails(ObservableCollection<Email> emails)
        {
            foreach (Email email in emails)
            {
                SendEmail(email);
            }
        }
    }
}
