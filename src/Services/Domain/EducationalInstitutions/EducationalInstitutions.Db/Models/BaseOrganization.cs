using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;

namespace EducationalInstitutions.Db.Models
{
    /// <summary>
    ///     Абстрактная организация
    /// </summary>
    public abstract class BaseOrganization : RelationalDictionary
    {
        /// <summary>
        ///     Сокращение от названия
        /// </summary>
        public virtual string Acronym { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Id Брендированного описания
        /// </summary>
        public virtual long? BrandedDescriptionId { get; set; }

        public virtual BrandedTemplate BrandedDescription { get; set; }

        /// <summary>
        ///     Логотип
        /// </summary>
        public virtual string LogoUrl { get; set; }

        /// <summary>
        ///     Сайт компании
        /// </summary>
        public virtual string SiteUrl { get; set; }
    }
}