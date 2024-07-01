using DT.Model.Data.Base;
using DT.Model.Data.Location;
using System.ComponentModel.DataAnnotations;

namespace DT.Model.Data
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Логин пользователя для входа
        /// </summary>
        [Required]
        [StringLength(100)]

        public string Login { get; set; }
        /// <summary>
        /// Хэш пароля
        /// </summary>
        [StringLength(150)]
        [Required]

        public string Password { get; set; }
        /// <summary>
        /// Email пользователя
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Имя пользователя, видимое для других пользователей
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Пол пользователя. 0 - девочка, 1 - мальчик. Думаю, понятно, почему? =)
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// Если пользователь ничего не написал в "о себе" - то зачем он тут нужен? Мы таких не любим! >=(
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Наличие детей; false - нет, true - есть
        /// </summary>
        public bool HaveChildren { get; set; }

        /// <summary>
        /// Город, в котором живет пользователь
        /// </summary>
        [Required]
        public City City { get; set; }
    }
}
