using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;

namespace EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        //COMENTADO PARA ENVIAR MAILS SIN ADJUNTOS
        //public IFormFileCollection Attachments { get; set; }
        //public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress("GEDEF", x)));
            Subject = subject;
            Content = content;
            //COMENTADO PARA ENVIAR MAILS SIN ADJUNTOS
            //Attachments = attachments;
        }
    }

}
