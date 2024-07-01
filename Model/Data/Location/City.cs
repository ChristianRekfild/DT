using DT.Model.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DT.Model.Data.Location
{
    public class City : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Область
        /// </summary>
        [Required]
        public Region Region { get; set; }
    }
}
