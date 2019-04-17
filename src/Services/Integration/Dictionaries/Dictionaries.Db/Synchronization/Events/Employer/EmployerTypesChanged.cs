using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Employer;

namespace Dictionaries.Db.Synchronization.Events.Employer
{
    public class EmployerTypesChanged : 
        EntityChangedIntegrationEvent<DtoEmployerType>
    {
    }
}
