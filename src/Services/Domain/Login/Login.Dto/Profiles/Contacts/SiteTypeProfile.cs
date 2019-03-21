using AutoMapper;
using BuildingBlocks.AutoMapper;
using Login.Db.Models.Contacts;
using Login.Dto.Models.Contacts;

namespace Login.Dto.Profiles.Contacts
{
    public class SiteTypeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<SiteType, DtoSiteType>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSiteType, SiteType>();
        }
    }
}
