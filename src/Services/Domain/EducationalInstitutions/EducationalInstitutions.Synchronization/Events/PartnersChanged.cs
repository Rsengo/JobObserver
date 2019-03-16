using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using EducationalInstitutions.Dto.Models;

namespace EducationalInstitutions.Synchronization.Events
{
    public class PartnersChanged : 
        EntityChangedIntegrationEvent<DtoPartners>
    {
    }
}
