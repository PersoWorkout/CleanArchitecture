using CleanArchitecture.Domain.Models;
using System.ComponentModel;

namespace CleanArchitecture.Domain.DTOs
{
    public class ProductsDTO: IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public ProductsDTO(int id, string name, string description, decimal price,int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
