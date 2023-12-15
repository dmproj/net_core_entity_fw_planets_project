using hikitocAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.DTO
{
    public class UpdatePlanetDto
    {
        [StringLength(30, MinimumLength = 1, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string Name { get; set; } = null!;

        //[Required(ErrorMessage = "[Required] attribute, ** custom error message **")] // The [Required] attribute can be omitted, as it is handled implicitly by the framework.
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string Description { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "The DiameterKm field must be a positive value")]
        public double DiameterKm { get; set; }

        [StringLength(1000, MinimumLength = 1, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string? Image { get; set; }
        public Guid SolarSystemId { get; set; }
        public Guid WaterId { get; set; }
    }
}

