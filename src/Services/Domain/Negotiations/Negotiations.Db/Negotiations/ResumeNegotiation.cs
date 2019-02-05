namespace Negotiations.Db.Negotiations
{
    /// <summary>
    ///     Отклик на резюме
    /// </summary>
    public class ResumeNegotiation : BaseNegotiation
    {
        /// <summary>
        ///     Id Менеджера, оставившего отклик
        /// </summary>
        public virtual long ManagerId { get; set; }

        /// <summary>
        ///     Id Резюме
        /// </summary>
        public virtual long ResumeId { get; set; }
    }
}