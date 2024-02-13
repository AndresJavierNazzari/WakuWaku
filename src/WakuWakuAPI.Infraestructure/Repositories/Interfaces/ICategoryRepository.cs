using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Infraestructure.Repositories.Interfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>?> GetCategoriesAsync();
    Task<Category?> GetCategoryByIdAsyncAsNoTracking(int id);
    Task<Category?> GetCategoryByIdAsync(int id);
    Category AddCategory(CategoryForCreation categoryForCreation);
    Category UpdateCategory(int id, CategoryForUpdate categoryForUpdate);
    Task<Category> DeleteCategoryByIdAsync(Category category);

}

