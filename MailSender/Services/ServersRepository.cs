using System.Collections.ObjectModel;
using MailSender.Models;

namespace MailSender.Services
{
    public class ServersRepository : ObservableCollection<Server>
    {

        public ServersRepository() : base()
        {
            for (int i =0; i<10; i++)
            {
                var server = new Server
                {
                    Name = $"Сервер {i}",
                    Address = $"smtp.server-{i}.ru",
                    Login = $"User-{i}",
                    Password = $"Password - {i}",
                    UseSSL = i % 2 == 0
                };
                Add(server);
            }
        }

        public Server Create(string Name, string Address, int Port, bool UseSSL, string Login, string Password)
        {
            var server = new Server
            {
                Name = Name,
                Address = Address,
                Port = Port,
                UseSSL = UseSSL,
                Login = Login,
                Password = Password,
            };
            Add(server);
            return server;
        }

    }
}