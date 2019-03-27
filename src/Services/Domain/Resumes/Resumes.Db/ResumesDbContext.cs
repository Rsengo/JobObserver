using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace Resumes.Db
{
    public partial class ResumesDbContext : DbContext
    {
        public ResumesDbContext(DbContextOptions<ResumesDbContext> options) :
            base(options)
        {
            EntityFrameworkManager.ContextFactory = _ => new ResumesDbContext(options);
            this.EnsureAutoHistory();
        }
    }
}
