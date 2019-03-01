using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Employers.Dto.Models.EducationalInstitutions;

namespace Employers.Synchronization.Events.EducationalInstitutions
{
    public class EducationalInstitutionsChanged : 
        EntityChangedIntegrationEvent<DtoEducationalInstitution>
    {
    }
}
