using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Resumes.Db
{
    public partial class ResumesDbContext : DbContext
    {
        public ResumesDbContext(DbContextOptions<ResumesDbContext> options) :
            base(options)
        {
        }
    }
}
