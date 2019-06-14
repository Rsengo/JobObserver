using System;
using System.Collections.Generic;
using System.Text;
using Vacancies.Db.Dto.Models;

namespace Vacancies.Export.ModelBuilders
{
    public class VacancyExportModelBuilderMock : IVacancyExportModelBuilder
    {
        public IDictionary<string, string> Build(DtoVacancy vacancy)
        {
            var dict = new Dictionary<string, string>();

            dict.Add("Должность", "Ведущий разработчик");
            dict.Add("Город", "Томск");
            dict.Add("Улица", "Советская");
            dict.Add("Номер здания", "84/3");
            dict.Add("Специализация", "Программирование; Интернет-технологии");
            dict.Add("Дополнительная информация", "");
            dict.Add("Категории водительских прав", "");
            dict.Add("Наличие транспорта", "Нет");
            dict.Add("Владение языками", "Английский: intermediate");
            dict.Add("Тип занятости", "Полная занятость");
            dict.Add("Заработная плата", "100000-150000");
            dict.Add("Валюта", "руб");
            dict.Add("Расписание", "Полный день");
            dict.Add("Навыки", "Asp; .Net; Js; React");
            dict.Add("Работодатель", "Отдел разработки ТПУ");
            dict.Add("Сфера деятельности", "IT");

            return dict;
        }
    }
}
