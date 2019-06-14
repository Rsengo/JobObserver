using System;
using System.Collections.Generic;
using System.Text;
using Resumes.Db.Dto.Models;

namespace Resumes.Export.ModelBuilders
{
    public class ResumeExportModelBuilderMock : IResumeExportModelBuilder
    {
        public IDictionary<string, string> Build(DtoResume resume)
        {
            var dict = new Dictionary<string, string>();

            dict.Add("Должность", "Должность");
            dict.Add("Город", "Город");
            dict.Add("Специализация", "Специализация");
            dict.Add("ФИО", "ФИО");
            dict.Add("Дата рождения", "Дата рождения");
            dict.Add("Пол", "Пол");
            dict.Add("Email", "Email");

            return dict;
        }
    }
}
