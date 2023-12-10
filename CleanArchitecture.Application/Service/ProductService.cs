using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Application.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            this.productRepository = productRepository;
        }
        public Task<List<ProductsDTO>> ProductsList()
        {
            return productRepository.ProductsList();
        }

        public Task<ProductsDTO> ProductById(int id)
        {
            return productRepository.ProductById(id);
        }

        public Task<ProductsDTO> Create(CreateProductValidator payload)
        {
            return productRepository.Create(payload);
        }

        public Task<ProductsDTO> Update(int id, UpdateProductValidator payload)
        {
            return productRepository.Update(id, payload);
        }
    }
}
