using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using CareerDays.Dto.Models;

namespace CareerDays.Synchronization.Events
{
    public class EmployersChanged : 
        EntityChangedIntegrationEvent<DtoEmployer>
    {
    }
}
