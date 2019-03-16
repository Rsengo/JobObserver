using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Employer;

namespace Dictionaries.EventBus.Events.Employer
{
    public class EmployerTypesChanged : 
        EntityChangedIntegrationEvent<DtoEmployerType>
    {
    }
}
