using System.Threading.Tasks;

namespace EmailNotifications.Mailer.MailServices
{
    /// <summary>
    /// Интерфейс почтовой службы.
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Отправка сообщения.
        /// </summary>
        /// <param name="to"> Адресат. </param>
        /// <param name="theme"> Тема. </param>
        /// <param name="body"> Тело письма. </param>
        /// <returns></returns>
        void SendMail(string to, string theme, string body);

        void SendMail(EmailNotification notification);

        /// <summary>
        /// Отправка сообщения.
        /// </summary>
        /// <param name="to"> Адресат. </param>
        /// <param name="theme"> Тема. </param>
        /// <param name="body"> Тело письма. </param>
        /// <returns></returns>
        Task SendMailAsync(string to, string theme, string body);

        Task SendMailAsync(EmailNotification notification);
    }
}
