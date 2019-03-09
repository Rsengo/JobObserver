using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Employers.Db
{
    public partial class EmployersDbContext: DbContext
    {
        public EmployersDbContext(DbContextOptions<EmployersDbContext> options) :
            base(options)
        {
            this.EnsureAutoHistory();
        }
    }
}
