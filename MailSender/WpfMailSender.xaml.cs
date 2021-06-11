using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }
        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            using var message = new MailMessage("mcdos14@yandex.ru", "mcdos1485@gmail.com");
            message.Subject = "Тестовое сообщение от " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff");
            message.Body = "Тело тестового сообщения " + DateTime.Now.ToString("F");

            //message.Attachments.Add(new Attachment());

            using var client = new SmtpClient("smtp.yandex.ru", 25)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = LoginEdit.Text,
                    SecurePassword = PasswordEdit.SecurePassword,
                }
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