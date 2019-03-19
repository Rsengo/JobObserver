using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Db.Models
{
    using Microsoft.AspNetCore.Identity;

    public class RoleClaim: IdentityRoleClaim<long>
    {
    }
}
