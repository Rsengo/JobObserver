using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Applicants;
using Resumes.Dto.Models.Applicants;

namespace Resumes.Dto.Profiles.Applicants
{
    public class GenderProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Gender, DtoGender>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoGender, Gender>();
        }
    }
}
