using System.Linq;
using Dictionaries.Db;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Dictionaries.API.Infrastructure.Initialization;
using Dictionaries.Db.Dto.Models;
using Dictionaries.Db.Dto.Models.Contacts;
using Dictionaries.Db.Dto.Models.Driving;
using Dictionaries.Db.Dto.Models.Educations;
using Dictionaries.Db.Dto.Models.Employer;
using Dictionaries.Db.Dto.Models.Employments;
using Dictionaries.Db.Dto.Models.Languages;
using Dictionaries.Db.Dto.Models.Negotiations;
using Dictionaries.Db.Dto.Models.Salaries;
using Dictionaries.Db.Dto.Models.Schedules;
using Dictionaries.Db.Dto.Models.Statuses;
using Dictionaries.Db.Dto.Models.Travel;
using Dictionaries.Db.Dto.Models.Travel.Relocation;
using Dictionaries.Db.Dto.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class DictionariesController : ControllerBase
    {
        private readonly DictionariesInitializationService _initializationService;

        private readonly DictionariesDbContext _context;

        public DictionariesController(
            DictionariesInitializationService initializationService, 
            DictionariesDbContext context)
        {
            _initializationService = initializationService;
            _context = context;
        }

        [HttpGet("_restore")]
        public async Task<IActionResult> InitializeAll()
        {
            await _initializationService.InitializeAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var businessTripReadiness = await _context.BusinessTripReadiness.ToListAsync();
            var currency = await _context.Currencies.ToListAsync();
            var drivingLicenseTypes = await _context.DrivingLicenseTypes.ToListAsync();
            var educationalLevels = await _context.EducationalLevels.ToListAsync();
            var employerTypes = await _context.EmployerTypes.ToListAsync();
            var employment = await _context.Employments.ToListAsync();
            var genders = await _context.Genders.ToListAsync();
            var languageLevels = await _context.LanguageLevels.ToListAsync();
            var languages = await _context.Languages.ToListAsync();
            var relocationTypes = await _context.RelocationTypes.ToListAsync();
            var responses = await _context.Responses.ToListAsync();
            var resumeStatuses = await _context.ResumeStatuses.ToListAsync();
            var schedules = await _context.Schedules.ToListAsync();
            var siteTypes = await _context.SiteTypes.ToListAsync();
            var travelTimes = await _context.TravelTimes.ToListAsync();
            var vacancyStatuses = await _context.VacancyStatuses.ToListAsync();

            var businessTripReadinessDto = businessTripReadiness.Select(Mapper.Map<DtoBusinessTripReadiness>);
            var currencyDto = currency.Select(Mapper.Map<DtoCurrency>);
            var drivingLicenseTypesDto = drivingLicenseTypes.Select(Mapper.Map<DtoDrivingLicenseType>);
            var educationalLevelsDto = educationalLevels.Select(Mapper.Map<DtoEducationalLevel>);
            var employerTypesDto = employerTypes.Select(Mapper.Map<DtoEmployerType>);
            var employmentDto = employment.Select(Mapper.Map<DtoEmployment>);
            var gendersDto = genders.Select(Mapper.Map<DtoGender>);
            var languageLevelsDto = languageLevels.Select(Mapper.Map<DtoLanguageLevel>);
            var languagesDto = languages.Select(Mapper.Map<DtoLanguage>);
            var relocationTypesDto = relocationTypes.Select(Mapper.Map<DtoRelocationType>);
            var responsesDto = responses.Select(Mapper.Map<DtoResponse>);
            var resumeStatusesDto = resumeStatuses.Select(Mapper.Map<DtoResumeStatus>);
            var schedulesDto = schedules.Select(Mapper.Map<DtoSchedule>);
            var siteTypesDto = siteTypes.Select(Mapper.Map<DtoSiteType>);
            var travelTimesDto = travelTimes.Select(Mapper.Map<DtoTravelTime>);
            var vacancyStatusesDto = vacancyStatuses.Select(Mapper.Map<DtoVacancyStatus>);

            var result = new DtoDictionaries
            {
                BusinessTripReadiness = businessTripReadinessDto,
                Currency = currencyDto,
                DrivingLicenseTypes = drivingLicenseTypesDto,
                EducationalLevels = educationalLevelsDto,
                EmployerTypes = employerTypesDto,
                Employment = employmentDto,
                Genders = gendersDto,
                LanguageLevels = languageLevelsDto,
                Languages = languagesDto,
                RelocationTypes = relocationTypesDto,
                Responses = responsesDto,
                ResumeStatuses = resumeStatusesDto,
                Schedules = schedulesDto,
                SiteTypes = siteTypesDto,
                TravelTimes = travelTimesDto,
                VacancyStatuses = vacancyStatusesDto,
            };

            return Ok(result);
        }
    }
}