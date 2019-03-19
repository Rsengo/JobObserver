using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Db.Models
{
    using Microsoft.AspNetCore.Identity;

    public class UserRole : IdentityUserRole<long>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
