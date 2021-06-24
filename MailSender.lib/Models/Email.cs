using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    public class Email
    {
        public Recipient _recipient { get; set; }

        public Sender _sender { get; set; }

        public Message _message { get; set; }

        public Server _server { get; set; }
        
    }
}