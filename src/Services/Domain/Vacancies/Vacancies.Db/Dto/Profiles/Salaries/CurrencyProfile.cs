using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Salaries;
using Vacancies.Db.Dto.Models.Salaries;

namespace Vacancies.Db.Dto.Profiles.Salaries
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
