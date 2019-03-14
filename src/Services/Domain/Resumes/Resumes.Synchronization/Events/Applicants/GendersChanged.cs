using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Applicants;
using Resumes.Dto.Models.Languages;
using Resumes.Dto.Models.Negotiations;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Synchronization.Events.Applicants
{
    public class GendersChanged : 
        EntityChangedIntegrationEvent<DtoGender>
    {
    }
}
