using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using EmailNotifications.Mailer.MailServices;

namespace EmailNotifications.API.IntegrationEvents
{
    public class EmailSendEventHandler : IIntegrationEventHandler<EmailSendEvent>
    {
        private readonly IMailService _mailer;

        public EmailSendEventHandler(IMailService mailer)
        {
            _mailer = mailer;
        }

        public Task Handle(EmailSendEvent @event)
        {
            var message = @event.Message;
            return _mailer.SendMailAsync(message);
        }
    }
}
