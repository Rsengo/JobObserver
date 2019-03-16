﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.Dto.Models.Specializations;
using Dictionaries.Dto.Models.Users;

namespace Dictionaries.EventBus.Events.Users
{
    public class GendersChanged : 
        EntityChangedIntegrationEvent<DtoGender>
    {
    }
}
