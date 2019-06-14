using System;
using System.Collections.Generic;
using System.Text;
using Vacancies.Db.Dto.Models;

namespace Vacancies.Export.ModelBuilders
{
    public interface IVacancyExportModelBuilder
    {
        IDictionary<string, string> Build(DtoVacancy vacancy);
    }
}
