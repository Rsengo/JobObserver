using System.Linq;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models;
using Vacancies.Dto.Models;
using Vacancies.Dto.Models.Driving;
using Vacancies.Dto.Models.Employers;
using Vacancies.Dto.Models.Employments;
using Vacancies.Dto.Models.Geographic;
using Vacancies.Dto.Models.Industries;
using Vacancies.Dto.Models.Languages;
using Vacancies.Dto.Models.Salaries;
using Vacancies.Dto.Models.Schedules;
using Vacancies.Dto.Models.Skills;
using Vacancies.Dto.Models.Statuses;
using Vacancies.Dto.Models.Tests;

namespace Vacancies.Dto.Profiles
{
    public class VacancyProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Vacancy, DtoVacancy>()
                .ForMember(
                    d => d.Employer, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEmployer>(s.Employer)))
                .ForMember(
                    d => d.Address, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoAddress>(s.Address)))
                .ForMember(
                    d => d.Department, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoDepartment>(s.Department)))
                .ForMember(
                    d => d.Employment, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoEmployment>(s.Employment)))
                .ForMember(
                    d => d.Salary, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSalary>(s.Salary)))
                .ForMember(
                    d => d.Schedule, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSchedule>(s.Schedule)))
                .ForMember(
                    d => d.VacancyStatus,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoVacancyStatus>(s.VacancyStatus)))
                .ForMember(
                    d => d.Industry,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoIndustry>(s.Industry)))

                .ForMember(
                    d => d.DrivingLicenseTypes, 
                    o => o.MapFrom(
                        s => s.DrivingLicenseTypes
                            .Select(x => x.DrivingLicenseType)
                            .Select(Mapper.Map<DtoDrivingLicenseType>)))
                .ForMember(
                    d => d.KeySkills, 
                    o => o.MapFrom(
                        s => s.KeySkills
                            .Select(x => x.Skill)
                            .Select(Mapper.Map<DtoSkill>)))
                .ForMember(
                    d => d.Languages, 
                    o => o.MapFrom(
                        s => s.Languages.Select(Mapper.Map<DtoLanguageSkill>)))
                .ForMember(
                    d => d.Tests, 
                    o => o.MapFrom(
                        s => s.Tests.Select(Mapper.Map<DtoVacancyTest>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<Vacancy, DtoVacancy>()
                .ForMember(
                    d => d.Employer,
                    o => o.Ignore())
                .ForMember(
                    d => d.Address,
                    o => o.Ignore())
                .ForMember(
                    d => d.Department,
                    o => o.Ignore())
                .ForMember(
                    d => d.Employment,
                    o => o.Ignore())
                .ForMember(
                    d => d.Salary,
                    o => o.Ignore())
                .ForMember(
                    d => d.Schedule,
                    o => o.Ignore())
                .ForMember(
                    d => d.VacancyStatus,
                    o => o.Ignore())

                .ForMember(
                    d => d.DrivingLicenseTypes,
                    o => o.Ignore())
                .ForMember(
                    d => d.KeySkills,
                    o => o.Ignore())
                .ForMember(
                    d => d.Languages,
                    o => o.Ignore())
                .ForMember(
                    d => d.Tests,
                    o => o.Ignore());
        }
    }
}
