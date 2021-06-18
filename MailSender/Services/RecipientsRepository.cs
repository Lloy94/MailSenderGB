using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Models;

namespace MailSender.Services
{
    public class RecipientsRepository
    {
        private List<Recipient> _Recipients;

        public RecipientsRepository()
        {
            _Recipients = Enumerable.Range(1, 10)
               .Select(i => new Recipient
               {
                   Id = i,
                   Name = $"Получатель - {i}",
                   Address = $"sender-{i}@server.ru",
                   Description = $"Описание получателя {i}",
               })
               .ToList();
        }

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public Recipient Create(int Id, string Name, string Address, string Description)
        {
            var recipient = new Recipient
            {
                Id = Id,
                Name = Name,
                Address = Address,
                Description = Description
            };
            Add(recipient);
            return recipient;
        }

        public void Add(Recipient recipient)
        {
            _Recipients.Add(recipient);
        }

        public void Remove(Recipient recipient)
        {
            _Recipients.Remove(recipient);
        }
    }
}

