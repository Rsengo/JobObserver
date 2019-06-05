using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using Notifications.EventBus.Events;
using Notifications.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.EventBus.EventHandlers
{
    public class UsersChangedHandler : IIntegrationEventHandler<UsersChanged>
    {
        private readonly IEventBus _eventBus;

        public UsersChangedHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(UsersChanged @event)
        {
            var createdNotifications = @event.Created.Select(x => new EmailNotification
            {
                Theme = "Регистрация в приложении JobObserver",
                Body = "Вы успешно зарегистрированы!",
                To = x.Email
            });

            var updatedNotifications = @event.Updated.Select(x => new EmailNotification
            {
                Theme = "Обновление информации о пользователе",
                Body = "Информация о вашем аккаунте была успешна изменена!",
                To = x.Email
            });

            var createdEvents = createdNotifications.Select(x => new EmailSendEvent(x));
            var updatedEvents = createdNotifications.Select(x => new EmailSendEvent(x));

            var events = createdEvents.Concat(updatedEvents);

            foreach (var emailEvent in events)
            {
                _eventBus.Publish(emailEvent);
            }

            return Task.CompletedTask;
        }
    }
}
