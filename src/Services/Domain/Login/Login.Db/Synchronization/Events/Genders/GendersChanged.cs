using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Db.Dto.Models.Genders;


namespace Login.Db.Synchronization.Events.Genders
{
    public class GendersChanged : 
        EntityChangedIntegrationEvent<DtoGender>
    {
    }
}
