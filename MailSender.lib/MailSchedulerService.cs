using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender
{
    public class MailSchedulerService : IMailService 
    {
        private readonly IMailService _MailService;
        DispatcherTimer timer = new DispatcherTimer(); // таймер
        DateTime dtSend; // дата и время отправки
        ObservableCollection<Email> emails; // коллекция email-ов адресатов

        /// <summary>
        /// Метод, в который превращаем строку из текстбокса tbTimePicker в TimeSpan
        /// </summary>
        /// <param name="strSendTime"></param>
        /// <returns></returns>
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }

            return tsSendTime;
        }

        /// <summary>
        ////Непосредственно отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails(DateTime dtSend, ObservableCollection<Email> emails)
        {
            this.dtSend = dtSend;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                _MailService.SendMails(emails);
                timer.Stop();
                MessageBox.Show("Письма отправлены.");
            }
        }
    }

}

