using Microsoft.EntityFrameworkCore;

namespace CareerDays.Db
{
    public partial class CareerDaysDbContext: DbContext
    {
        public CareerDaysDbContext(DbContextOptions<CareerDaysDbContext> options) : 
            base(options)
        {
        }
    }
}
