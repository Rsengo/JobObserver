using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Statuses;

namespace Vacancies.Db.Synchronization.Events.Statuses
{
    public class VacancyStatusesChanged : EntityChangedIntegrationEvent<DtoVacancyStatus>
    {
    }
}
