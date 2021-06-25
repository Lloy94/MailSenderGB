using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Services;
using MailSender.ViewModels.Base;
using MailSender.Views;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<Server> _ServersRepository;
        private readonly IRepository<Sender> _SendersRepository;
        private readonly IRepository<Recipient> _RecipientsRepository;
        private readonly IRepository<Message> _MessagesRepository;
        private readonly IMailService _MailService;
        private readonly IStatistic _Statistic;

        public MainWindowViewModel(
            IUserDialog UserDialog,
            IRepository<Server> ServersRepository,
            IRepository<Sender> SendersRepository,
            IRepository<Recipient> RecipientsRepository,
            IRepository<Message> MessagesRepository,
            IMailService MailService,
            IStatistic Statistic)
        {
            _UserDialog = UserDialog;
            _ServersRepository = ServersRepository;
            _SendersRepository = SendersRepository;
            _RecipientsRepository = RecipientsRepository;
            _MessagesRepository = MessagesRepository;
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

        private void OnAddServerCommandExecuted(object _)
        {
            var server = _UserDialog.AddServer();
            if (server != null)
                Servers.Add(server);
        }

        private ICommand _RemoveServerCommand;

        public ICommand RemoveServerCommand => _RemoveServerCommand
            ??= new LambdaCommand(OnRemoveServerCommandExecuted);

        private void OnRemoveServerCommandExecuted(object _)
        {
             Servers.Remove(SelectedServer);
           if(Servers.Count>0) SelectedServer = Servers.FirstOrDefault();
        }

        private ICommand _AddListViewCommand;

        public ICommand AddListViewCommand => _AddListViewCommand
            ??= new LambdaCommand(OnAddListViewCommandExecuted);

        private void OnAddListViewCommandExecuted(object _)
        {
            ListViewItems.Add(new ListViewItem_Scheduler());
        }

        private ICommand _MailShedulerCommand;

        public ICommand MailShedulerCommandCommand => _MailShedulerCommand
            ??= new LambdaCommand(OnMailShedulerCommandExecuted);

        private void OnMailShedulerCommandExecuted(object _)
        {
            //foreach (var listItem in ListViewItems)
               // MailSchedulerService.DatesEmailTexts.Add(Convert.ToDateTime(listItem.tBox.Text), listItem.TextBoxText);
        }
        public ObservableCollection<ListViewItem_Scheduler> ListViewItems { get; } = new();

        public ListViewItem_Scheduler SelectedListView { get; set; }

        private ICommand _RemoveListViewCommand;

        public ICommand RemoveListViewCommand => _RemoveListViewCommand
            ??= new LambdaCommand(OnRemoveListViewCommandExecuted);

        private void OnRemoveListViewCommandExecuted(object _)
        {
            ListViewItems.Remove(SelectedListView);
        }
        public static Server Server { get; set; }



        public static Sender Sender { get; set; }

        private ICommand _AddSenderCommand;

        public ICommand AddSenderCommand => _AddSenderCommand
            ??= new LambdaCommand(OnAddSenderCommandExecuted);

        private void OnAddSenderCommandExecuted(object _)
        {
            var sender = _UserDialog.AddSender();
            if(sender!=null)
                Senders.Add(sender);
        }

        private ICommand _RemoveSenderCommand;

        public ICommand RemoveSenderCommand => _RemoveSenderCommand
            ??= new LambdaCommand(OnRemoveSenderCommandExecuted);

        private void OnRemoveSenderCommandExecuted(object _)
        {
            Senders.Remove(SelectedSender);
            if (Senders.Count>0 ) SelectedSender = Senders.FirstOrDefault();
        }
      

        public static Recipient Recipient { get; set; }

        public Message Message { get; set; }

        public Email Email
        {
            get; set;
        }

        private ICommand _AddRecipientCommand;

        public ICommand AddRecipientCommand => _AddRecipientCommand
            ??= new LambdaCommand(OnAddRecipientCommandExecuted);

        private void OnAddRecipientCommandExecuted(object _)
        {
            Recipients.Add(new Recipient());
        }

        private ICommand _RemoveRecipientCommand;

        public ICommand RemoveRecipientCommand => _RemoveRecipientCommand
            ??= new LambdaCommand(OnRemoveRecipientCommandExecuted);

        private  void OnRemoveRecipientCommandExecuted(object _)
        {
            Recipients.Remove(SelectedRecipient);
        }
        public ObservableCollection<Server> Servers { get; } = new();
        public ObservableCollection<Sender> Senders { get; } = new();
        public ObservableCollection<Recipient> Recipients { get; } = new();
        public ObservableCollection<Message> Messages { get; } = new();

        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient { get => _SelectedRecipient; set => Set(ref _SelectedRecipient, value); }

        private Sender _SelectedSender;
        public Sender SelectedSender { get => _SelectedSender; set => Set(ref _SelectedSender, value); }

        private Server _SelectedServer;
        public Server SelectedServer { get => _SelectedServer; set => Set(ref _SelectedServer, value); }

        private Message _SelectedMessage;
        public Message SelectedMessage { get => _SelectedMessage; set => Set(ref _SelectedMessage, value); }

        #region Command LoadDataCommand - Загрузка данных

        /// <summary>Загрузка данных</summary>
        private LambdaCommand _LoadDataCommand;

        /// <summary>Загрузка данных</summary>
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new(OnLoadDataCommandExecuted);

        /// <summary>Логика выполнения - Загрузка данных</summary>
        private void OnLoadDataCommandExecuted(object p)
        {
            Servers.Clear();
            Senders.Clear();
            Recipients.Clear();
            Messages.Clear();

            foreach (var item in _ServersRepository.GetAll()) Servers.Add(item);
            SelectedServer = Servers.FirstOrDefault();

            foreach (var item in _RecipientsRepository.GetAll()) Recipients.Add(item);
            SelectedRecipient = Recipients.FirstOrDefault();

            foreach (var item in _SendersRepository.GetAll()) Senders.Add(item);
            SelectedSender = Senders.FirstOrDefault();

            foreach (var item in _MessagesRepository.GetAll()) Messages.Add(item);
            SelectedMessage = Messages.FirstOrDefault();
        }

        #endregion
        #region Command SendMessageCommand - Отправка почты

        /// <summary>Отправка почты</summary>
        private LambdaCommand _SendMessageCommand;

        /// <summary>Отправка почты</summary>
        public ICommand SendMessageCommand => _SendMessageCommand
            ??= new(OnSendMessageCommandExecuted);

        /// <summary>Логика выполнения - Отправка почты</summary>
        private void OnSendMessageCommandExecuted(object p)
        {
            var server = SelectedServer;
            var mail_sender = _MailService.GetSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);

            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var message = SelectedMessage;

            mail_sender.Send(sender.Address, recipient.Address, message.Title, message.Text);
        }

        #endregion

        #region Command EditServerCommand - Редактирование сервера

        /// <summary>Редактирование сервера</summary>
        private LambdaCommand _EditServerCommand;

        /// <summary>Редактирование сервера</summary>
        public ICommand EditServerCommand => _EditServerCommand
            ??= new(OnEditServerCommandExecuted, p => p is Server);

        /// <summary>Логика выполнения - Редактирование сервера</summary>
        private void OnEditServerCommandExecuted(object p)
        {
            if (p is not Server server) return;
            if (_UserDialog.EditServer(server))
                _ServersRepository.Update(server);
        }

        #endregion

        #region Command EditSenderCommand - Редактирование отправителя

        /// <summary>Редактирование отправителя</summary>
        private LambdaCommand _EditSenderCommand;

        /// <summary>Редактирование отправителя</summary>
        public ICommand EditSenderCommand => _EditSenderCommand
            ??= new(OnEditSenderCommandExecuted, p => p is Sender);

        /// <summary>Логика выполнения - Редактирование отправителя</summary>
        private void OnEditSenderCommandExecuted(object p)
        {
            if (p is not Sender sender) return;
            if (_UserDialog.EditSender(sender))
                _SendersRepository.Update(sender);
        }

        #endregion
    }
}