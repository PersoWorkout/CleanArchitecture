using System.Text.Json.Serialization;

namespace CleanArchitecture.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Products>? Products { get; set; }
    }
}
