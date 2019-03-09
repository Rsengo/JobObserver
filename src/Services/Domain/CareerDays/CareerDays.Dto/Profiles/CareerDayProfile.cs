using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models;
using CareerDays.Dto.Models;
using CareerDays.Dto.Models.Geographic;

namespace CareerDays.Dto.Profiles
{
    public class CareerDayProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<CareerDay, DtoCareerDay>()
                .ForMember(
                    dest => dest.EducationalInstitution,
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoEducationalInstitution>(src.EducationalInstitution)))
                .ForMember(
                    dest => dest.Address, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoAddress>(src.Address)))
                .ForMember(
                    dest => dest.Employer, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoEmployer>(src.Employer)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCareerDay, CareerDay>()
                .ForMember(
                    dest => dest.EducationalInstitution,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Address,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Employer,
                    opt => opt.Ignore());
        }
    }
}
