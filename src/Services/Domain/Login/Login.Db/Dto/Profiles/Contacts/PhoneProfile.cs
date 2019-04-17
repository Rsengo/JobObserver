using BuildingBlocks.AutoMapper;
using Login.Db.Models.Contacts;
using Login.Db.Dto.Models.Contacts;

namespace Login.Db.Dto.Profiles.Contacts
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
