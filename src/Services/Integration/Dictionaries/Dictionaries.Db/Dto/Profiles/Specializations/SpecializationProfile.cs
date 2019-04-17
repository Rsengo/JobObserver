using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Specializations;
using Dictionaries.Db.Dto.Models.Specializations;

namespace Dictionaries.Db.Dto.Profiles.Specializations
{
    public class SpecializationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Specialization, DtoSpecialization>()
                .ForMember(
                    d => d.Parent,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSpecialization>(s.Parent)));

            CreateMap<Specialization, DtoSpecializationSync>()
                .ForMember(
                    dest => dest.Specializations,
                    opt => opt.MapFrom(
                        src => src.Specializations.Select(Mapper.Map<DtoSpecializationSync>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSpecialization, Specialization>()
                .ForMember(
                    d => d.Parent,
                    o => o.MapFrom(
                        s => Mapper.Map<Specialization>(s.Parent)));

            CreateMap<DtoSpecializationSync, Specialization>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Specializations,
                    opt => opt.MapFrom(
                        s => s.Specializations.Select(Mapper.Map<Specialization>)));
        }
    }
}
