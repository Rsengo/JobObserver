using System;
using System.Collections.Generic;
using System.Text;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Login.Db
{
    public class LoginContext : IdentityDbContext<User>
    {
    }
}
