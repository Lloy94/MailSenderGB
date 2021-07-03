using MailSender.Models;

namespace MailSender.Interfaces
{
    public interface IUserDialog
    {
        bool EditServer(Server server);

        bool EditSender(Sender sender);

        bool EditRecipient(Recipient recipient);

        Sender AddSender();

        Server AddServer();

        Recipient AddRecipient();
    } 
}