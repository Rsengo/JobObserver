using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Languages;
using Resumes.Dto.Models.Negotiations;

namespace Resumes.Synchronization.Events.Negotiations
{
    public class ResponsesChanged : 
        EntityChangedIntegrationEvent<DtoResponse>
    {
    }
}
