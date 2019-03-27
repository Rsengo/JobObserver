using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace Employers.Db
{
    public partial class EmployersDbContext: DbContext
    {
        public EmployersDbContext(DbContextOptions<EmployersDbContext> options) :
            base(options)
        {
            EntityFrameworkManager.ContextFactory = _ => new EmployersDbContext(options);
            this.EnsureAutoHistory();
        }
    }
}
