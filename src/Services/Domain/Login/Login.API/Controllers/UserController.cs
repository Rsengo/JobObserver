using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Login.API.Configuration;
using Login.Db.Dto.Models;
using Login.Db.Models;
using Login.Db.Synchronization.Events.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly IEventBus _eventBus;

        public UserController(
            UserManager<User> userManager,
             IEventBus eventBus)
        {
            _userManager = userManager;
            _eventBus = eventBus;
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

        [HttpPost("restoreadmin")]
        public async Task<IActionResult> RestoreAdmin()
        {
            var user = await _userManager.FindByEmailAsync(IdentityConfig.ADMIN_EMAIL);
            var dto = Mapper.Map<DtoUser>(user);

            var @event = new UsersChanged
            {
                Created = new [] { dto }
            };

            _eventBus.Publish(@event);

            return Ok();
        }
    }
}
