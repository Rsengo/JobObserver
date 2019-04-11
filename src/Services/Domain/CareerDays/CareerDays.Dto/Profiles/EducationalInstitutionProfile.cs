using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models;
using CareerDays.Dto.Models;

namespace CareerDays.Dto.Profiles
{
    public class EducationalInstitutionProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EducationalInstitution, DtoEducationalInstitution>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEducationalInstitution, EducationalInstitution>()
                .ForMember(d => d.CareerDays, o => o.Ignore());
        }
    }
}
