using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Languages;

namespace Resumes.Db.Synchronization.Events.Languages
{
    public class LanguageLevelsChanged : 
        EntityChangedIntegrationEvent<DtoLanguageLevel>
    {
    }
}
