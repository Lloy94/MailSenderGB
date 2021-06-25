using MailSender.Interfaces;
using MailSender.Models;
using MailSender.ViewModels;
using MailSender.Views;

namespace MailSender.Services
{
    internal class WindowUserDialogService : IUserDialog
    {
        public bool EditServer(Server server)
        {
            var model = new ServerEditorDialogViewModel
            {
                Name = server.Name,
                Address = server.Address,
                Port = server.Port,
                UseSSL = server.UseSSL,
                Login = server.Login,
                Password = server.Password,
            };

            var view = new ServerEditorDialogWindow
            {
                DataContext = model
            };

            model.EditCompleted += (s, e) =>
            {
                view.DialogResult = true;
                view.Close();
            };

            model.EditCanceled += (s, e) =>
            {
                view.DialogResult = false;
                view.Close();
            };

            if (view.ShowDialog() != true)
                return false;

            server.Name = model.Name;
            server.Address = model.Address;
            server.Port = model.Port;
            server.UseSSL = model.UseSSL;
            server.Login = model.Login;
            server.Password = model.Password;

            return true;
        }

        public bool EditSender(Sender sender)
        {
            var model = new SenderEditorDialogViewModel
            {
                Name = sender.Name,
                Address = sender.Address,
                Description = sender.Description
            };

            var view = new SenderEditorDialogWindow
            {
                DataContext = model
            };

            model.EditCompleted += (s, e) =>
            {
                view.DialogResult = true;
                view.Close();
            };

            model.EditCanceled += (s, e) =>
            {
                view.DialogResult = false;
                view.Close();
            };

            if (view.ShowDialog() != true)
                return false;

            sender.Name = model.Name;
            sender.Address = model.Address;
            sender.Description = model.Description;
            return true;
        }

        public Sender AddSender()
        {
            var model = new SenderEditorDialogViewModel();

            var sender = new Sender();
            var view = new SenderEditorDialogWindow
            {
                DataContext = model
            };

            model.EditCompleted += (s, e) =>
            {
                view.DialogResult = true;
                view.Close();
            };

            model.EditCanceled += (s, e) =>
            {
                view.DialogResult = false;
                view.Close();
            };

            if (view.ShowDialog() != true)
                return null;

            sender.Name = model.Name;
            sender.Address = model.Address;
            sender.Description = model.Description;
            return sender;
        }

        public Server AddServer()
        {
            var model = new ServerEditorDialogViewModel();

            var view = new ServerEditorDialogWindow
            {
                DataContext = model
            };

            var server = new Server();

            model.EditCompleted += (s, e) =>
            {
                view.DialogResult = true;
                view.Close();
            };

            model.EditCanceled += (s, e) =>
            {
                view.DialogResult = false;
                view.Close();
            };

            if (view.ShowDialog() != true)
                return null;

            server.Name = model.Name;
            server.Address = model.Address;
            server.Port = model.Port;
            server.UseSSL = model.UseSSL;
            server.Login = model.Login;
            server.Password = model.Password;

            return server;
        }
    }
}