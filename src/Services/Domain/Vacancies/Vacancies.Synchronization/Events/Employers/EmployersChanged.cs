using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Employers;

namespace Vacancies.Synchronization.Events.Employers
{
    public class EmployersChanged : EntityChangedIntegrationEvent<DtoEmployer>
    {
    }
}
