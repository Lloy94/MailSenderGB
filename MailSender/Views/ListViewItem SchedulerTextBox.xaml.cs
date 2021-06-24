using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для ListViewItem_SchedulerTextBox.xaml
    /// </summary>
    public partial class ListViewItem_SchedulerTextBox : Window
    {
        public ListViewItem_SchedulerTextBox()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem_Scheduler.RichTextBoxText = rTextBox.Selection.Text;
            this.Close();
        }
    }
}
