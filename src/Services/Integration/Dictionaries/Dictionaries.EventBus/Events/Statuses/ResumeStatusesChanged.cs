using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.Dto.Models.Specializations;
using Dictionaries.Dto.Models.Statuses;

namespace Dictionaries.EventBus.Events.Statuses
{
    public class ResumeStatusesChanged : 
        EntityChangedIntegrationEvent<DtoResumeStatus>
    {
    }
}
