using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Travel.Relocation;
using Resumes.Dto.Models.Geographic;
using Resumes.Dto.Models.Travel.Relocation;

namespace Resumes.Dto.Profiles.Travel.Relocation
{
    public class RelocationPossibilityProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<RelocationPossibility, DtoRelocationPossibility>()
                .ForMember(
                    d => d.Area, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)))
                .ForMember(
                    d => d.RelocationType, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoRelocationType>(s.RelocationType)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoRelocationPossibility, RelocationPossibility>()
                .ForMember(
                    d => d.Resume, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Area, 
                    o => o.Ignore())
                .ForMember(
                    d => d.RelocationType, 
                    o => o.Ignore());
        }
    }
}
