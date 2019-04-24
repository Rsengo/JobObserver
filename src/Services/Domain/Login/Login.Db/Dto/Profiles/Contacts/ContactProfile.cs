using System.Linq;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Login.Db.Models.Contacts;
using Login.Db.Dto.Models.Contacts;

namespace Login.Db.Dto.Profiles.Contacts
{
    public class ContactProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Contact, DtoContact>()
                .ForMember(
                    d => d.Phones,
                    o => o.MapFrom(
                        s => s.Phones.Select(Mapper.Map<DtoPhone>)))
                .ForMember(
                    d => d.Sites,
                    o => o.MapFrom(
                        s => s.Sites.Select(Mapper.Map<DtoSite>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoContact, Contact>()
                .ForMember(
                    d => d.Phones,
                    o => o.MapFrom(
                        s => s.Phones.Select(Mapper.Map<Phone>)))
                .ForMember(
                    d => d.Sites,
                    o => o.MapFrom(
                        s => s.Sites.Select(Mapper.Map<Site>)))
                .ForMember(
                    d => d.User,
                    o => o.Ignore());
        }
    }
}
