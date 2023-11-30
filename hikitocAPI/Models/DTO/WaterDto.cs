using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.DTO
{
    public class WaterDto
    {
        public Guid Id { get; set; }

        [StringLength(30)] //nvarchar(30)
        public string Type { get; set; }

        [StringLength(1000)]
        public string? Image { get; set; }

    }
}

