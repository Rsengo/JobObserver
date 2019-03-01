using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Languages;

namespace Dictionaries.EventBus.Events.Languages
{
    public class LanguageLevelsChanged : 
        EntityChangedIntegrationEvent<DtoLanguageLevel>
    {
    }
}
