using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Languages;
using Dictionaries.Db.Dto.Models.Negotiations;
using Dictionaries.Db.Dto.Models.Specializations;
using Dictionaries.Db.Dto.Models.Statuses;

namespace Dictionaries.Db.Synchronization.Events.Statuses
{
    public class ResumeStatusesChanged : 
        EntityChangedIntegrationEvent<DtoResumeStatus>
    {
    }
}
