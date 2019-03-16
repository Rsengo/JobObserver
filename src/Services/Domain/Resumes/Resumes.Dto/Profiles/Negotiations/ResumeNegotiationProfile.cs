using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Negotiations;
using Resumes.Dto.Models.Negotiations;

namespace Resumes.Dto.Profiles.Negotiations
{
    public class ResumeNegotiationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeNegotiation, DtoResumeNegotiation>()
                .ForMember(
                    d => d.Response,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoResponse>(s.Response)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeNegotiation, ResumeNegotiation>()
                .ForMember(
                    d => d.Resume,
                    o => o.Ignore())
                .ForMember(
                    d => d.Response,
                    o => o.Ignore());
        }
    }
}
