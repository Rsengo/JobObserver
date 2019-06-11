using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacancies.Db;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Salaries;
using Vacancies.Db.Models;

namespace Vacancies.API.Filters.Builders
{
    public class VacancySearchBuilder
    {
        private readonly VacanciesDbContext _context;

        public VacancySearchBuilder(VacanciesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Vacancy> BuildQuery(VacancySearchFilter filter)
        {
            IQueryable<Vacancy> query = _context.Vacancies;

            AddAreasCondition(query, filter.AreaIds);
            AddSpecializationsCondition(query, filter.SpecializationIds);
            AddEmploymentsCondition(query, filter.EmploymentIds);
            AddSchedulesCondition(query, filter.ScheduleIds);
            AddSkillsCondition(query, filter.KeySkillIds);
            AddDrivingLicenseCondition(query, filter.DrivingLicenseTypeIds);
            AddLanguagesCondition(query, filter.Languages);
            AddSalaryCondition(query, filter.Salary);
            AddUpdatedCondition(query, filter.PublishedAtMin, filter.PublishedAtMax);
            AddVehicleCondition(query, filter.RequiredVehicle);
            AddTitleCondition(query, filter.Title);
            AddHandicappedCondition(query, filter.AcceptHandicapped);
            AddEmployersCondition(query, filter.EmployerIds);
            AddIndustriesCondition(query, filter.IndustryIds);

            query = query
                .Skip(filter.Offset)
                .Take(filter.Count);

            return query;
        }

        private static IQueryable<Vacancy> AddAreasCondition(IQueryable<Vacancy> query, ICollection<long> areaIds)
        {
            if (areaIds?.Any() == true)
                query = query
                    .Where(x => x.Address != null)
                    .Where(x => areaIds.Contains(x.Address.AreaId));

            return query;
        }

        private static IQueryable<Vacancy> AddSpecializationsCondition(IQueryable<Vacancy> query, ICollection<long> specializationIds)
        {
            if (specializationIds?.Any() == true)
                query = query
                    .Where(x => x.Specializations
                        .Select(y => y.SpecializationId)
                        .Intersect(specializationIds)
                        .Any());

            return query;
        }

        private static IQueryable<Vacancy> AddEmploymentsCondition(IQueryable<Vacancy> query, ICollection<long> employmentIds)
        {
            if (employmentIds?.Any() == true)
                query = query
                    .Where(x => 
                        x.EmploymentId != null && 
                        employmentIds.Contains(x.EmploymentId.Value));

            return query;
        }

        private static IQueryable<Vacancy> AddSchedulesCondition(IQueryable<Vacancy> query, ICollection<long> scheduleIds)
        {
            if (scheduleIds?.Any() == true)
                query = query
                    .Where(x => 
                        x.Schedule != null && 
                        scheduleIds.Contains(x.ScheduleId.Value));

            return query;
        }

        private static IQueryable<Vacancy> AddEmployersCondition(
            IQueryable<Vacancy> query,
            ICollection<long> employerIds)
        {
            if (employerIds?.Any() == true)
                query = query
                    .Where(x => employerIds.Contains(x.EmployerId));

            return query;
        }

        private static IQueryable<Vacancy> AddIndustriesCondition(
            IQueryable<Vacancy> query,
            ICollection<long> industryIds)
        {
            if (industryIds?.Any() == true)
                query = query
                    .Where(x => industryIds.Contains(x.IndustryId));

            return query;
        }

        private static IQueryable<Vacancy> AddSkillsCondition(IQueryable<Vacancy> query, ICollection<long> skillIds)
        {
            if (skillIds?.Any() == true)
                query = query
                    .Where(x => x.KeySkills
                        .Select(y => y.SkillId)
                        .Intersect(skillIds)
                        .Any());

            return query;
        }

        private static IQueryable<Vacancy> AddDrivingLicenseCondition(IQueryable<Vacancy> query, ICollection<long> ids)
        {
            if (ids?.Any() == true)
                query = query
                    .Where(x => x.DrivingLicenseTypes
                        .Select(y => y.DrivingLicenseTypeId)
                        .Intersect(ids)
                        .Any());

            return query;
        }

        private static IQueryable<Vacancy> AddLanguagesCondition(
            IQueryable<Vacancy> query,
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

        private static IQueryable<Vacancy> AddSalaryCondition(
            IQueryable<Vacancy> query,
            ICollection<DtoSalary> objs)
        {
            if (objs?.Any() != true)
                return query;

            var predicate = PredicateBuilder.New<Vacancy>();

            foreach (var salary in objs)
            {
                predicate = predicate.Or(x =>
                    x.Salary.From == salary.From &&
                    x.Salary.To == salary.To &&
                    x.Salary.CurrencyId == salary.CurrencyId);
            }

            query = query.Where(predicate);

            return query;
        }

        private static IQueryable<Vacancy> AddUpdatedCondition(
            IQueryable<Vacancy> query,
            DateTime? min,
            DateTime? max)
        {
            if (max != null)
                query = query.Where(x => x.PublishedAt <= max);

            if (min != null)
                query = query.Where(x => x.PublishedAt >= min);

            return query;
        }

        private static IQueryable<Vacancy> AddVehicleCondition(
            IQueryable<Vacancy> query,
            bool? hasVehicle)
        {
            if (hasVehicle != null)
                query = query.Where(x => x.RequiredVehicle == hasVehicle);

            return query;
        }

        private static IQueryable<Vacancy> AddHandicappedCondition(
            IQueryable<Vacancy> query,
            bool? acceptHandicapped)
        {
            if (acceptHandicapped != null)
                query = query.Where(x => x.AcceptHandicapped == acceptHandicapped);

            return query;
        }

        private static IQueryable<Vacancy> AddTitleCondition(
            IQueryable<Vacancy> query,
            string title)
        {
            if (title != null)
                query = query.Where(x => EF.Functions.Contains(x.Title.ToLower(), title.ToLower()));

            return query;
        }
    }
}
