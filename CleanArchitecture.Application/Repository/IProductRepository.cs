using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Application.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductsDTO>> ProductsList();
        Task<ProductsDTO?> ProductById(int id);
        Task<ProductsDTO?> Create(CreateProductValidator payload);
        Task<ProductsDTO?> Update(int id, UpdateProductValidator payload);
    }
}
