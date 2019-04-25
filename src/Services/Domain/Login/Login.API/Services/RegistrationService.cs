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
    using Login.Db.Dto.Models;

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
            Contact contacts = null;
            EducationalInstitutionManagerAttributes eduInstAttributes = null;
            EmployerManagerAttributes empAttributes = null;

            await _context.SaveChangesAsync();

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                BirthDate = model.BirthDate,
                ContactsId = contacts?.Id,
                GenderId = model.GenderId,
                AreaId = model.AreaId,
                Email = model.Email,
                UserName = model.Email,
                EducationalInstitutionManagerAttributesId = eduInstAttributes?.Id,
                EmployerManagerAttributesId = empAttributes?.Id
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (roleResult.Errors.Any())
            {
                OnErrorsOccured?.Invoke(roleResult);
            }
            
            if (model.Contacts != null)
            {
                contacts = Mapper.Map<Contact>(model.Contacts);
                _context.Contacts.Add(contacts);

                await AddContacts(model, user.Id);
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

        private async Task<long> AddContacts(RegistrationViewModel model, string userId)
        {
            var contacts = Mapper.Map<Contact>(model);
            contacts.UserId = userId;

            _context.Contacts.Add(contacts);
            await _context.SaveChangesAsync();

            var phones = contacts.Phones;
            var sites = contacts.Sites;

            foreach (var phone in phones)
            {
                phone.ContactId = contacts.Id;
            }

            foreach (var site in sites)
            {
                site.ContactId = contacts.Id;
            }

            _context.Phones.AddRange(phones);
            _context.Sites.AddRange(sites);

            await _context.SaveChangesAsync();

            return contacts.Id;
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
