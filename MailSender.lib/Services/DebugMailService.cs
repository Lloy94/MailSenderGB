using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class DebugMailService : IMailService
    {
        private readonly IStatistic _Statistic;

        public DebugMailService(IStatistic Statistic) => _Statistic = Statistic;

        public void SendEmail(string From, string To, string Title, string Body)
        {
            Debug.WriteLine($"Отправка почты от {From} к {To}: {Title} - {Body}");
            _Statistic.MessageSended();
        }
    }
}