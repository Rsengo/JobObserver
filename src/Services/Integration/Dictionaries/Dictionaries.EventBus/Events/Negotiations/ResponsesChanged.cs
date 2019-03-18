using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;

namespace Dictionaries.EventBus.Events.Negotiations
{
    public class ResponsesChanged : 
        EntityChangedIntegrationEvent<DtoResponse>
    {
    }
}
