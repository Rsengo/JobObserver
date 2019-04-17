using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using EducationalInstitutions.Db.Dto.Models;

namespace EducationalInstitutions.Db.Synchronization.Events
{
    public class PartnersChanged : 
        EntityChangedIntegrationEvent<DtoPartners>
    {
    }
}
