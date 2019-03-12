using System;
using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Dto.Models.Educations
{
    /// <summary>
    ///     Образование
    /// </summary>
    public class DtoEducation : DtoEntity
    {
        /// <summary>
        ///     Уровень образования
        /// </summary>
        [JsonProperty("educational_level")]
        public virtual DtoEducationalLevel EducationalLevel { get; set; }

        /// <summary>
        ///     Id Уровня образования
        /// </summary>
        [JsonProperty("educational_level_id")]
        public virtual long EducationalLevelId { get; set; }

        /// <summary>
        ///     Направление подготовки
        /// </summary>
        [JsonProperty("school")]
        public virtual string School { get; set; }

        /// <summary>
        ///     Id Факультета
        /// </summary>
        [JsonProperty("faculty_id")]
        public virtual long FacultyId { get; set; }

        /// <summary>
        ///     Дата поступления
        /// </summary>
        [JsonProperty("admission_date")]
        public virtual DateTime AdmissionDate { get; set; }

        /// <summary>
        ///     Дата окончания
        /// </summary>
        [JsonProperty("graduation_date")]
        public virtual DateTime GraduationDate { get; set; }

        /// <summary>
        ///     Список специализаций
        /// </summary>
        [JsonProperty("specializations")]
        public virtual ICollection<DtoSpecialization> Specializations { get; set; }

        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }
    }
}