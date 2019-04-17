using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Tests;
using Vacancies.Db.Dto.Models.Tests;

namespace Vacancies.Db.Dto.Profiles.Tests
{
    public class VacancyTestProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<VacancyTest, DtoVacancyTest>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoVacancyTest, VacancyTest>()
                .ForMember(d => d.Vacancy, o => o.Ignore());
        }
    }
}
