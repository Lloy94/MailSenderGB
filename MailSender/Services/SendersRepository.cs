using System.Collections.ObjectModel;
using MailSender.Models;

namespace MailSender.Services
{
    public class SendersRepository : ObservableCollection<Sender>
    {
        public SendersRepository() : base()
        {
            for (int i = 0; i < 10; i++)
            {
                var sender = new Sender
                {
                    Id = i,
                    Name = $"Отправитель - {i}",
                    Address = $"sender-{i}@server.ru",
                    Description = $"Описание отправителя {i}",
                };
               Add(sender); 
            }
        }
                
        public Sender Create(int Id, string Name, string Address, string Description)
        {
            var sender = new Sender
            {
                Id = Id,
                Name = Name,
                Address = Address,
                Description = Description
            };
            Add(sender);
            return sender;
        }

    }
}
