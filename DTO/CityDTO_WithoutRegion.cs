using DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CityDTO_WithoutRegion : BaseDTO
    {
        /// <summary>
        /// Название города
        /// </summary>
        [Required]
        public string Name { get; set; }

    }
}
