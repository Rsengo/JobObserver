using Login.Dto.Models;

namespace Login.Dto.Profiles
{
    using AutoMapper;

    using BuildingBlocks.AutoMapper;

    using Login.Db.Models;
    using Login.Dto.Models.Attributes;
    using Login.Dto.Models.Contacts;
    using Login.Dto.Models.Genders;
    using Login.Dto.Models.Geographic;

    public class UserProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<User, DtoUser>()
                .ForMember(
                    d => d.Area, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)))
                .ForMember(
                    d => d.Contacts, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoContact>(s.Contacts)))
                .ForMember(
                    d => d.EducationalInstitutionManagerAttributes,
                    o => o.MapFrom(
                        s =>
                        Mapper.Map<DtoEducationalInstitutionManagerAttributes>(
                            s.EducationalInstitutionManagerAttributes)))
                .ForMember(
                    d => d.EmployerManagerAttributes,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEmployerManagerAttributes>(s.EmployerManagerAttributes)))
                .ForMember(
                    d => d.Gender, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoGender>(s.Gender)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoUser, User>()
                .ForMember(
                    d => d.Area, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Contacts, 
                    o => o.Ignore())
                .ForMember(
                    d => d.EducationalInstitutionManagerAttributes, 
                    o => o.Ignore())
                .ForMember(
                    d => d.EmployerManagerAttributes, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Gender, 
                    o => o.Ignore());
        }
    }
}
