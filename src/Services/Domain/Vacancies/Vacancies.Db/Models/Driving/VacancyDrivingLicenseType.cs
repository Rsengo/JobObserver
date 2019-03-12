using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Driving
{
    public class VacancyDrivingLicenseType : RelationalEntity
    {
        public virtual Vacancy Vacancy { get; set; }

        public virtual long VacancyId { get; set; }

        public virtual DrivingLicenseType DrivingLicenseType { get; set; }

        public virtual long DrivingLicenseTypeId { get; set; }
    }
}
