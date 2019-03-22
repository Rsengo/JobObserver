using AutoMapper;
using BuildingBlocks.AutoMapper;
using Login.Db.Models.Geographic;
using Login.Dto.Models.Geographic;

namespace Login.Dto.Profiles.Geographic
{
    public class AreaProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Area, DtoArea>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoArea>(src.Parent)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoArea, Area>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.MapFrom(
                        src => Mapper.Map<Area>(src.Parent)))
                .ForMember(
                    dest => dest.Areas,
                    opt => opt.Ignore());
        }
    }
}
