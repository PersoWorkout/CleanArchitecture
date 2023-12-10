using System.Text.Json.Serialization;

namespace CleanArchitecture.Infrastructure.Models
{
    public class Products: Domain.Models.IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Categories Category { get; set; }
    }
}
