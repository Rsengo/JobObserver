using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Specializations;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Dto.Profiles.Specializations
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
