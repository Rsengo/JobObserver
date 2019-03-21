using System.Linq;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Login.Db.Models.Contacts;
using Login.Dto.Models.Contacts;

namespace Login.Dto.Profiles.Contacts
{
    public class ContactProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Contact, DtoContact>()
                .ForMember(
                    d => d.Phone,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoPhone>(s.Phone)))
                .ForMember(
                    d => d.AdditionalPhone,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoPhone>(s.AdditionalPhone)))
                .ForMember(
                    d => d.Sites,
                    o => o.MapFrom(
                        s => s.Sites.Select(Mapper.Map<DtoSite>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoContact, Contact>()
                .ForMember(
                    d => d.Phone,
                    o => o.Ignore())
                .ForMember(
                    d => d.AdditionalPhone,
                    o => o.Ignore())
                .ForMember(
                    d => d.Sites,
                    o => o.Ignore());
        }
    }
}
