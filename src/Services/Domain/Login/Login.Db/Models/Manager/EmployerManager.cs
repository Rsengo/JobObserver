using System.Collections.Generic;

namespace Login.Db.Models.Manager
{
    /// <summary>
    ///     Менеджер работодателя
    /// </summary>
    public class EmployerManager : BaseManager
    {
        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }
    }
}