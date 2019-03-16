using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Specializations
{
    public class VacancySpecialization : RelationalEntity
    {
        public virtual Vacancy Vacancy { get; set; }

        public virtual long VacancyId { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual long SpecializationId { get; set; }
    }
}
