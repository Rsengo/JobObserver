using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Languages;

namespace Vacancies.Synchronization.Events.Languages
{
    public class LanguageLevelsChanged : 
        EntityChangedIntegrationEvent<DtoLanguageLevel>
    {
    }
}
