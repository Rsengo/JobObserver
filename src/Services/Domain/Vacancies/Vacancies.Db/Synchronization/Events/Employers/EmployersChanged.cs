using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Employers;

namespace Vacancies.Db.Synchronization.Events.Employers
{
    public class EmployersChanged : EntityChangedIntegrationEvent<DtoEmployer>
    {
    }
}
