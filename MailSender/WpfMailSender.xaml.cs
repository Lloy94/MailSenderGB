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
    public partial class WpfMailSender
    {


        public WpfMailSender()
        {
            InitializeComponent();
            //ServersList.ItemsSource = TestData.Servers;
        }

        private void Exit_OnClick(object Sender, RoutedEventArgs E)
        {
            Close();
        }

        private void About_OnClick(object Sender, RoutedEventArgs E) =>
                MessageBox.Show("Рассыльщик почты", "О программе", MessageBoxButton.OK);

        private void ServerAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.TestData.Servers.Add(new Models.Server());
            ServersList.ItemsSource = null;
            ServersList.ItemsSource = Data.TestData.Servers;
        }

        private void ServerDelete_Click(object sender, RoutedEventArgs e)
        {
            Data.TestData.Servers.RemoveAt(ServersList.SelectedIndex);
            ServersList.ItemsSource = null;
            ServersList.ItemsSource = Data.TestData.Servers;
        }

        private void SenderAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.TestData.Senders.Add(new Models.Sender());
        }

        private void SenderDelete_Click(object sender, RoutedEventArgs e)
        {
            Data.TestData.Senders.RemoveAt(SendersList.SelectedIndex);
            SendersList.ItemsSource = null;
            SendersList.ItemsSource = Data.TestData.Senders;
        }

        private void RecipientAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.TestData.Recipients.Add(new Models.Recipient());
        }

        private void RecepientRemove_Click(object sender, RoutedEventArgs e)
        {
            Data.TestData.Recipients.RemoveAt(RecepientList.SelectedIndex);
            RecepientList.ItemsSource = null;
            RecepientList.ItemsSource = Data.TestData.Recipients;
        }

        private void Shedule_Click(object sender, RoutedEventArgs e)
        {
            tbMain.SelectedIndex = 1;
        }
    }
}
