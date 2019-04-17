using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Employers.Db.Dto.Models;

namespace Employers.Db.Synchronization.Events
{
    public class PartnersChanged : 
        EntityChangedIntegrationEvent<DtoPartners>
    {
    }
}
