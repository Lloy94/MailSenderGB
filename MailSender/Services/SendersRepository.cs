using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Models;

namespace MailSender.Services
{
    public class SendersRepository
    {

        private List<Sender> _Senders;

        public SendersRepository()
        {
            _Senders = Enumerable.Range(1, 10)
               .Select(i => new Sender
               {
                   Id = i,
                   Name = $"Отправитель - {i}",
                   Address = $"sender-{i}@server.ru",
                   Description = $"Описание отправителя {i}",
               })
               .ToList();
        }

        public IEnumerable<Sender> GetAll() => _Senders;

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

        public void Add(Sender sender)
        {
            _Senders.Add(sender);
        }

        public void Remove(Sender sender)
        {
            _Senders.Remove(sender);
        }
    }
}
