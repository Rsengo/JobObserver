using AutoMapper;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Contacts;
using Dictionaries.Db.Dto.Models.Contacts;

namespace Dictionaries.Db.Dto.Profiles.Contacts
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
