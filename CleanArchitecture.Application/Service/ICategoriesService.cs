using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Validators;

namespace CleanArchitecture.Application.Service
{
    public interface ICategoriesService
    {
        Task<List<CategoriesDTO>> ListCategories();
        Task<CategoriesDTO?> CategoryById(int id);
        Task<CategoriesDTO?> Create(CategoryValidator payload);
        Task<CategoriesDTO?> Update(int id, CategoryValidator payload);
    }
}
