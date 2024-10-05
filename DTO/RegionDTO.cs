using DTO.Base;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class RegionDTO : BaseDTO
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Название области
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Список городов для данной области
        /// </summary>
        public List<CityDTO> Cities { get; } = new List<CityDTO>();
    }
}
