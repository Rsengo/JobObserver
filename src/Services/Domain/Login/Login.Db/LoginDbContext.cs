using Login.Db.Models.Attributes;
using Login.Db.Models.Contacts;
using Login.Db.Models.Genders;
using Login.Db.Models.Geographic;
using Microsoft.EntityFrameworkCore;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Login.Db
{
    public partial class LoginDbContext : IdentityDbContext<User>
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) :
            base(options)
        {
            this.EnsureAutoHistory();
        }
    }
}
