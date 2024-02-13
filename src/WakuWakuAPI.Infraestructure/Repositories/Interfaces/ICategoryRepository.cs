using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Infraestructure.Repositories.Interfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>?> GetCategoriesAsyncAsNoTracking();
    Task<Category?> GetCategoryByIdAsyncAsNoTracking(int id);
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category categoryToUpdate, Category newValuescategory); 
    Task<Category> DeleteCategoryByIdAsync(Category category);

}

