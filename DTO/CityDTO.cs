using DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CityDTO : BaseDTO
    {
        /// <summary>
        /// Название города
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Область
        /// </summary>
        [Required]
        public RegionDTO Region { get; set; }
    }
}
