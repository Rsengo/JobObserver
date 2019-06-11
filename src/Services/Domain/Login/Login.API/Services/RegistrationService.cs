using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Login.API.Configuration;
using Login.API.ViewModels;
using Login.Db;
using Login.Db.Models;
using Login.Db.Models.Attributes;
using Login.Db.Models.Contacts;
using Microsoft.AspNetCore.Identity;
using BuildingBlocks.EventBus.Abstractions;
using Login.Db.Synchronization.Events.Users;

namespace Login.API.Services
{
    public class RegistrationService: IRegistrationService
    {
        private readonly LoginDbContext _context;

        private readonly UserManager<User> _userManager;

        public event Action<IdentityResult> OnErrorsOccured;

        public RegistrationService(
            LoginDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<User> RegisterAsync(RegistrationViewModel model, string role)
        {
            await _context.SaveChangesAsync();

            var user = new User
            {
                Id = Guid.NewGuid().ToString("D"),
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                GenderId = model.GenderId,
                AreaId = model.AreaId,
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.Email.ToUpper()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (roleResult.Errors.Any())
            {
                OnErrorsOccured?.Invoke(roleResult);
            }

            if (role == IdentityConfig.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER)
            {
                await AddEducationalInstitutionManagerProperties(model, user.Id);
            }

            if (role == IdentityConfig.DefaultRoles.EMPLOYER_MANAGER)
            {
                await AddEmployerManagerProperties(model, user.Id);
            }

            return user;
        }

        private async Task AddEducationalInstitutionManagerProperties(RegistrationViewModel model, string userId)
        {
            var attrs = new EducationalInstitutionManagerAttributes
            {
                OrganizationId = model.OrganizationId.Value,
                Position = model.Position,
                UserId = userId
            };

            _context.EducationalInstitutionManagerAttributes.Add(attrs);
            await _context.SaveChangesAsync();
        }

        private async Task AddEmployerManagerProperties(RegistrationViewModel model, string userId)
        {
            var attrs = new EmployerManagerAttributes
            {
                OrganizationId = model.OrganizationId.Value,
                Position = model.Position,
                UserId = userId
            };

            _context.EmployerManagerAttributes.Add(attrs);
            await _context.SaveChangesAsync();
        }
    }
}
