using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Languages;

namespace Dictionaries.Db.Synchronization.Events.Languages
{
    public class LanguageLevelsChanged : 
        EntityChangedIntegrationEvent<DtoLanguageLevel>
    {
    }
}
