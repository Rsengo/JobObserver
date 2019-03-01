using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using EducationalInstitutions.Dto.Models.Employers;

namespace EducationalInstitutions.Synchronization.Events.Employers
{
    public class EmployersChanged : 
        EntityChangedIntegrationEvent<DtoEmployer>
    {
    }
}
