using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Employments;

namespace Resumes.Synchronization.Events.Employments
{
    public class EmploymentsChanged : 
        EntityChangedIntegrationEvent<DtoEmployment>
    {
    }
}
