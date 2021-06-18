﻿using System.Net;
using System.Net.Mail;
using MailSender.Models;
namespace MailSender.Interfaces
{
    public interface IMailService
    {
        void SendEmail(Sender _sender, Recipient _recipient, Message _message, Server _server) 
        {
            if (_message == null|| _recipient == null) return;
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
            try
            {
                client.Send(message);

            }
            catch (SmtpException smtp_exception) { }

        }
    }
}
