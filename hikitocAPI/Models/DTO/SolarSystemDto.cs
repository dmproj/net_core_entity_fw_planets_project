using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.DTO
{
    public class SolarSystemDto
    {
        public Guid Id { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string Code { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(1000, MinimumLength = 1, ErrorMessage = "The {0} field must be between {2} and {1} characters")]
        public string? Image { get; set; }

    }
}

