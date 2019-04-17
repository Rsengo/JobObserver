using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Dto.Models.Geographic;
using Resumes.Db.Dto.Models.Geographic.Metro;

namespace Resumes.Db.Dto.Profiles.Geographic.Metro
{
    public class MetroProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Db.Models.Geographic.Metro.Metro, DtoMetro>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoMetro, Db.Models.Geographic.Metro.Metro>()
                .ForMember(
                    dest => dest.Lines, 
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Area, 
                    opt => opt.Ignore());
        }
    }
}
