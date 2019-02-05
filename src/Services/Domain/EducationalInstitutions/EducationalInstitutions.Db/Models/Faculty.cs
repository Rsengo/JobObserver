namespace EducationalInstitutions.Db.Models
{
    /// <summary>
    ///     Факультет
    /// </summary>
    public class Faculty : BaseOrganization
    {
        /// <summary>
        ///     Образовательное учреждение
        /// </summary>
        public virtual EducationalInstitution EducationalInstitution { get; set; }

        /// <summary>
        ///     Id Образовательного учреждения
        /// </summary>
        public virtual long EducationalInstitutionId { get; set; }
    }
}