using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Login.API.Configuration;
using Login.Db;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;

namespace Login.API.Data
{
    public class LoginDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        private readonly LoginDbContext _context;

        private readonly ILogger<LoginDbContextSeed> _logger;

        public LoginDbContextSeed(
            LoginDbContext context,
            ILogger<LoginDbContextSeed> logger)
        {
            _passwordHasher = new PasswordHasher<User>();
            _logger = logger;
            _context = context;
        }

        public async Task<User> SeedAsync()
        {
            try
            {
                var roles = GetDefaultRoles();
                var user = await GetAdminUserAsync(_passwordHasher, _context);

                if (!_context.Roles.Any())
                    _context.Roles.AddRange(roles);

                if (!_context.Users.Any())
                    _context.Users.Add(user);

                await _context.SaveChangesAsync();

                if (!_context.UserRoles.Any())
                {
                    var adminRoles = GetAdminRoles(
                        await _context.Users.Where(x => x.UserName == "rsengo42@gmail.com").SingleOrDefaultAsync(), 
                        await _context.Roles.ToListAsync());
                    _context.UserRoles.AddRange(adminRoles);
                    await _context.SaveChangesAsync();
                }

                return user;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error when try to add admin user: {@ex}", ex);
                throw;
            }
        }

        private static IEnumerable<IdentityUserRole<string>> GetAdminRoles(User admin, IEnumerable<IdentityRole> roles)
        {
            var userRoles = roles
                .Where(x => x.Name == IdentityConfig.DefaultRoles.ADMIN)
                .Select(x => new IdentityUserRole<string>()
                {
                    RoleId = x.Id,
                    UserId = admin.Id
                });

            return userRoles;
        }

        private static async Task<User> GetAdminUserAsync(IPasswordHasher<User> hasher, LoginDbContext context)
        {
            var areaId = await context.Areas.Select(x => x.Id).FirstOrDefaultAsync();
            var genderId = await context.Genders.Select(x => x.Id).FirstOrDefaultAsync();

            var admin = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                BirthDate = new DateTime(1998, 1, 5),
                FirstName = "admin",
                Email = IdentityConfig.ADMIN_EMAIL,
                NormalizedEmail = IdentityConfig.ADMIN_EMAIL.ToUpper(),
                UserName = IdentityConfig.ADMIN_EMAIL,
                NormalizedUserName = IdentityConfig.ADMIN_EMAIL.ToUpper(),
                PhoneNumber = "+79996195928",
                SecurityStamp = Guid.NewGuid().ToString("D"),
                AreaId = areaId,
                GenderId = genderId
            };

            admin.PasswordHash = hasher.HashPassword(admin, IdentityConfig.ADMIN_PASSWORD);

            return admin;
        }

        private static IEnumerable<IdentityRole> GetDefaultRoles()
        {
            var roleNames = IdentityConfig.GetRoleNames();
            var roles = roleNames.Select(x => new IdentityRole
            {
                Id = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                Name = x,
                NormalizedName = x.ToUpperInvariant()
            });

            return roles;
        }
    }
}
