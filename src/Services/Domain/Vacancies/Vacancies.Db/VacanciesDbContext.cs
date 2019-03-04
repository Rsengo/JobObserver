using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Vacancies.Db
{
    public partial class VacanciesDbContext : DbContext
    {
        public VacanciesDbContext(DbContextOptions<VacanciesDbContext> options) :
            base(options)
        {
        }
    }
}
