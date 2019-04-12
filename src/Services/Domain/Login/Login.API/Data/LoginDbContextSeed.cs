﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Login.API.Configuration;
using Login.Db;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Polly;

namespace Login.API.Data
{
    public class LoginDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginDbContextSeed()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task SeedAsync(
            LoginDbContext context,
            ILogger<LoginDbContextSeed> logger)
        {
            try
            {
                var roles = GetDefaultRoles();
                var user = GetAdminUser(_passwordHasher);

                if (!context.Roles.Any())
                    context.Roles.AddRange(roles);

                if (!context.Users.Any())
                    context.Users.Add(user);

                await context.SaveChangesAsync();

                if (!context.UserRoles.Any())
                {
                    var adminRoles = GetAdminRoles(user, roles);
                    context.UserRoles.AddRange(adminRoles);
                    await context.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                logger.LogError("Error when try to add admin user: {@ex}", ex);
                throw;
            }
        }

        private static IEnumerable<IdentityUserRole<string>> GetAdminRoles(User admin, IEnumerable<IdentityRole> roles)
        {
            var userRoles = roles.Select(x => new IdentityUserRole<string>()
            {
                RoleId = x.Id,
                UserId = admin.Id
            });

            return userRoles;
        }

        private static User GetAdminUser(IPasswordHasher<User> hasher)
        {
            var admin = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                BirthDate = new DateTime(1998, 1, 5),
                FirstName = "admin",
                Email = "rsengo42@gmail.com",
                NormalizedEmail = "RSENGO42@GMAIL.COM",
                UserName = "rsengo42@gmail.com",
                NormalizedUserName = "RSENGO42@GMAIL.COM",
                PhoneNumber = "89505831265",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            admin.PasswordHash = hasher.HashPassword(admin, "admin");

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