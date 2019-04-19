using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Login.API.Configuration;
using Login.Db;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;

        private readonly LoginDbContext _context;

        public ProfileService(UserManager<User> userManager, LoginDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject)?.Value;

            var user = await _userManager.FindByIdAsync(subjectId);
            if (user == null)
                throw new ArgumentException("Invalid subject identifier");

            var claims = await GetClaimsFromUser(user);
            context.IssuedClaims = claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject)?.Value;
            var user = await _userManager.FindByIdAsync(subjectId);

            context.IsActive = false;

            if (user == null)
                return;

            if (_userManager.SupportsUserSecurityStamp)
            {
                var securityStamp = subject.Claims
                    .Where(c => c.Type == "security_stamp")
                    .Select(c => c.Value)
                    .SingleOrDefault();

                if (securityStamp != null)
                {
                    var dbSecurityStamp = await _userManager.GetSecurityStampAsync(user);
                    if (dbSecurityStamp != securityStamp)
                        return;
                }
            }

            context.IsActive =
                !user.LockoutEnabled ||
                !user.LockoutEnd.HasValue ||
                user.LockoutEnd <= DateTime.Now;
        }

        private async Task<IEnumerable<Claim>> GetClaimsFromUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id),
                new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var roleClaims = await GetRoleClaims(user);
            claims.AddRange(roleClaims);

            if (_userManager.SupportsUserEmail)
            {
                claims.AddRange(new[]
                {
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                });
            }

            if (_userManager.SupportsUserPhoneNumber && !string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claims.AddRange(new[]
                {
                    new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                    new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
                });
            }

            return claims;
        }

        private async Task<IEnumerable<Claim>> GetRoleClaims(User user)
        {
            var claims = new List<Claim>();

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            if (await _userManager.IsInRoleAsync(user, IdentityConfig.DefaultRoles.EMPLOYER_MANAGER))
            {
                var attrs = _context.EmployerManagerAttributes.SingleOrDefault(x =>
                    x.Id == user.EmployerManagerAttributesId);
                claims.Add(new Claim(IdentityConfig.JobObserverJwtClaimTypes.OrganizationId, attrs?.OrganizationId.ToString()));
            }

            if (await _userManager.IsInRoleAsync(user, IdentityConfig.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER))
            {
                var attrs = _context.EmployerManagerAttributes.SingleOrDefault(x =>
                    x.Id == user.EmployerManagerAttributesId);
                claims.Add(new Claim(IdentityConfig.JobObserverJwtClaimTypes.OrganizationId, attrs?.OrganizationId.ToString()));
            }

            return claims;
        }
    }
}
