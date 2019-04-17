using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Geographic.Metro;

namespace Vacancies.Db.Synchronization.Events.Geographic.Metro
{
    public class StationsChanged : 
        EntityChangedIntegrationEvent<DtoStation>
    {
    }
}
