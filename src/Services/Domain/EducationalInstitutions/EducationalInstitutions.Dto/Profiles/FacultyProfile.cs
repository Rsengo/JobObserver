﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Dto.Models;

namespace EducationalInstitutions.Dto.Profiles
{
    public class FacultyProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Faculty, DtoFaculty>()
                .ForMember(
                    d => d.EducationalInstitution,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEducationalInstitution>(s.EducationalInstitution)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoFaculty, Faculty>()
                .ForMember(
                    d => d.EducationalInstitution,
                    o => o.Ignore());
        }
    }
}
