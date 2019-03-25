using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Users;
using Dictionaries.Dto.Models.Users;

namespace Dictionaries.Dto.Profiles.Users
{
    public class GenderProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Gender, DtoGender>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoGender, Gender>();
        }
    }
}
