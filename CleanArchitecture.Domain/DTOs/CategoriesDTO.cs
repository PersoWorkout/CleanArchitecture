using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.DTOs
{
    public class CategoriesDTO: ICategories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoriesDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
