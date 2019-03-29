using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Login.Db.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public IdentityController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные входные данные");

            var user = new User
                {
                    //todo
                };

            var result = await _userManager.CreateAsync(user, "");
            if (result.Errors.Any())
            {
                AddErrors(result);
            }

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