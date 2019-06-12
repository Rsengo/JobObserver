using BuildingBlocks.EventBus.Abstractions;
using Notifications.EventBus.Events;
using Notifications.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.EventBus.EventHandlers
{
    public class MoodleEmployerRegisteredEventHandler :
        IIntegrationEventHandler<MoodleEmployerRegisteredEvent>
    {
        private readonly IEventBus _eventBus;

        public MoodleEmployerRegisteredEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(MoodleEmployerRegisteredEvent @event)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Вы успешно зарегистрированы в системе тестирования соискателей!");
            builder.AppendLine($"Имя пользователя: {@event.Username}");
            builder.AppendLine($"Пароль: {@event.Password}");

            var message = new EmailNotification
            {
                To = @event.Email,
                Theme = "Регистрация в системе тестирования соискателей прошла успешно!",
                Body = builder.ToString()
            };
            var emailEvent = new EmailSendEvent(message);

            _eventBus.Publish(emailEvent);

            return Task.CompletedTask;
        }
    }
}
