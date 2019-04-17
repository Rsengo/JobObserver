using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Applicants;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Negotiations;
using Resumes.Db.Dto.Models.Specializations;

namespace Resumes.Db.Synchronization.Events.Applicants
{
    public class GendersChanged : 
        EntityChangedIntegrationEvent<DtoGender>
    {
    }
}
