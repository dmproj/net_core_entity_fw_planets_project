using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.Domain
{
    public class SolarSystem
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)] //nvarchar(30)
        public string Code { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }

    }
}