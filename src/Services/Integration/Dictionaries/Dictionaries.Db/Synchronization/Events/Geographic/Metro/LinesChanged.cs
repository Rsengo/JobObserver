using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Geographic.Metro;

namespace Dictionaries.Db.Synchronization.Events.Geographic.Metro
{
    public class LinesChanged : 
        EntityChangedIntegrationEvent<DtoLine>
    {
    }
}
