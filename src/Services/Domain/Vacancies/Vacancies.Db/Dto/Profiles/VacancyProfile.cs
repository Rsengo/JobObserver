using System.Linq;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models;
using Vacancies.Db.Dto.Models;
using Vacancies.Db.Dto.Models.Driving;
using Vacancies.Db.Dto.Models.Employers;
using Vacancies.Db.Dto.Models.Employments;
using Vacancies.Db.Dto.Models.Geographic;
using Vacancies.Db.Dto.Models.Industries;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Salaries;
using Vacancies.Db.Dto.Models.Schedules;
using Vacancies.Db.Dto.Models.Skills;
using Vacancies.Db.Dto.Models.Statuses;
using Vacancies.Db.Dto.Models.Tests;

namespace Vacancies.Db.Dto.Profiles
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
