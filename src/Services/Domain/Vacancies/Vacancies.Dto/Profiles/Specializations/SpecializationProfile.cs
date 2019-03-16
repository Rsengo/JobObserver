using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Specializations;
using Vacancies.Dto.Models.Specializations;

namespace Vacancies.Dto.Profiles.Specializations
{
    public class SpecializationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Specialization, DtoSpecialization>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSpecialization, Specialization>();
        }
    }
}
