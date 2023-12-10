using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Application.Repository
{
    public interface ICategoriesRepository
    {
        Task<List<CategoriesDTO>> ListCategories();
        Task<CategoriesDTO?> CategoryById(int id);
        Task<CategoriesDTO?> Create(CategoryValidator payload);
        Task<CategoriesDTO?> Update(int id, CategoryValidator payload);
    }
}
