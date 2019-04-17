using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models;
using Resumes.Db.Dto.Models;
using Resumes.Db.Dto.Models.Applicants;
using Resumes.Db.Dto.Models.Certificates;
using Resumes.Db.Dto.Models.Driving;
using Resumes.Db.Dto.Models.Educations;
using Resumes.Db.Dto.Models.Employments;
using Resumes.Db.Dto.Models.Experiences;
using Resumes.Db.Dto.Models.Geographic;
using Resumes.Db.Dto.Models.Geographic.Metro;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.ResumeAreas;
using Resumes.Db.Dto.Models.Salaries;
using Resumes.Db.Dto.Models.Schedules;
using Resumes.Db.Dto.Models.Skills;
using Resumes.Db.Dto.Models.Specializations;
using Resumes.Db.Dto.Models.Statuses;
using Resumes.Db.Dto.Models.Travel;
using Resumes.Db.Dto.Models.Travel.Relocation;

namespace Resumes.Db.Dto.Profiles
{
    public class ResumeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Resume, DtoResume>()
                .ForMember(
                    d => d.Education, 
                    o => o.MapFrom(
                        s => s.Education.Select(Mapper.Map<DtoEducation>)))
                .ForMember(
                    d => d.Certificates, 
                    o => o.MapFrom(
                        s => s.Certificates.Select(Mapper.Map<DtoCertificate>)))
                .ForMember(
                    d => d.Citizenship, 
                    o => o.MapFrom(
                        s => s.Citizenship
                            .Select(x => x.Area)
                            .Select(Mapper.Map<DtoArea>)))
                .ForMember(
                    d => d.DrivingLicenseTypes, 
                    o => o.MapFrom(
                        s => s.DrivingLicenseTypes
                            .Select(x => x.DrivingLicenseType)
                            .Select(Mapper.Map<DtoDrivingLicenseType>)))
                .ForMember(
                    d => d.Employments, 
                    o => o.MapFrom(
                        s => s.Employments
                            .Select(x => x.Employment)
                            .Select(Mapper.Map<DtoEmployment>)))
                .ForMember(
                    d => d.Experience, 
                    o => o.MapFrom(
                        s => s.Experience.Select(Mapper.Map<DtoExperience>)))
                .ForMember(
                    d => d.Languages, 
                    o => o.MapFrom(
                        s => s.Languages.Select(Mapper.Map<DtoLanguageSkill>)))
                .ForMember(
                    d => d.RelocationPossibility, 
                    o => o.MapFrom(
                        s => s.RelocationPossibility.Select(Mapper.Map<DtoRelocationPossibility>)))
                .ForMember(
                    d => d.WorkTicket, 
                    o => o.MapFrom(
                        s => s.WorkTicket
                            .Select(x => x.Area)
                            .Select(Mapper.Map<DtoArea>)))
                .ForMember(
                    d => d.Specializations, 
                    o => o.MapFrom(
                        s => s.Specializations
                            .Select(x => x.Specialization)
                            .Select(Mapper.Map<DtoSpecialization>)))
                .ForMember(
                    d => d.Schedules, 
                    o => o.MapFrom(
                        s => s.Schedules
                            .Select(x => x.Schedule)
                            .Select(Mapper.Map<DtoSchedule>)))
                .ForMember(
                    d => d.Skills, 
                    o => o.MapFrom(
                        s => s.Skills
                            .Select(x => x.Skill)
                            .Select(Mapper.Map<DtoSkill>)))

                .ForMember(
                    d => d.Applicant, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoApplicant>(s.Applicant)))
                .ForMember(
                    d => d.Area, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoArea>(s.Area)))
                .ForMember(
                    d => d.BusinessTripReadiness, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoBusinessTripReadiness>(s.BusinessTripReadiness)))
                .ForMember(
                    d => d.MetroStation, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoStation>(s.MetroStation)))
                .ForMember(
                    d => d.ResumeLocale,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoLanguage>(s.ResumeLocale)))
                .ForMember(
                    d => d.ResumeStatus, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoResumeStatus>(s.ResumeStatus)))
                .ForMember(
                    d => d.Salary, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSalary>(s.Salary)))
                .ForMember(
                    d => d.TravelTime, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoTravelTime>(s.TravelTime)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResume, Resume>()
                .ForMember(
                    d => d.Education,
                    o => o.Ignore())
                .ForMember(
                    d => d.Certificates,
                    o => o.Ignore())
                .ForMember(
                    d => d.Citizenship,
                    o => o.Ignore())
                .ForMember(
                    d => d.DrivingLicenseTypes,
                    o => o.Ignore())
                .ForMember(
                    d => d.Employments,
                    o => o.Ignore())
                .ForMember(
                    d => d.Experience,
                    o => o.Ignore())
                .ForMember(
                    d => d.Languages,
                    o => o.Ignore())
                .ForMember(
                    d => d.RelocationPossibility,
                    o => o.Ignore())
                .ForMember(
                    d => d.WorkTicket,
                    o => o.Ignore())
                .ForMember(
                    d => d.Specializations,
                    o => o.Ignore())
                .ForMember(
                    d => d.Schedules,
                    o => o.Ignore())
                .ForMember(
                    d => d.Skills,
                    o => o.Ignore())

                .ForMember(
                    d => d.Applicant,
                    o => o.Ignore())
                .ForMember(
                    d => d.Area,
                    o => o.Ignore())
                .ForMember(
                    d => d.BusinessTripReadiness,
                    o => o.Ignore())
                .ForMember(
                    d => d.MetroStation,
                    o => o.Ignore())
                .ForMember(
                    d => d.ResumeLocale,
                    o => o.Ignore())
                .ForMember(
                    d => d.ResumeStatus,
                    o => o.Ignore())
                .ForMember(
                    d => d.Salary,
                    o => o.Ignore())
                .ForMember(
                    d => d.TravelTime,
                    o => o.Ignore());
        }
    }
}
