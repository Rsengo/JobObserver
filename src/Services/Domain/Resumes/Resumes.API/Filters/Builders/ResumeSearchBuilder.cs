using Microsoft.EntityFrameworkCore;
using Resumes.Db;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Salaries;
using Resumes.Db.Dto.Models.Travel.Relocation;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Filters.Builders
{
    public class ResumeSearchBuilder
    {
        private readonly ResumesDbContext _context;

        public ResumeSearchBuilder(ResumesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Resume> BuildQuery(ResumeSearchFilter filter)
        {
            var query = _context.Resumes;

            AddApplicantCondition(query, filter.ApplicantId);
            AddAreasCondition(query, filter.AreaIds);
            //AddMetroStationsCondition(filter.MetroStationIds);
            AddBusinessTripReadinessCondition(query, filter.BusinessTripReadinessIds);
            AddSpecializationsCondition(query, filter.SpecializationIds);
            AddEmploymentsCondition(query, filter.EmploymentIds);
            AddSchedulesCondition(query, filter.ScheduleIds);
            AddSkillsCondition(query, filter.SkillIds);
            AddCitizenshipCondition(query, filter.CitizenshipIds);
            AddWorkTicketCondition(query, filter.WorkTicketIds);
            AddTravelTimesCondition(query, filter.TravelTimeIds);
            AddLocaleCondition(query, filter.ResumeLocaleIds);
            AddDrivingLicenseCondition(query, filter.DrivingLicenseTypeIds);
            AddRelocationCondition(query, filter.RelocationPossibility);
            AddLanguagesCondition(query, filter.Languages);
            AddSalaryCondition(query, filter.Salary);
            AddUpdatedCondition(query, filter.UpdatedAtMin, filter.UpdatedAtMax);
            AddVehicleCondition(query, filter.HasVehicle);
            AddTitleCondition(query, filter.Title);

            return query;
        }

        private static IQueryable<Resume> AddApplicantCondition(IQueryable<Resume> query, Guid? applicantId)
        {
            if (applicantId != null)
                query = query.Where(x => x.ApplicantId == applicantId.Value);

            return query;
        }

        private static IQueryable<Resume> AddAreasCondition(IQueryable<Resume> query, ICollection<long> areaIds)
        {
            if (areaIds?.Any() == true)
                query = query
                    .Where(x => x.AreaId != null)
                    .Where(x => areaIds.Contains(x.AreaId.Value));

            return query;
        }

        private static IQueryable<Resume> AddMetroStationsCondition(IQueryable<Resume> query, ICollection<long> stationIds)
        {
            if (stationIds?.Any() == true)
                query = query
                    .Where(x => x.MetroStationId != null)
                    .Where(x => stationIds.Contains(x.MetroStationId.Value));

            return query;
        }

        private static IQueryable<Resume> AddBusinessTripReadinessCondition(IQueryable<Resume> query, ICollection<long> businessTripReadinessIds)
        {
            if (businessTripReadinessIds?.Any() == true)
                query = query
                    .Where(x => x.BusinessTripReadinessId != null)
                    .Where(x => businessTripReadinessIds.Contains(x.MetroStationId.Value));

            return query;
        }

        private static IQueryable<Resume> AddSpecializationsCondition(IQueryable<Resume> query, ICollection<long> specializationIds)
        {
            if (specializationIds?.Any() == true)
                query = query
                    .Where(x => x.Specializations
                        .Select(y => y.SpecializationId)
                        .Intersect(specializationIds)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddEmploymentsCondition(IQueryable<Resume> query, ICollection<long> employmentIds)
        {
            if (employmentIds?.Any() == true)
                query = query
                    .Where(x => x.Employments
                        .Select(y => y.EmploymentId)
                        .Intersect(employmentIds)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddSchedulesCondition(IQueryable<Resume> query, ICollection<long> scheduleIds)
        {
            if (scheduleIds?.Any() == true)
                query = query
                    .Where(x => x.Schedules
                        .Select(y => y.ScheduleId)
                        .Intersect(scheduleIds)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddSkillsCondition(IQueryable<Resume> query, ICollection<long> skillIds)
        {
            if (skillIds?.Any() == true)
                query = query
                    .Where(x => x.Skills
                        .Select(y => y.SkillId)
                        .Intersect(skillIds)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddCitizenshipCondition(IQueryable<Resume> query, ICollection<long> ids)
        {
            if (ids?.Any() == true)
                query = query
                    .Where(x => x.Citizenship
                        .Select(y => y.AreaId)
                        .Intersect(ids)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddWorkTicketCondition(IQueryable<Resume> query, ICollection<long> ids)
        {
            if (ids?.Any() == true)
                query = query
                    .Where(x => x.WorkTicket
                        .Select(y => y.AreaId)
                        .Intersect(ids)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddTravelTimesCondition(IQueryable<Resume> query, ICollection<long> ids)
        {
            if (ids?.Any() == true)
                query = query
                    .Where(x => x.TravelTimeId != null)
                    .Where(x => ids.Contains(x.TravelTimeId.Value));

            return query;
        }

        private static IQueryable<Resume> AddLocaleCondition(IQueryable<Resume> query, ICollection<long> ids)
        {
            if (ids?.Any() == true)
                query = query
                    .Where(x => x.ResumeLocaleId != null)
                    .Where(x => ids.Contains(x.ResumeLocaleId.Value));

            return query;
        }

        private static IQueryable<Resume> AddDrivingLicenseCondition(IQueryable<Resume> query, ICollection<long> ids)
        {
            if (ids?.Any() == true)
                query = query
                    .Where(x => x.DrivingLicenseTypes
                        .Select(y => y.DrivingLicenseTypeId)
                        .Intersect(ids)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddRelocationCondition(
            IQueryable<Resume> query, 
            ICollection<DtoRelocationPossibility> relocations)
        {
            var relocationsStr = relocations?.Select(x => $"{x.RelocationTypeId}_{x.AreaId}");
            if (relocations?.Any() == true)
                query = query
                    .Where(x => x.RelocationPossibility
                        .Select(y => $"{y.RelocationTypeId}_{y.AreaId}")
                        .Intersect(relocationsStr)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddLanguagesCondition(
            IQueryable<Resume> query,
            ICollection<DtoLanguageSkill> objs)
        {
            var str = objs?.Select(x => $"{x.LanguageId}_{x.LevelId}");
            if (objs?.Any() == true)
                query = query
                    .Where(x => x.Languages
                        .Select(y => $"{y.LanguageId}_{y.LevelId}")
                        .Intersect(str)
                        .Any());

            return query;
        }

        private static IQueryable<Resume> AddSalaryCondition(
            IQueryable<Resume> query,
            ICollection<DtoSalary> objs)
        {
            //TODO
            return query;
        }

        private static IQueryable<Resume> AddUpdatedCondition(
            IQueryable<Resume> query,
            DateTime? min,
            DateTime? max)
        {
            if (max != null)
                query = query.Where(x => x.UpdatedAt <= max);

            if (min != null)
                query = query.Where(x => x.UpdatedAt >= min);

            return query;
        }

        private static IQueryable<Resume> AddVehicleCondition(
            IQueryable<Resume> query,
            bool? hasVehicle)
        {
            if (hasVehicle != null)
                query = query.Where(x => x.HasVehicle == hasVehicle);

            return query;
        }

        private static IQueryable<Resume> AddTitleCondition(
            IQueryable<Resume> query,
            string title)
        {
            if (title != null)
                query = query.Where(x => EF.Functions.Contains(x.Title.ToLower(), title.ToLower()));

            return query;
        }
    }
}
