﻿using System.Collections.Generic;

namespace MailSender.Interfaces
{
    public interface IMailService
    {
        //void SendEmail(string From, string To, string Title, string Body);
        IMailSender GetSender(string ServerAddress, int Port, bool UseSSL, string Login, string Password);
    }

    public interface IMailSender
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);

        void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);

        void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body);
    }
}