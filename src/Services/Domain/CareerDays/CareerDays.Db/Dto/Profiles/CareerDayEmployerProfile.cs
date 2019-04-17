using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models;
using CareerDays.Db.Dto.Models;

namespace CareerDays.Db.Dto.Profiles
{
    public class CareerDayEmployerProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<CareerDayEmployer, DtoCareerDayEmployer>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoCareerDayEmployer, CareerDayEmployer>()
                .ForMember(d => d.CareerDay, o => o.Ignore())
                .ForMember(d => d.Employer, o => o.Ignore());
        }
    }
}
