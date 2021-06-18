using System.Collections.ObjectModel;
using MailSender.Models;

namespace MailSender.Services
{
    public class MessagesRepository : ObservableCollection<Message>
    { 
        public MessagesRepository() : base()
        {
            for (int i = 0; i < 100; i++)
            {
                var message = new Message
                {
                    Title = $"Сообщение {i}",
                    Text = $"Текст сообщения {i}"
                };
                Add(message);
            }
        }

        public Message Create(string Title, string Text)
        {
            var message = new Message
            {
                Title = Title,
                Text = Text,
            };
            Add(message);
            return message;
        }

    }
}