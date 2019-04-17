using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Negotiations;

namespace Resumes.Db.Synchronization.Events.Negotiations
{
    public class ResponsesChanged : 
        EntityChangedIntegrationEvent<DtoResponse>
    {
    }
}
