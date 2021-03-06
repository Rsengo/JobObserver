﻿using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Languages
{
    /// <summary>
    ///     Навыки владения каким-либо языком
    /// </summary>
    public class LanguageSkill : RelationalEntity
    {
        /// <summary>
        ///     Язык
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        ///     Id Языка
        /// </summary>
        public virtual long? LanguageId { get; set; }

        /// <summary>
        ///     Уровень
        /// </summary>
        public virtual LanguageLevel Level { get; set; }

        /// <summary>
        ///     Id Уровня
        /// </summary>
        public virtual long? LevelId { get; set; }

        public virtual Vacancy Vacancy { get; set; }

        public virtual long VacancyId { get; set; }
    }
}