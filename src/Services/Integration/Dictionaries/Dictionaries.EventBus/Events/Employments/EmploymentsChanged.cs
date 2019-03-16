using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Employments;

namespace Dictionaries.EventBus.Events.Employments
{
    public class EmploymentsChanged : 
        EntityChangedIntegrationEvent<DtoEmployment>
    {
    }
}
