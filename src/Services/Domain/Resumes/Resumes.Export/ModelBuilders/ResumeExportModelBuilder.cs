using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resumes.Db.Dto.Models;
using Resumes.Db.Dto.Models.Applicants;

namespace Resumes.Export.ModelBuilders
{
    public class ResumeExportModelBuilder : IResumeExportModelBuilder
    {
        public IDictionary<string, string> Build(DtoResume resume)
        {
            var dict = new Dictionary<string, string>();

            if (resume.Applicant != null)
            {
                var applicantDict = CreateApplicantDictionary(resume.Applicant);
                foreach (var attr in applicantDict)
                {
                    dict.TryAdd(attr.Key, attr.Value);
                }
            }

            //TODO образование и опыт
            dict.Add("Должность", resume.Title);
            dict.Add("Город", resume.Area?.Name);
            dict.Add("Специализация", string.Join("; ", resume.Specializations?.Select(x => x.Name)));
            dict.Add("Дополнительная информация", resume.AdditionalInfo);
            dict.Add("Готовность к командировкам", resume.BusinessTripReadiness?.Name);
            dict.Add("Гражданство", string.Join("; ", resume.Citizenship?.Select(x => x.Name)));
            dict.Add("Категории водительских прав", string.Join("; ", resume.DrivingLicenseTypes?.Select(x => x.Name)));
            dict.Add("Наличие транспорта", resume.HasVehicle ? "+" : "-");
            dict.Add("Владение языками", string.Join("; ", resume.Languages?.Select(x => $"{x.Language.Name}: {x.Level.Name}")));
            dict.Add("Тип занятости", string.Join("; ", resume.Employments?.Select(x => x.Name)));
            dict.Add("Возможность переезда", string.Join("; ", resume.RelocationPossibility?.Select(x => $"{x.Area.Name}: {x.RelocationType.Name}")));
            dict.Add("Заработная плата", resume.Salary == null ? string.Empty : $"{resume.Salary.From} - {resume.Salary.To}");
            dict.Add("Валюта", resume.Salary?.Currency?.Name);
            dict.Add("Расписание", string.Join("; ", resume.Schedules?.Select(x => x.Name)));
            dict.Add("Навыки", string.Join("; ", resume.Skills?.Select(x => x.Name)));
            dict.Add("Разрешение на работу", string.Join("; ", resume.WorkTicket?.Select(x => x.Name)));
            dict.Add("Время проезда до работы", resume.TravelTime?.Name);

            return dict;
        }

        private static IDictionary<string, string> CreateApplicantDictionary(DtoApplicant applicant)
        {
            var dict = new Dictionary<string, string>();

            dict.Add("ФИО", applicant.FullName);
            dict.Add("Дата рождения", applicant.BirthDate.ToString("dd MM yyyy"));
            dict.Add("Пол", applicant.Gender?.Name);
            dict.Add("Email", applicant.Email);

            return dict;
        }
    }
}
