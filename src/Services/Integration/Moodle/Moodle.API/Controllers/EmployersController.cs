using BuildingBlocks.EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moodle.API.Dto;
using Moodle.API.Factories;
using Moodle.API.Integration.Events;
using Moodle.Integration;
using Moodle.Integration.Factories;
using Moodle.Integration.Models.GetUser;
using Moodle.Integration.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Moodle.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class EmployersController : ControllerBase
    {
        private readonly IMoodleRequestFactory _requestFactory;

        private readonly IMoodleIntegrator _integrator;

        private readonly IUsernameFactory _usernameFactory;

        private readonly IEventBus _eventBus;

        private readonly ILogger<EmployersController> _logger;

        public EmployersController(
            IMoodleRequestFactory requestFactory, 
            IMoodleIntegrator integrator,
            IUsernameFactory usernameFactory,
            IEventBus eventBus,
            ILogger<EmployersController> logger)
        {
            _requestFactory = requestFactory;
            _integrator = integrator;
            _usernameFactory = usernameFactory;
            _eventBus = eventBus;
            _logger = logger;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] EmployerRegistrationDto dto)
        {
            var email = new MailAddress(dto.Email);
            var username = _usernameFactory.CreateEmployerUsername(dto.Id);

            var moodleDto = _requestFactory.Create<RegistrationRequest>();
            moodleDto.UserName = username;
            moodleDto.Password = dto.Password;
            moodleDto.Email = dto.Email;
            moodleDto.FirstName = dto.Name;
            moodleDto.LastName = email.User;

            var responseCtx = await _integrator.SendRequestAsync<RegistrationResponse>(moodleDto);

            if (!responseCtx.Succeed)
            {
                _logger.LogError("Ошибка регистрации работодателя в Moodle: {@ex}", responseCtx.Exception);
                return BadRequest(responseCtx.Exception.Message);
            }

            var response = responseCtx.ResponseData;

            if (response.Success == 0)
            {
                _logger.LogError("Ошибка регистрации работодателя в Moodle");
                return BadRequest(response);
            }

            var @event = new MoodleEmployerRegisteredEvent(
                username,
                dto.Password,
                dto.Email);

            _eventBus.Publish(@event);

            return Ok(response);
        }
        
        [HttpGet("{id}/hasAccount")]
        public async Task<IActionResult> HasAccount([FromQuery]long id)
        {
            var username = _usernameFactory.CreateEmployerUsername(id);
            var request = new GetUserByUsernameRequest(username);

            var responseCtx = await _integrator.SendRequestAsync<IEnumerable<GetUserResponse>>(request);

            if (!responseCtx.Succeed)
                return BadRequest(responseCtx.Exception.Message);

            var response = responseCtx.ResponseData;

            if (response == null)
            {
                _logger.LogError("Ошибка при поиске пользователя {username}", username);
                return BadRequest($"Ошибка при поиске пользователя {username}");
            }

            if (!response.Any())
                return Ok(false);

            if (response.Count() > 1)
            {
                _logger.LogError("Найдено более одного пользователя {username}", username);
                return BadRequest($"Найдено более одного пользователя {username}");
            }

            return Ok(true);
        }

        [HttpGet("{id}/resetPassword")]
        public async Task<IActionResult> ResetPassword([FromQuery]long id)
        {
            throw new NotImplementedException();
        }
    }
}
