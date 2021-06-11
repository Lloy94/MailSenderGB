﻿using System;
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
        public void Send() 
        {

            using var message = new MailMessage(MailSenderData.Sender, MailSenderData.Receiver);
            message.Subject = "Тестовое сообщение от " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff");
            message.Body = "Тело тестового сообщения " + DateTime.Now.ToString("F");

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
               // WpfMailSender.MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SmtpException smtp_exception)
            {
                //MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
