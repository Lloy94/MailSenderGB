using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
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
        public static string UserName;

        public static SecureString SecurePassword;

        private EmailSendService send = new();
        public WpfMailSender()
        {
            InitializeComponent();
        }
        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            UserName = LoginEdit.Text;
            SecurePassword = PasswordEdit.SecurePassword;
            send.Send();
            
        }
    }
}