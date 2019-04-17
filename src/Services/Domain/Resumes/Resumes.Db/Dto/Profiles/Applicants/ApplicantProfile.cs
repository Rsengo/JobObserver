using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Dto.Models.Applicants;
using Resumes.Db.Dto.Models.Geographic;

namespace Resumes.Db.Dto.Profiles.Applicants
{
    public class ApplicantProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Applicant, DtoApplicant>()
                .ForMember(
                    d => d.Area, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)))
                .ForMember(
                    d => d.Gender, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoGender>(s.Gender)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoApplicant, Applicant>()
                .ForMember(
                    d => d.Area, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Gender, 
                    o => o.Ignore())
                .ForMember(
                    d => d.FullName, 
                    o => o.Ignore());
        }
    }
}
