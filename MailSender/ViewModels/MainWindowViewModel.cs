using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Services;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly ServersRepository _ServersRepository;
        private readonly IMailService _MailService;
        private readonly IStatistic _Statistic;

        public MainWindowViewModel(
            ServersRepository ServersRepository,
            IMailService MailService,
            IStatistic Statistic)
        {
            _ServersRepository = ServersRepository;
            _MailService = MailService;
            _Statistic = Statistic;
        }

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Рассыльщик почты";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов!";

        /// <summary>Статус</summary>
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        private ICommand _ExitCommand;

        public ICommand ExitCommand => _ExitCommand
            ??= new LambdaCommand(OnExitCommandExecuted);

        private static void OnExitCommandExecuted(object _)
        {
            Application.Current.Shutdown();
        }

        private ICommand _AboutCommand;

        public ICommand AboutCommand => _AboutCommand
            ??= new LambdaCommand(OnAboutCommandExecuted);

        private static void OnAboutCommandExecuted(object _)
        {
            MessageBox.Show("Рассыльщик почты", "О программе");
        }

        private ICommand _AddServerCommand;

        public ICommand AddServerCommand => _AddServerCommand
            ??= new LambdaCommand(OnAddServerCommandExecuted);

        private static void OnAddServerCommandExecuted(object _)
        {
            Servers.Add(new Server());
        }

        private ICommand _RemoveServerCommand;

        public ICommand RemoveServerCommand => _RemoveServerCommand
            ??= new LambdaCommand(OnRemoveServerCommandExecuted);

        private static void OnRemoveServerCommandExecuted(object _)
        {
             Servers.Remove(Server);
        }

        public static Server Server { get; set; }

        public static ServersRepository Servers { get; } = new();

        public static SendersRepository Senders { get; } = new();

        public static Sender Sender { get; set; }

        private ICommand _AddSenderCommand;

        public ICommand AddSenderCommand => _AddSenderCommand
            ??= new LambdaCommand(OnAddSenderCommandExecuted);

        private static void OnAddSenderCommandExecuted(object _)
        {
            Senders.Add(new Sender());
        }

        private ICommand _RemoveSenderCommand;

        public ICommand RemoveSenderCommand => _RemoveSenderCommand
            ??= new LambdaCommand(OnRemoveSenderCommandExecuted);

        private static void OnRemoveSenderCommandExecuted(object _)
        {
            Senders.Remove(Sender);
        }

        public static RecipientsRepository Recipients { get; } = new();

        public static Recipient Recipient { get; set; }

        private ICommand _AddRecipientCommand;

        public ICommand AddRecipientCommand => _AddRecipientCommand
            ??= new LambdaCommand(OnAddRecipientCommandExecuted);

        private static void OnAddRecipientCommandExecuted(object _)
        {
            Recipients.Add(new Recipient());
        }

        private ICommand _RemoveRecipientCommand;

        public ICommand RemoveRecipientCommand => _RemoveRecipientCommand
            ??= new LambdaCommand(OnRemoveRecipientCommandExecuted);

        private static void OnRemoveRecipientCommandExecuted(object _)
        {
            Recipients.Remove(Recipient);
        }
        #region Command SendMessageCommand - Отправка почты

        /// <summary>Отправка почты</summary>
        private LambdaCommand _SendMessageCommand;

        /// <summary>Отправка почты</summary>
        public ICommand SendMessageCommand => _SendMessageCommand
            ??= new(OnSendMessageCommandExecuted);

        /// <summary>Логика выполнения - Отправка почты</summary>
        private void OnSendMessageCommandExecuted(object p)
        {
            _MailService.SendEmail("Отправитель", "Получатель", "Тема", "Тело письма");
        }

        #endregion
    }
}