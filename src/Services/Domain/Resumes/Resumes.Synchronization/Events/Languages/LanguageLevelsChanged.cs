using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Languages;

namespace Resumes.Synchronization.Events.Languages
{
    public class LanguageLevelsChanged : 
        EntityChangedIntegrationEvent<DtoLanguageLevel>
    {
    }
}
