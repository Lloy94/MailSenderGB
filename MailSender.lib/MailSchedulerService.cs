using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        static Dictionary<DateTime, string> dicDates = new();
        public static Dictionary<DateTime, string> DatesEmailTexts
        {
            get { return dicDates; }
            set
            {
                dicDates = value;
                dicDates = dicDates.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public Email _email { get => _MailService._email; set => _MailService._email = value; }



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
        public void SendEmails(ObservableCollection<Email> emails)
        {
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dicDates.Count == 0)
            {
                timer.Stop();
                MessageBox.Show("Письма отправлены.");
            }
            else if (dicDates.Keys.First<DateTime>().ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                _MailService._email._message.Text = dicDates[dicDates.Keys.First<DateTime>()];
                _MailService._email._message.Title = $"Рассылка от {dicDates.Keys.First<DateTime>().ToShortTimeString()} ";
                _MailService.SendMails(emails);
                dicDates.Remove(dicDates.Keys.First<DateTime>());
            }

        }

    }
}

