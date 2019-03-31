using Newtonsoft.Json;

namespace EmailNotifications.Mailer.Providers
{
    /// <summary>
    /// Абстрактный класс, задающий методы создания Хоста и получения полного e-mail
    /// </summary>
    public class SmtpProvider
    {
        private const int DEFAULT_TIMEOUT = 20000;

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Домен.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Использовать SSL.
        /// </summary>
        public bool EnableSSL { get; set; }

        /// <summary>
        /// Порт.
        /// </summary>
        public int Port { get; set; }

        public int TimeOut { get; set; }

        /// <summary>
        /// Полный E-mail.
        /// </summary>
        public string Email => 
            $"{Login}@{Domain}";

        /// <summary>
        /// Хост.
        /// </summary>
        public string Host => 
            $"smtp.{Domain}";

        public SmtpProvider()
        {
            TimeOut = DEFAULT_TIMEOUT;
        }
    }
}
