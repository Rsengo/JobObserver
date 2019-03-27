using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Employers.Dto.Models;

namespace Employers.Synchronization.Events
{
    public class DepartmentsChanged :
        EntityChangedIntegrationEvent<DtoDepartment>
    {
    }
}
