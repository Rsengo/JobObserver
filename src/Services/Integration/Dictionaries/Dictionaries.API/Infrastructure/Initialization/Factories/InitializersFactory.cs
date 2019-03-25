using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Dictionaries.API.Infrastructure.Initialization.Attributes;
using Dictionaries.API.Infrastructure.Initialization.Initializers;
using Dictionaries.Db;
using Dictionaries.Db.Models.Travel;

namespace Dictionaries.API.Infrastructure.Initialization.Factories
{
    public class InitializersFactory : IInitializersFactory
    {
        private readonly string _folder;
        private readonly DictionariesDbContext _context;
        private readonly IEventBus _eventBus;

        public InitializersFactory(
            string folder,
            DictionariesDbContext context,
            IEventBus eventBus)
        {
            _folder = folder;
            _context = context;
            _eventBus = eventBus;
        }

        public IEnumerable<IInitializer> Create()
        {
            ////yield return new AreasInitializer(GetJsonPath(typeof(AreasInitializer)), _context, _eventBus);
            //yield return new BusinessTripReadinessInitializer(GetJsonPath(typeof(BusinessTripReadinessInitializer)), _context, _eventBus);
            //yield return new CurrenciesInitializer(GetJsonPath(typeof(CurrenciesInitializer)), _context, _eventBus);
            yield return new DrivingLicenseTypesInitializer(GetJsonPath(typeof(DrivingLicenseTypesInitializer)), _context, _eventBus);
            //yield return new EducationalLevelsInitializer(GetJsonPath(typeof(EducationalLevelsInitializer)), _context, _eventBus);
            //yield return new EmployerTypesInitializer(GetJsonPath(typeof(EmployerTypesInitializer)), _context, _eventBus);
            //yield return new EmploymentsInitializer(GetJsonPath(typeof(EmploymentsInitializer)), _context, _eventBus);
            //yield return new GendersInitializer(GetJsonPath(typeof(GendersInitializer)), _context, _eventBus);
            //yield return new IndustriesInitializer(GetJsonPath(typeof(IndustriesInitializer)), _context, _eventBus);
            //yield return new LanguageLevelsInitializer(GetJsonPath(typeof(LanguageLevelsInitializer)), _context, _eventBus); 
            //yield return new LanguagesInitializer(GetJsonPath(typeof(LanguagesInitializer)), _context, _eventBus);
            //yield return new RelocationTypesInitializer(GetJsonPath(typeof(RelocationTypesInitializer)), _context, _eventBus);
            //yield return new ResponsesInitializer(GetJsonPath(typeof(ResponsesInitializer)), _context, _eventBus);
            //yield return new ResumeStatusesInitializer(GetJsonPath(typeof(ResumeStatusesInitializer)), _context, _eventBus);
            //yield return new SchedulesInitializer(GetJsonPath(typeof(SchedulesInitializer)), _context, _eventBus);
            //yield return new SkillsInitializer(GetJsonPath(typeof(SkillsInitializer)), _context, _eventBus);
            ////yield return new SpecializationsInitializer(GetJsonPath(typeof(SpecializationsInitializer)), _context, _eventBus);
            //yield return new TravelTimesInitializer(GetJsonPath(typeof(TravelTimesInitializer)), _context, _eventBus);
            //yield return new VacancyStatusesInitializer(GetJsonPath(typeof(VacancyStatusesInitializer)), _context, _eventBus);
        }

        private string GetJsonPath(Type initializerType)
        {
            var jsonFileNameAttr = (JsonFileNameAttribute)initializerType.GetCustomAttributes()
                .SingleOrDefault(x => x is JsonFileNameAttribute);
            var jsonName = jsonFileNameAttr.Name;
            var jsonPath = Path.Combine(_folder, jsonName);

            return jsonPath;
        }

        private string GetJsonPath<T>()
            where T : IInitializer
        {
            return GetJsonPath(typeof(T));
        }
    }
}
