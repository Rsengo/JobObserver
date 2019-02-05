namespace Negotiations.Db.Negotiations
{
    /// <summary>
    ///     Оклик на вакансию
    /// </summary>
    public class VacancyNegotiation : BaseNegotiation
    {
        /// <summary>
        ///     Id Соискателя, оставившего отзыв
        /// </summary>
        public virtual long ApplicantId { get; set; }

        /// <summary>
        ///     Id Вакансии
        /// </summary>
        public virtual long VacancyId { get; set; }
    }
}