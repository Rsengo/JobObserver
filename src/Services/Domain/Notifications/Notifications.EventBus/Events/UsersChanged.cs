using BuildingBlocks.EventBus.Synchronization.Events;
using Notifications.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifications.EventBus.Events
{
    public class UsersChanged :
        EntityChangedIntegrationEvent<DtoUser, Guid>
    {
    }
}
