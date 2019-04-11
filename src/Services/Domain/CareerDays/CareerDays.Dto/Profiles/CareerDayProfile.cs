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
    using System.Linq;

    public class CareerDayProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<CareerDay, DtoCareerDay>()
                .ForMember(
                    dest => dest.EducationalInstitution,
                    opt => opt.MapFrom(
                        src => src.EducationalInstitutions
                            .Select(x => x.EducationalInstitution)
                            .Select(Mapper.Map<DtoEducationalInstitution>)))
                .ForMember(
                    dest => dest.Address, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoAddress>(src.Address)))
                .ForMember(
                    dest => dest.Employer, 
                    opt => opt.MapFrom(
                        src => src.Employers
                            .Select(x => x.Employer)
                            .Select(Mapper.Map<DtoEmployer>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCareerDay, CareerDay>()
                .ForMember(
                    dest => dest.EducationalInstitutions,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Address,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Employers,
                    opt => opt.Ignore());
        }
    }
}
