using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vacancies.Db.Dto.Models;

namespace Vacancies.Export.ModelBuilders
{
    public class VacancyExportModelBuilder : IVacancyExportModelBuilder
    {
        public IDictionary<string, string> Build(DtoVacancy vacancy)
        {
            var dict = new Dictionary<string, string>();

            dict.Add("Должность", vacancy.Title);
            dict.Add("Город", vacancy.Address?.Area?.Name);
            dict.Add("Улица", vacancy.Address?.Street);
            dict.Add("Номер здания", vacancy.Address?.Building);
            dict.Add("Специализация", string.Join("; ", vacancy.Specializations?.Select(x => x.Name)));
            dict.Add("Дополнительная информация", vacancy.Description);
            dict.Add("Категории водительских прав", string.Join("; ", vacancy.DrivingLicenseTypes?.Select(x => x.Name)));
            dict.Add("Наличие транспорта", vacancy.RequiredVehicle ? "+" : "-");
            dict.Add("Владение языками", string.Join("; ", vacancy.Languages?.Select(x => $"{x.Language.Name}: {x.Level.Name}")));
            dict.Add("Тип занятости", vacancy.Employment?.Name);
            dict.Add("Заработная плата", vacancy.Salary == null ? string.Empty : $"{vacancy.Salary.From} - {vacancy.Salary.To}");
            dict.Add("Валюта", vacancy.Salary?.Currency?.Name);
            dict.Add("Расписание", vacancy.Schedule?.Name);
            dict.Add("Навыки", string.Join("; ", vacancy.KeySkills?.Select(x => x.Name)));
            dict.Add("Работодатель", vacancy.Employer?.Name);
            dict.Add("Сфера деятельности", vacancy.Industry?.Name);

            return dict;
        }
    }
}
