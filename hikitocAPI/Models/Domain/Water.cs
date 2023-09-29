using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.Domain
{
    public class Water
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)] //nvarchar(30)
        public string Type { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }

    }
}
