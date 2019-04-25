using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Applicants;

namespace Resumes.Db.Synchronization.Events.Applicants
{
    public class ApplicantsChanged : 
        EntityChangedIntegrationEvent<DtoApplicant, Guid>
    {
    }
}
