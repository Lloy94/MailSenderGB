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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для ListViewItem_Scheduler.xaml
    /// </summary>
    public partial class ListViewItem_Scheduler : UserControl
    {
        public string TextBoxText = RichTextBoxText;

        public static string RichTextBoxText { get; set; }
        public ListViewItem_Scheduler()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var textBox = new ListViewItem_SchedulerTextBox();
            textBox.Show();
        }

    }
}
