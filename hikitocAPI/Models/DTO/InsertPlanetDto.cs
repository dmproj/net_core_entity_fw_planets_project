using hikitocAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.DTO
{
    public class InsertPlanetDto
    {
        [StringLength(30)] //nvarchar(20)
        public string Name { get; set; } = null!; //null-forgiving op.

        [StringLength(1000)]
        public string Description { get; set; }
        public double DiameterKm { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }
        public Guid SolarSystemId { get; set; }
        public Guid WaterId { get; set; }
    }
}

