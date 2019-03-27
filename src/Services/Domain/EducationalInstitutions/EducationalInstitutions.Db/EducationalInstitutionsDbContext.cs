using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace EducationalInstitutions.Db
{
    public partial class EducationalInstitutionsDbContext : DbContext
    {
        public EducationalInstitutionsDbContext(DbContextOptions<EducationalInstitutionsDbContext> options) :
            base(options)
        {
            EntityFrameworkManager.ContextFactory = _ => new EducationalInstitutionsDbContext(options);
            this.EnsureAutoHistory();
        }
    }
}
