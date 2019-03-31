using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailNotifications.Mailer;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotifications.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly Mailer.MailServices.Mailer _mailer;

        public MailController(Mailer.MailServices.Mailer mailer)
        {
            _mailer = mailer;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(EmailNotification message)
        {
            await _mailer.SendMailAsync(message);

            return Ok();
        }
    }
}
