using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Statuses;

namespace Vacancies.Synchronization.Events.Statuses
{
    public class VacancyStatusesChanged : EntityChangedIntegrationEvent<DtoVacancyStatus>
    {
    }
}
