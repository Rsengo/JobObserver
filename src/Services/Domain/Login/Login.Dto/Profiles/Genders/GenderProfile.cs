using BuildingBlocks.AutoMapper;
using Login.Db.Models.Genders;
using Login.Dto.Models.Genders;

namespace Login.Dto.Profiles.Genders
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
