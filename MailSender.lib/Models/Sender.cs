using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    public class Sender
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MailAddress Address { get; set; }

        public string Description { get; set; }

    }
}