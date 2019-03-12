using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Applicants;

namespace Resumes.Synchronization.Events.Applicants
{
    public class ApplicantsChanged : 
        EntityChangedIntegrationEvent<DtoApplicant>
    {
    }
}
