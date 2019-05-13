using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Security.Access;
using Resumes.API.Controllers;
using Resumes.Db;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Models.Driving;
using Resumes.Db.Models.Educations;
using Resumes.Db.Models.Employments;
using Resumes.Db.Models.Experiences;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Models.Languages;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Models.ResumeAreas;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Models.Schedules;
using Resumes.Db.Models.Skills;
using Resumes.Db.Models.Specializations;
using Resumes.Db.Models.Travel.Relocation;

namespace Resumes.API.Security
{
    using System.Collections.Immutable;
    using BuildingBlocks.EntityFramework.Models;
    using Resumes.Db.Models;

    public class ApplicantAccessor : IAccessor
    {
        private readonly Guid _applicantId;

        private readonly ResumesDbContext _context;

        public ApplicantAccessor(
            Guid applicantId,
            ResumesDbContext context)
        {
            _context = context;
            _applicantId = applicantId;
        }

        public bool HasPermission<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {

            if (entity is Resume castedResume)
            {
                return castedResume.ApplicantId == _applicantId;
            }

            if (entity is Certificate castedCertificate)
            {
                var resumeId = castedCertificate.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is Citizenship castedCitizenship)
            {
                var resumeId = castedCitizenship.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is ResumeDrivingLicenseType castedResumeDrivingLicenseType)
            {
                var resumeId = castedResumeDrivingLicenseType.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is Education castedEducation)
            {
                var resumeId = castedEducation.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is EducationSpecialization castedEducationSpecialization)
            {
                var educationId = castedEducationSpecialization.EducationId;
                var education = _context.Educations
                    .Select(x => new Education {Id = x.Id, ResumeId = x.ResumeId})
                    .Single(x => x.Id == educationId);
                return GetOwnerPermission(education.ResumeId);
            }

            if (entity is ResumeEmployment castedResumeEmployment)
            {
                var resumeId = castedResumeEmployment.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is Experience castedExperience)
            {
                var resumeId = castedExperience.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is LanguageSkill castedLanguageSkill)
            {
                var resumeId = castedLanguageSkill.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is ResumeNegotiation castedResumeNegotiation)
            {
                var resumeId = castedResumeNegotiation.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is RelocationPossibility castedRelocationPossibility)
            {
                var resumeId = castedRelocationPossibility.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is Salary castedSalary)
            {
                var resumeId = castedSalary.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is ResumeSchedule castedSchedule)
            {
                var resumeId = castedSchedule.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is ResumeSkill casredResumeSkill)
            {
                var resumeId = casredResumeSkill.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is ResumeSpecialization castedResumeSpecialization)
            {
                var resumeId = castedResumeSpecialization.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            if (entity is WorkTicket castedWorkTicket)
            {
                var resumeId = castedWorkTicket.ResumeId;
                return GetOwnerPermission(resumeId);
            }

            return operation == AccessOperation.READ;
        }

        private bool GetOwnerPermission(long resumeId)
        {
            var resume = _context.Resumes
                .Select(x => new Resume { Id = x.Id, ApplicantId = x.ApplicantId })
                .SingleOrDefault(x => x.Id == resumeId);
            return resume?.ApplicantId == _applicantId;
        } 
    }
}
