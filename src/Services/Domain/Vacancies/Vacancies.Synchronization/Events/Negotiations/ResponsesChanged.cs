using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Languages;
using Vacancies.Dto.Models.Negotiations;

namespace Vacancies.Synchronization.Events.Negotiations
{
    public class ResponsesChanged : 
        EntityChangedIntegrationEvent<DtoResponse>
    {
    }
}
