using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace Vacancies.Dto.Models.Tests
{
    public class DtoVacancyTest: DtoDictionary
    {
        [JsonProperty("vacancy_id")]
        public virtual long VacancyId { get; set; }

        [JsonProperty("test_id")]
        public virtual long TestId { get; set; }
    }
}
