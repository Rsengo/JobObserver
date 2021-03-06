﻿using BuildingBlocks.EntityFramework.Models;

namespace EducationalInstitutions.Db.Models
{
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class BrandedTemplate : RelationalEntity
    {
        /// <summary>
        ///     Название.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     HTML шаблон
        /// </summary>
        public virtual string Text { get; set; }
    }
}