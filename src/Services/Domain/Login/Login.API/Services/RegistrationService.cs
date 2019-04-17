﻿using System;
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

        private readonly IEventBus _eventBus;

        public event Action<IdentityResult> OnErrorsOccured;

        public RegistrationService(
            LoginDbContext context,
            UserManager<User> userManager,
            IEventBus eventBus)
        {
            _context = context;
            _userManager = userManager;
            _eventBus = eventBus;
        }

        public async Task RegisterAsync(RegistrationViewModel model, string role)
        {
            Contact contacts = null;
            EducationalInstitutionManagerAttributes eduInstAttributes = null;
            EmployerManagerAttributes empAttributes = null;

            if (model.Contacts != null)
            {
                contacts = Mapper.Map<Contact>(model.Contacts);
                _context.Contacts.Add(contacts);
            }

            if (model.EducationalInstitutionManagerAttributes == null)
            {
                eduInstAttributes = Mapper.Map<EducationalInstitutionManagerAttributes>(
                    model.EducationalInstitutionManagerAttributes);
                _context.EducationalInstitutionManagerAttributes.Add(eduInstAttributes);
            }

            if (model.EmployerManagerAttributes == null)
            {
                empAttributes = Mapper.Map<EmployerManagerAttributes>(
                    model.EmployerManagerAttributes);
                _context.EmployerManagerAttributes.Add(empAttributes);
            }

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
            if (result.Errors.Any())
            {
                OnErrorsOccured?.Invoke(result);

                if (model.Contacts != null)
                    await _context.Contacts.Where(x => x.Id == contacts.Id).DeleteFromQueryAsync();

                if (model.EducationalInstitutionManagerAttributes == null)
                    await _context.EducationalInstitutionManagerAttributes
                        .Where(x => x.Id == eduInstAttributes.Id)
                        .DeleteFromQueryAsync();

                if (model.EmployerManagerAttributes == null)
                    await _context.EmployerManagerAttributes
                        .Where(x => x.Id == empAttributes.Id)
                        .DeleteFromQueryAsync();
            }

            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (roleResult.Errors.Any())
            {
                OnErrorsOccured?.Invoke(roleResult);
            }

            var @event = new UsersChanged
            {
                Created = new[] { Mapper.Map<DtoUser>(user) }
            };

            _eventBus.Publish(@event);
        }
    }
}
