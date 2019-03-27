using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace Dictionaries.Db
{
    public partial class DictionariesDbContext : DbContext
    {
        public DictionariesDbContext(DbContextOptions<DictionariesDbContext> options) :
            base(options)
        {
            EntityFrameworkManager.ContextFactory = _ => new DictionariesDbContext(options);
            this.EnsureAutoHistory();
        }
    }
}
