using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Salaries;
using Vacancies.Dto.Models.Salaries;

namespace Vacancies.Dto.Profiles.Salaries
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
