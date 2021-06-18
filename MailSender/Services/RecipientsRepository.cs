using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Models;

namespace MailSender.Services
{
    public class RecipientsRepository : ObservableCollection<Recipient>
    {
        public RecipientsRepository() : base ()
        {
            for (int i = 0; i < 10; i++)
            {
                var recipient = new Recipient
                {
                    Id = i,
                    Name = $"Получатель - {i}",
                    Address = $"recipient-{i}@server.ru",
                    Description = $"Описание получателя {i}",
                };
                Add(recipient);
            }
        }

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
      
    }
}

