﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.API.Configuration;
using Login.API.Services;
using Login.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;

            _registrationService.OnErrorsOccured += AddErrors;
        }

        [HttpPost("applicant")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterApplicant(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            await _registrationService.RegisterAsync(model, IdentityConfig.DefaultRoles.APPLICANT);

            if (ModelState.ErrorCount <= 0)
                return Ok();

            var errors = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            return BadRequest(errors);
        }

        [HttpPost("employermanager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEmployerManager(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            await _registrationService.RegisterAsync(model, IdentityConfig.DefaultRoles.EMPLOYER_MANAGER);

            if (ModelState.ErrorCount <= 0)
                return Ok();

            var errors = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            return BadRequest(errors);
        }

        [HttpPost("educationalinstitutionmanager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEducationalInstitutionManager(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            await _registrationService.RegisterAsync(model, IdentityConfig.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER);

            if (ModelState.ErrorCount <= 0)
                return Ok();

            var errors = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

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
