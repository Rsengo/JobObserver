using BuildingBlocks.Database.EntityFramework.Models;

namespace Resumes.Db.Models.Recommendations
{
    /// <summary>
    ///     Рекомендация
    /// </summary>
    public abstract class BaseRecommendation : RelationalEntity
    {
        /// <summary>
        ///     Комментарий
        /// </summary>
        public virtual string Comment { get; set; }

        /// <summary>
        ///     Резюме
        /// </summary>
        public virtual Resume Resume { get; set; }

        /// <summary>
        ///     Id Резюме
        /// </summary>
        public virtual long ResumeId { get; set; }

        /// <summary>
        ///     Id Менеджера, давшего рекомендацию
        /// </summary>
        public virtual long ManagerId { get; set; }
    }
}