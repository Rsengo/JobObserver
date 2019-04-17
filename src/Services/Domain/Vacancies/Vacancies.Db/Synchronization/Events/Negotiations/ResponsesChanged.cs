using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Negotiations;

namespace Vacancies.Db.Synchronization.Events.Negotiations
{
    public class ResponsesChanged : 
        EntityChangedIntegrationEvent<DtoResponse>
    {
    }
}
