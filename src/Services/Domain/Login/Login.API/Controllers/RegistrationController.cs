﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Login.API.Configuration;
using Login.API.HttpFilters;
using Login.API.Services;
using Login.API.ViewModels;
using Login.Db.Dto.Models;
using Login.Db.Synchronization.Events.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Login.API.Controllers
{
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        private readonly IEventBus _eventBus;

        private readonly IOptions<RedirectSettings> _redirectSettings;

        private readonly ICryptoService _cryptoService;

        public RegistrationController(
            IRegistrationService registrationService,
            IEventBus eventBus,
            IOptions<RedirectSettings> redirectSettings,
            ICryptoService cryptoService)
        {
            _registrationService = registrationService;
            _eventBus = eventBus;
            _redirectSettings = redirectSettings;
            _cryptoService = cryptoService;

            _registrationService.OnErrorsOccured += AddErrors;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var url = _cryptoService.Encrypt(returnUrl);
            return Redirect(_redirectSettings.Value.FullRegistrationPageUrl + url);
        }

        [HttpPost("applicant")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterApplicant(RegistrationViewModel model)
        {
            var user = await _registrationService.RegisterAsync(model, IdentityConfig.DefaultRoles.APPLICANT);

            if (ModelState.ErrorCount <= 0)
            {
                var @event = new ApplicantsChanged
                {
                    Created = new[] { Mapper.Map<DtoUser>(user) }
                };
                _eventBus.Publish(@event);

                var url = _cryptoService.Decrypt(model.ReturnUrl);
                
                return Ok(url);
            }

            var errorsJson = new JsonErrorResponse
            {
                Messages = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray()
            };
            var errors = new BadRequestObjectResult(errorsJson);

            return BadRequest(errors);
        }

        [HttpPost("employermanager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEmployerManager(RegistrationViewModel model)
        {
            await _registrationService.RegisterAsync(model, IdentityConfig.DefaultRoles.EMPLOYER_MANAGER);

            if (ModelState.ErrorCount <= 0)
            {
                var url = _cryptoService.Decrypt(model.ReturnUrl);

                return Ok(url);
            }

            var errorsJson = new JsonErrorResponse
            {
                Messages = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray()
            };
            var errors = new BadRequestObjectResult(errorsJson);

            return BadRequest(errors);
        }

        [HttpPost("educationalinstitutionmanager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEducationalInstitutionManager(RegistrationViewModel model)
        {
            await _registrationService.RegisterAsync(model, IdentityConfig.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER);

            if (ModelState.ErrorCount <= 0)
            {
                var url = _cryptoService.Decrypt(model.ReturnUrl);

                return Ok(url);
            }

            var errorsJson = new JsonErrorResponse
            {
                Messages = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray()
            };
            var errors = new BadRequestObjectResult(errorsJson);

            return BadRequest(errors);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
