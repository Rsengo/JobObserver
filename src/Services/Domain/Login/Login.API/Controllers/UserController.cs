using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Login.Db.Dto.Models;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeUserInformation(DtoUser dto, string id)
        {
            var newUser = Mapper.Map<User>(dto);
            newUser.Id = id;

            await _userManager.UpdateAsync(newUser);

            var response = Mapper.Map<DtoUser>(newUser);

            return Ok(response);
        }
    }
}
