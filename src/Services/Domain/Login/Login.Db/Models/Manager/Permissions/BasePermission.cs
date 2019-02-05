using BuildingBlocks.Database.EntityFramework.Models;
using BuildingBlocks.Database.EntityFramework.Models;

namespace Login.Db.Models.Manager.Permissions
{
    /// <summary>
    ///     Возможность, привилегия (базовая)
    /// </summary>
    public abstract class BasePermission : RelationalDictionary
    {
    }
}