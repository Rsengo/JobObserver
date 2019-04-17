using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Languages;

namespace Vacancies.Db.Synchronization.Events.Languages
{
    public class LanguagesChanged : 
        EntityChangedIntegrationEvent<DtoLanguage>
    {
    }
}
