using DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO : BaseDTO
    {
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
        public CityDTO City { get; set; }
    }
}
