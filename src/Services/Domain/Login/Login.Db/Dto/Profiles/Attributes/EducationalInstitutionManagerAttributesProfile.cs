﻿using BuildingBlocks.AutoMapper;
using Login.Db.Models.Attributes;
using Login.Db.Dto.Models.Attributes;

namespace Login.Db.Dto.Profiles.Attributes
{
    public class EducationalInstitutionManagerAttributesProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EducationalInstitutionManagerAttributes, DtoEducationalInstitutionManagerAttributes>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEducationalInstitutionManagerAttributes, EducationalInstitutionManagerAttributes>()
                .ForMember(
                    d => d.User, 
                    o => o.Ignore());
        }
    }
}
