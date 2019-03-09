using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Dto.Models;

namespace EducationalInstitutions.Dto.Profiles
{
    public class PartnersProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Partners, DtoPartners>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoPartners, Partners>()
                .ForMember(
                    d => d.EducationalInstitution,
                    o => o.Ignore());
        }
    }
}
