using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Db.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Db.Synchronization.Events.Users
{
    public class UsersChanged: 
        EntityChangedIntegrationEvent<DtoUser, string>
    {
        public UsersChanged(ApplicantsChanged applicantsChanged)
        {
            Created = applicantsChanged.Created;
            Updated = applicantsChanged.Updated;
            Deleted = applicantsChanged.Deleted;
        }
    }
}
