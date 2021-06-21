using System.Diagnostics;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
    public class DebugMailService : IMailService
    {
        private readonly IStatistic _Statistic;

        public DebugMailService(IStatistic Statistic) => _Statistic = Statistic;

        public void SendEmail(Email _email)
        {
            if (_email == null) return;
            Debug.WriteLine($"Отправка почты от {_email._sender.Address} к {_email._recipient.Address}: {_email._message.Title} - {_email._message.Text}");
            _Statistic.MessageSended();
        }
    }
}