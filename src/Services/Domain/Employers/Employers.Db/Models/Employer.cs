using System.Collections.Generic;

namespace Employers.Db.Models
{
    /// <summary>
    ///     Работодатель
    /// </summary>
    public class Employer : BaseOrganization
    {
        /// <summary>
        ///     Подтвержден администратором
        /// </summary>
        public virtual bool Trusted { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

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
    }
}