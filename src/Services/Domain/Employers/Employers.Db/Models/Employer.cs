using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;
using Employers.Db.Models.Geographic;
using Employers.Db.Models.Synonyms;

namespace Employers.Db.Models
{
    /// <summary>
    ///     Работодатель
    /// </summary>
    public class Employer : RelationalDictionary
    {
        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        public virtual Area Area { get; set; }

        /// <summary>
        ///     Сокращение от названия
        /// </summary>
        public virtual string Acronym { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Снинонимичные названия
        /// </summary>
        public virtual ICollection<EmployerSynonyms> Synonyms { get; set; }

        /// <summary>
        ///     Id Брендированного описания
        /// </summary>
        public virtual BrandedTemplate BrandedDescription { get; set; }

        /// <summary>
        ///     Логотип
        /// </summary>
        public virtual string LogoUrl { get; set; }

        /// <summary>
        ///     Сайт компании
        /// </summary>
        public virtual string SiteUrl { get; set; }

        /// <summary>
        ///     Тип работодателя (Кадровое агентство, рекрутер, прямой работодатель и т.д.)
        /// </summary>
        public virtual EmployerType Type { get; set; }

        /// <summary>
        ///     Id Типа работодателя
        /// </summary>
        public virtual long? TypeId { get; set; }

        /// <summary>
        ///     Отделения
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<Partners> Partners { get; set; }
    }
}