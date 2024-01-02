using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Infraestructure.Repositories.Interfaces;
public interface ICategoryRepository {
    IEnumerable<Category> GetCategories();
    Category GetCategoryById(int id);
    Category AddCategory(CategoryForCreation categoryForCreation);
    Category UpdateCategory(int id, CategoryForUpdate categoryForUpdate);
    Category DeleteCategoryById(int id);

}

