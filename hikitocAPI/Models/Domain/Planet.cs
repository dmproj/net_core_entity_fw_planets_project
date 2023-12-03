using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.Domain
{
    public class Planet : IValidatableObject
    {
        [Key]
        public Guid PlanetId { get; set; }

        [StringLength(30)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "[Required] attribute, ** custom error message **")]
        [StringLength(1000)]
        public string Description { get; set; }

        public double DiameterKm { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }

        public Guid SolarSystemId { get; set; }
        public Guid WaterId { get; set; }

        public SolarSystem SolarSystem { get; set; }
        public Water Water { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var results = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                //results.Add(new ValidationResult("Planet name is required.", new[] { nameof(Name) }));
                yield return new ValidationResult("Planet name is required.", new[] { nameof(Name) });
            }

            if (DiameterKm <= 0)
            {
                //results.Add(new ValidationResult("Diameter must be a positive value.", new[] { nameof(DiameterKm) }));
                yield return new ValidationResult("Diameter must be a positive value.", new[] { nameof(DiameterKm) });
            }

            //return results;
        }
    }
}
