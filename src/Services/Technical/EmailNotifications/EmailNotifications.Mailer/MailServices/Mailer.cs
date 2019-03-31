using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EmailNotifications.Mailer.Providers;
using Microsoft.Extensions.Logging;

namespace EmailNotifications.Mailer.MailServices
{
    public class Mailer: IMailService, IDisposable
    {
        /// <summary>
        /// SMTP-провайдер по умолчанию
        /// </summary>
        private readonly SmtpProvider _provider;

        private readonly SmtpClient _client;

        private readonly ILogger<IMailService> _logger;

        /// <summary>
        /// Конфигурация.
        /// </summary>
        /// <param name="provider"> Провайдер. </param>
        public Mailer(SmtpProvider provider, ILogger<IMailService> logger)
        {
            _logger = logger;
            _provider = provider;
            _client = Connect(provider);
        }

        /// <inheritdoc/>
        public void SendMail(string to, string theme, string body)
        {
            var message = new EmailNotification
            {
                Body = body,
                Theme = theme,
                To = to
            };

            SendMail(message);
        }

        public void SendMail(EmailNotification notification)
        {
            using (var mail = CreateMessage(notification))
            {
                SetCallbacks(_client, notification);
                _client.Send(mail);
            }
        }

        public Task SendMailAsync(string to, string theme, string body)
        {
            var message = new EmailNotification
            {
                Body = body,
                Theme = theme,
                To = to
            };

            return SendMailAsync(message);
        }

        public async Task SendMailAsync(EmailNotification notification)
        {
            using (var mail = CreateMessage(notification))
            {
                await _client.SendMailAsync(mail);
            }
        }

        private void SetCallbacks(SmtpClient client, EmailNotification mail)
        {
            client.SendCompleted += (s, e) =>
            {
                if (e.Cancelled)
                {
                    _logger.LogError("Sending message '{@mail}' was cancelled. Reason: Timeout", mail);
                }

                if (e.Error != null)
                {
                    _logger.LogError("Failed to deliver {@mail} Problem is: {error}", mail, e.Error.Message);
                }

                _logger.LogInformation("The mail {@mail} was successfully delivered!", mail);
            };
        }

        private static SmtpClient Connect(SmtpProvider provider)
        {
            var client = new SmtpClient
            {
                Port = provider.Port,
                EnableSsl = provider.EnableSSL,
                Timeout = provider.TimeOut,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = provider.Host,
                Credentials = new NetworkCredential(provider.Email, provider.Password)
            };

            return client;
        }

        private MailMessage CreateMessage(EmailNotification notification)
        {
            var mail = new MailMessage(_provider.Email, notification.To)
            {
                Subject = notification.Theme,
                Body = notification.Body
            };

            return mail;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
