using DT.Model.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DT.Model.Data.Location
{
    public class Region : BaseEntity
    {
        /// <summary>
        /// Название области
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Список городов для данной области
        /// </summary>
        public List<City> Cities { get; } = new List<City>();
    }
}
