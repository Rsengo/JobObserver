using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Employments;

namespace Dictionaries.Db.Synchronization.Events.Employments
{
    public class EmploymentsChanged : 
        EntityChangedIntegrationEvent<DtoEmployment>
    {
    }
}
