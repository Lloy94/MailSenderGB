using System;
using System.Collections.Generic;
using System.Linq;
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
            using var message = new MailMessage(Data.TestData.Senders[SendersList.SelectedIndex].Address, Data.TestData.Recipients[RecepientList.SelectedIndex].Address);

            using var client = new SmtpClient(ServersList.SelectedItem.ToString());
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = "",
                Password = ""
            };

            try
            {
                client.Send(message);
                MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SmtpException smtp_exception)
            {
                MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
