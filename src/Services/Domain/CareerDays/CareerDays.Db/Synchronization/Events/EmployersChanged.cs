using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Db.Dto.Models;

namespace CareerDays.Db.Synchronization.Events
{
    public class EmployersChanged : 
        EntityChangedIntegrationEvent<DtoEmployer>
    {
    }
}
