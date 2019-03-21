using BuildingBlocks.AutoMapper;
using Login.Db.Models.Contacts;
using Login.Dto.Models.Contacts;

namespace Login.Dto.Profiles.Contacts
{
    public class PhoneProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Phone, DtoPhone>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoPhone, Phone>();
        }
    }
}
