using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Vacancies.Db.Dto.Models;

namespace Vacancies.Export
{
    public interface IVacancyExporter
    {
        Task<Stream> ExportAsync(DtoVacancy resume);
    }
}
