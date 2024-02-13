using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Application.Services.Interfaces;
public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync(int page, int pageSize, string filter);
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(CategoryForCreation categoryForCreation);
    Task<Category> UpdateCategoryAsync(CategoryForUpdate categoryForUpdate);
    Task<Category> DeleteCategoryByIdAsync(int id);
}

