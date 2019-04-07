using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Login.API.Configuration;
using Login.API.Infrastructure.Services;
using Login.API.Infrastructure.ViewModels;
using Login.Db;
using Login.Db.Models;
using Login.Db.Models.Attributes;
using Login.Db.Models.Contacts;
using Login.Dto.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Login.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly IIdentityServerInteractionService _interaction;

        private readonly ILogger<IdentityController> _logger;

        private readonly IRegistrationService _registrationService;

        public IdentityController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IIdentityServerInteractionService interaction,
            ILogger<IdentityController> logger,
            IRegistrationService registrationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _logger = logger;
            _registrationService = registrationService;

            _registrationService.OnErrorsOccured += AddErrors;
        }

        [HttpPost("registration/applicant")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterApplicant(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            await _registrationService.RegisterAsync(model, DefaultRole.APPLICANT);

            if (ModelState.ErrorCount <= 0)
                return Ok();

            var errors = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            return BadRequest(errors);
        }

        [HttpPost("registration/employermanager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEmployerManager(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            await _registrationService.RegisterAsync(model, DefaultRole.EMPLOYER_MANAGER);

            if (ModelState.ErrorCount <= 0)
                return Ok();

            var errors = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            return BadRequest(errors);
        }

        [HttpPost("registration/educationalinstitutionmanager")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterEducationalInstitutionManager(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            await _registrationService.RegisterAsync(model, DefaultRole.EDUCATIONAL_INSTITUTION_MANAGER);

            if (ModelState.ErrorCount <= 0)
                return Ok();

            var errors = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            return BadRequest(errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверный формат данных");

            var user = await _userManager.FindByEmailAsync(model.Email);
            var credentialsValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!credentialsValid)
                return BadRequest("Неверный логин или пароль");

            var props = model.RememberMe
                ? new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddYears(10)
                }
                : new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),
                    AllowRefresh = true
                };

            await _signInManager.SignInAsync(user, props);

            var dtoUser = Mapper.Map<DtoUser>(user);

            return Ok(dtoUser);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut(LogOutViewModel model)
        {
            var idp = User?.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;

            if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
            {
                if (model.LogoutId == null)
                {
                    // if there's no current logout context, we need to create one
                    // this captures necessary info from the current logged in user
                    // before we signout and redirect away to the external IdP for signout
                    model.LogoutId = await _interaction.CreateLogoutContextAsync();
                }

                try
                {
                    // hack: try/catch to handle social providers that throw
                    await HttpContext.SignOutAsync(idp);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Logout error; {error}", ex.Message);
                }
            }

            // delete authentication cookie
            await HttpContext.SignOutAsync();

            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            // set this so UI rendering sees an anonymous user
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            return Ok();
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