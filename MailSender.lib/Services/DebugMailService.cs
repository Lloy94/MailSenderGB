using System.Diagnostics;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
    public class DebugMailService : IMailService
    {
        private readonly IStatistic _Statistic;

        public DebugMailService(IStatistic Statistic) => _Statistic = Statistic;

        public void SendEmail(Sender _sender, Recipient _recipient, Message _message, Server _server)
        {
            Debug.WriteLine($"Отправка почты от {_sender.Address} к {_recipient.Address}: {_message.Title} - {_message.Text}");
            _Statistic.MessageSended();
        }
    }
}