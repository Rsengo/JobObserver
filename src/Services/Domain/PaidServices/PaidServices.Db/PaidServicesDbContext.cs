using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PaidServices.Db
{
    public partial class PaidServicesDbContext : DbContext
    {
        public PaidServicesDbContext(DbContextOptions<PaidServicesDbContext> options) :
            base(options)
        {
        }
    }
}
