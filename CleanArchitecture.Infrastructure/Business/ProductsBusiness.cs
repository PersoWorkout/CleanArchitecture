using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Business
{
    public class ProductsBusiness: IProductRepository
    {
        private readonly CatalogDbContext _db;
        public ProductsBusiness(CatalogDbContext db) {
            _db = db;
        }
        public async Task<List<ProductsDTO>> ProductsList()
        {
            return await _db.Products.Select((p) => new ProductsDTO(p.Id, p.Name, p.Description, p.Price, p.CategoryId)).ToListAsync();
        }

        public async Task<ProductsDTO> ProductById(int id)
        {
            return await _db.Products.Where((p) => p.Id == id).Select((p) => new ProductsDTO(p.Id, p.Name, p.Description, p.Price, p.CategoryId)).FirstOrDefaultAsync();
        }

        public async Task<ProductsDTO> Create(CreateProductValidator payload)
        {
            if (!await _db.Categories.AnyAsync((c) => c.Id == payload.idCategory))
            {
                return null;
            }

            Products product = new()
            {
                Name = payload.name,
                Description = payload.description,
                Price = payload.price,
                CategoryId = payload.idCategory
            };

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return new ProductsDTO(product.Id, product.Name, product.Description, product.Price, product.CategoryId);
        }

        public async Task<ProductsDTO?> Update(int id, UpdateProductValidator payload)
        {
            Products? product = await _db.Products.Where((p) => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return null;
            }

            if (payload.idCategory != null && !await _db.Categories.AnyAsync((c) => c.Id == payload.idCategory))
            {
                return null;
            }

            product.Name = !string.IsNullOrEmpty(payload.name) ? payload.name : product.Name;
            product.Description = !string.IsNullOrEmpty(payload.description) ? payload.description : product.Description;
            product.Price = payload.price.GetValueOrDefault(product.Price);
            product.CategoryId = payload.idCategory.GetValueOrDefault(product.CategoryId);

            await _db.SaveChangesAsync();

            return new ProductsDTO(product.Id, product.Name, product.Description, product.Price, product.CategoryId);
        }
    }
}
