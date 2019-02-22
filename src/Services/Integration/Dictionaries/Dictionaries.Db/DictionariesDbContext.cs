using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Dictionaries.Db
{
    public partial class DictionariesDbContext : DbContext
    {
        public DictionariesDbContext(DbContextOptions<DictionariesDbContext> options) :
            base(options)
        {
        }
    }
}
