using System;
using BuildingBlocks.EntityFramework.Models;
using Login.Db.Models.Contacts;
using Login.Db.Models.Geographic;

namespace Login.Db.Models
{
    /// <summary>
    ///     Абстрактный пользователь
    /// </summary>
    public abstract class BaseUser : RelationalEntity
    {
        /// <summary>
        ///     Фамилия
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        ///     Имя
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        ///     Отчество
        /// </summary>
        public virtual string MiddleName { get; set; }

        /// <summary>
        ///     Дата рождения
        /// </summary>
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        ///     Контакты
        /// </summary>
        public virtual Contact Contacts { get; set; }

        /// <summary>
        ///     Id Контактов
        /// </summary>
        public virtual long? ContactsId { get; set; }

        /// <summary>
        ///     Пол
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        ///     Id Пола
        /// </summary>
        public virtual long? GenderId { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Город
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        ///     Полное имя
        /// </summary>
        public virtual string FullName => $"{FirstName} {MiddleName} {LastName}";
    }
}