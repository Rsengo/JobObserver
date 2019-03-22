using BuildingBlocks.AutoMapper;
using Login.Db.Models.Contacts;
using Login.Dto.Models.Contacts;
using AutoMapper;

namespace Login.Dto.Profiles.Contacts
{
    public class SiteProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Site, DtoSite>()
                .ForMember(
                    d => d.Type, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSiteType>(s.Type)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSite, Site>()
                .ForMember(
                    d => d.Contact, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Type, 
                    o => o.Ignore());
        }
    }
}
