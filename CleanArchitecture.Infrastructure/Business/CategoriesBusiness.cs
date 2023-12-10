using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Business
{
    public class CategoriesBusiness: ICategoriesRepository
    {
        private readonly CatalogDbContext _db;

        public CategoriesBusiness(CatalogDbContext db) {
            _db = db;
        }

        public async Task<List<CategoriesDTO>> ListCategories()
        {
            return await _db.Categories.Select((c) => new CategoriesDTO(c.Id, c.Name)).ToListAsync();
        }

        public async Task<CategoriesDTO?> CategoryById(int id)
        {
            return await _db.Categories.Where((c) => c.Id == id).Select((c) => new CategoriesDTO(c.Id, c.Name)).FirstOrDefaultAsync();
        }

        public async Task<CategoriesDTO?> Create(CategoryValidator payload)
        {
            Categories category = new Categories()
            {
                Name = payload.name
            };

            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return new CategoriesDTO(category.Id, category.Name);
        }

        public async Task<CategoriesDTO?> Update(int id, CategoryValidator payload)
        {
            Categories? category = await _db.Categories.Where((c) => c.Id == id).FirstOrDefaultAsync();
            if(category == null)
            {
                return null;
            }

            category.Name = payload.name;
            await _db.SaveChangesAsync();

            return new CategoriesDTO(category.Id, category.Name);
        }
    }
}
