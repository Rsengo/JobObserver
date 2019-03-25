using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Salaries;
using Dictionaries.Dto.Models.Salaries;

namespace Dictionaries.Dto.Profiles.Salaries
{
    public class CurrencyProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Currency, DtoCurrency>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCurrency, Currency>();
        }
    }
}
