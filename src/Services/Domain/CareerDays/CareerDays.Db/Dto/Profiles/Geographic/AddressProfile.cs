using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models.Geographic;
using CareerDays.Db.Dto.Models.Geographic;
using CareerDays.Db.Dto.Models.Geographic.Metro;

namespace CareerDays.Db.Dto.Profiles.Geographic
{
    public class AddressProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Address, DtoAddress>()
                .ForMember(
                    dest => dest.Area, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoArea>(src.Area)))
                .ForMember(
                    dest => dest.Station, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoStation>(src.Station)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoAddress, Address>()
                .ForMember(
                    dest => dest.Area,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Station,
                    opt => opt.Ignore());
        }
    }
}
