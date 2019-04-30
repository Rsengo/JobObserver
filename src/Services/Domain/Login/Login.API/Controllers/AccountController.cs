using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Services;
using Login.API.Services;
using Login.API.ViewModels;
using Login.Db.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Login.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly IIdentityServerInteractionService _interaction;

        private readonly ILogger<AccountController> _logger;

        private readonly IOptions<RedirectSettings> _redirectSettings;

        private readonly ICryptoService _cryptoService;

        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IIdentityServerInteractionService interaction,
            ILogger<AccountController> logger,
            IOptions<RedirectSettings> redirectSettings,
            ICryptoService cryptoService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _logger = logger;
            _redirectSettings = redirectSettings;
            _cryptoService = cryptoService;
        }

        /// <summary>
        /// Show login page
        /// </summary>
        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null)
            {
                //if IdP is passed, then bypass showing the login screen
                return ExternalLogin(context.IdP, returnUrl);
            }

            var encodedUrl = _cryptoService.Encrypt(returnUrl);
            return Redirect(_redirectSettings.Value.FullLoginPageUrl + encodedUrl);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //TODO обработка ошибок
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

            var encodedUrl = model.ReturnUrl;
            var decodedUrl = _cryptoService.Decrypt(encodedUrl);

            return Ok(decodedUrl);
        }

        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet("logout")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                // if the user is not authenticated, then just show logged out page
                return await Logout(new LogoutViewModel { LogoutId = logoutId });
            }

            //Test for Xamarin. 
            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                //it's safe to automatically sign-out
                return await Logout(new LogoutViewModel { LogoutId = logoutId });
            }

            var encodedLogoutId = _cryptoService.Encrypt(logoutId);
            return Redirect(_redirectSettings.Value.FullLogoutPageUrl + encodedLogoutId);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutViewModel model)
        {
            string logoutId = null;

            if (model.LogoutId != null)
            {
                var logoutIdEncrypt = model.LogoutId;
                logoutId = _cryptoService.Decrypt(logoutIdEncrypt);
            }

            var idp = User?.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;

            if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
            {
                if (logoutId == null)
                {
                    // if there's no current logout context, we need to create one
                    // this captures necessary info from the current logged in user
                    // before we signout and redirect away to the external IdP for signout
                    logoutId = await _interaction.CreateLogoutContextAsync();
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

            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var encodedUrl = logout?.PostLogoutRedirectUri;
            var decodedUrl = _cryptoService.Decrypt(encodedUrl);

            return Redirect(decodedUrl);
        }

        public async Task<IActionResult> DeviceLogOut(string redirectUrl)
        {
            // delete authentication cookie
            await HttpContext.SignOutAsync();

            // set this so UI rendering sees an anonymous user
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            return Redirect(redirectUrl);
        }
        
        /// <summary>
        /// initiate roundtrip to external authentication provider
        /// </summary>
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            if (returnUrl != null)
            {
                returnUrl = UrlEncoder.Default.Encode(returnUrl);
            }
            returnUrl = "/account/externallogincallback?returnUrl=" + returnUrl;

            // start challenge and roundtrip the return URL
            var props = new AuthenticationProperties
            {
                RedirectUri = returnUrl,
                Items = { { "scheme", provider } }
            };
            return new ChallengeResult(provider, props);
        }
    }
}