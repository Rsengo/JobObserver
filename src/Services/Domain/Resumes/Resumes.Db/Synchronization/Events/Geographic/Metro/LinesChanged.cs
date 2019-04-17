using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Geographic.Metro;

namespace Resumes.Db.Synchronization.Events.Geographic.Metro
{
    public class LinesChanged : 
        EntityChangedIntegrationEvent<DtoLine>
    {
    }
}
