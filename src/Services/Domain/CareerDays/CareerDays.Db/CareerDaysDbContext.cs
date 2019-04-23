using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace CareerDays.Db
{
    public partial class CareerDaysDbContext: DbContext
    {
        public CareerDaysDbContext(DbContextOptions<CareerDaysDbContext> options) : 
            base(options)
        {
            EntityFrameworkManager.ContextFactory = _ => new CareerDaysDbContext(options);
            this.EnsureAutoHistory();
        }
    }
}
