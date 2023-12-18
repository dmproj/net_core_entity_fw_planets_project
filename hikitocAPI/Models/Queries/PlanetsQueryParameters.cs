namespace hikitocAPI.Models.Queries
{
    public class PlanetsQueryParameters
    {
        public string? FilterBy{ get; set; }
        public string? Contains{ get; set; }
        public string? SortBy { get; set; } //= "Something";
    }
}
