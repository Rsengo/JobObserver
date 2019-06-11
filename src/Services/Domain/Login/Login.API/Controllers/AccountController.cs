using System;
using System.Security.Claims;
using System.Text;
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
    [Route("[controller]")]
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
        public async Task<IActionResult> Login([FromQuery]string ReturnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(ReturnUrl);
            if (context?.IdP != null)
            {
                //if IdP is passed, then bypass showing the login screen
                return ExternalLogin(context.IdP, ReturnUrl);
            }

            var encoded = _cryptoService.Encrypt(ReturnUrl);

            return Redirect(_redirectSettings.Value.FullLoginPageUrl + encoded);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            _logger.LogCritical($"{model.Email}+\n+{model.Password}+\n+{model.RememberMe}+\n+{model.ReturnUrl}");
            
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

            var returnUrl = _cryptoService.Decrypt(model.ReturnUrl);

            return Ok(returnUrl);
        }

        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet("logout")]
        public async Task<IActionResult> Logout([FromQuery]string logoutId)
        {
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

            var postLogoutUrl = logout?.PostLogoutRedirectUri;

            if (postLogoutUrl != null)
                return Redirect(postLogoutUrl);

            return Redirect($"{_redirectSettings.Value.WebAppClient}/");
        }

        [HttpGet("devicelogout")]
        public async Task<IActionResult> DeviceLogOut([FromQuery]string redirectUrl)
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
        [HttpGet("externallogin")]
        public IActionResult ExternalLogin([FromQuery]string provider, [FromQuery]string returnUrl)
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