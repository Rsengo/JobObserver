using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Salaries;
using Resumes.Dto.Models.Salaries;

namespace Resumes.Dto.Profiles.Salaries
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
