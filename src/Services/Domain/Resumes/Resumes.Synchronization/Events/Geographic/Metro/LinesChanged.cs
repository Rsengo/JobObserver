using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Geographic.Metro;

namespace Resumes.Synchronization.Events.Geographic.Metro
{
    public class LinesChanged : 
        EntityChangedIntegrationEvent<DtoLine>
    {
    }
}
