using System.Text.Json.Serialization;

namespace CleanArchitecture.Infrastructure.Models
{
    public class Categories: Domain.Models.ICategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Products>? Products { get; set; }
    }
}
