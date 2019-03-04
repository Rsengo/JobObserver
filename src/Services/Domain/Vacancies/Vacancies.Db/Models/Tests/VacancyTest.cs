using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Tests
{
    public class VacancyTest: RelationalDictionary
    {
        public virtual Vacancy Vacancy { get; set; }

        public virtual long VacancyId { get; set; }

        public virtual long TestId { get; set; }
    }
}
