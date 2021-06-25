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
    /// Логика взаимодействия для SenderEditorDialogWindow.xaml
    /// </summary>
    public partial class SenderEditorDialogWindow : Window
    {
        public SenderEditorDialogWindow()
        {
            InitializeComponent();
        }

        private void OnIdValidationError(object Sender, ValidationErrorEventArgs E)
        {
            if (E.Action == ValidationErrorEventAction.Added)
            {
                ((Control)E.OriginalSource).ToolTip = E.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)E.OriginalSource).ClearValue(ToolTipProperty);
            }
        }
    }
}
