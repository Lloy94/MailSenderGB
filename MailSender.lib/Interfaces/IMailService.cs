using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MailSender.Models;

namespace MailSender.Interfaces
{
    public interface IMailService
    {
        void SendEmail(Sender _sender, Recipient _recipient, Message _message, Server _server) 
        {
            using var message = new MailMessage(_sender.Address, _recipient.Address);
            message.Subject = _message.Title;
            message.Body = _message.Text;
            using var client = new SmtpClient(_server.Address, _server.Port)
            {
                EnableSsl = _server.UseSSL,
                Credentials = new NetworkCredential
                {
                    UserName = _server.Login,
                    Password = _server.Password,
                }
            };
        }
    }
}
