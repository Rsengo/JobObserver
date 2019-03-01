using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EducationalInstitutions.Db
{
    public partial class EducationalInstitutionsDbContext : DbContext
    {
        public EducationalInstitutionsDbContext(DbContextOptions<EducationalInstitutionsDbContext> options) :
            base(options)
        {
        }
    }
}
