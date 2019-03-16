using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.ResumeAreas;
using Resumes.Dto.Models.Geographic;
using Resumes.Dto.Models.ResumeAreas;

namespace Resumes.Dto.Profiles.ResumeAreas
{
    public class CitizenshipProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Citizenship, DtoCitizenship>()
                .ForMember(
                    d => d.Area,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCitizenship, Citizenship>()
                .ForMember(
                    d => d.Resume,
                    o => o.Ignore())
                .ForMember(
                    d => d.Area,
                    o => o.Ignore());
        }
    }
}
