using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Geographic.Metro;

namespace Vacancies.Synchronization.Events.Geographic.Metro
{
    public class StationsChanged : 
        EntityChangedIntegrationEvent<DtoStation>
    {
    }
}
