using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Employments;

namespace Vacancies.Synchronization.Events.Employments
{
    public class EmploymentsChanged : 
        EntityChangedIntegrationEvent<DtoEmployment>
    {
    }
}
