using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Application.Services.Interfaces;
public interface ICategoryService {
    IEnumerable<Category> GetCategories(int page, int pageSize, string filter);
    Category GetCategoryById(int id);
    Category AddCategory(CategoryForCreation categoryForCreation);
    Category UpdateCategory(int id, CategoryForUpdate categoryForUpdate);
    Category DeleteCategoryById(int id);
}

