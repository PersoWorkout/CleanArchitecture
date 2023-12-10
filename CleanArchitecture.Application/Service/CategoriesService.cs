using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Application.Service
{
    public class CategoriesService: ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository) {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<CategoriesDTO>> ListCategories() { 
            return await _categoriesRepository.ListCategories();
        }
        public async Task<CategoriesDTO?> CategoryById(int id)
        {
            return await _categoriesRepository.CategoryById(id);
        }
        public async Task<CategoriesDTO?> Create(CategoryValidator payload)
        {
            return await _categoriesRepository.Create(payload);
        }
        public async Task<CategoriesDTO?> Update(int id, CategoryValidator payload)
        {
            return await _categoriesRepository.Update(id, payload);
        }
    }
}
