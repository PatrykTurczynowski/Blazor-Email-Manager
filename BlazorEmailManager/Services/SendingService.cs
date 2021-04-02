using BlazorEmailManager.Interfaces;
using BlazorEmailManager.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;

namespace BlazorEmailManager.Services
{
    public class SendingService : ISendingService
    {
        public void SendEmails(EmailDraft emailDraft, IList<string> recipients)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(emailDraft.Sender.Name, emailDraft.Sender.Email));
                foreach (var to in recipients)
                {
                    mail.To.Add(new MailboxAddress(to, to));
                }
                mail.Subject = emailDraft.Topic;
                mail.Body = new TextPart() { Text = emailDraft.MessageText };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate(emailDraft.Sender.Email, emailDraft.Sender.Password);
                    client.Send(mail);
                    client.Disconnect(true);
                }
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }
    }
}
