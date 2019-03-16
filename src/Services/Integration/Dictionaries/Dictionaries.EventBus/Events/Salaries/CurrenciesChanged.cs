using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.Dto.Models.Salaries;

namespace Dictionaries.EventBus.Events.Salaries
{
    public class CurrenciesChanged : 
        EntityChangedIntegrationEvent<DtoCurrency>
    {
    }
}
