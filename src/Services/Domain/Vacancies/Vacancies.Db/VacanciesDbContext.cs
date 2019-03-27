using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace Vacancies.Db
{
    public partial class VacanciesDbContext : DbContext
    {
        public VacanciesDbContext(DbContextOptions<VacanciesDbContext> options) :
            base(options)
        {
            EntityFrameworkManager.ContextFactory = _ => new VacanciesDbContext(options);
            this.EnsureAutoHistory();
        }
    }
}
