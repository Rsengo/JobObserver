using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Db.Dto.Models.Geographic.Metro;

namespace CareerDays.Db.Synchronization.Events.Geographic.Metro
{
    public class LinesChanged : 
        EntityChangedIntegrationEvent<DtoLine>
    {
    }
}
