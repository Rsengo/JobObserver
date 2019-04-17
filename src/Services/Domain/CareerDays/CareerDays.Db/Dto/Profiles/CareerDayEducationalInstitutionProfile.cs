using BuildingBlocks.AutoMapper;

using CareerDays.Db.Models;
using CareerDays.Db.Dto.Models;

namespace CareerDays.Db.Dto.Profiles
{
    public class CareerDayEducationalInstitutionProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<CareerDayEducationalInstitution, DtoCareerDayEducationalInstitution>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCareerDayEducationalInstitution, CareerDayEducationalInstitution>()
                .ForMember(d => d.CareerDay, o => o.Ignore())
                .ForMember(d => d.EducationalInstitution, o => o.Ignore());
        }
    }
}
