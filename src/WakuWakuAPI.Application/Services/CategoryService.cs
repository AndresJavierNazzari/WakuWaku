using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Application.Services.Interfaces;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using WakuWakuAPI.Application.CrossCutting;
using WakuWakuAPI.Application.Consts;

namespace WakuWakuAPI.Application.Services;
public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        ArgumentNullException.ThrowIfNull(categoryRepository);
        _categoryRepository = categoryRepository;

    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync(int page = 1, int pageSize = 10, string filter = "")
    {
        var categoryList = await _categoryRepository.GetCategoriesAsync();
        NotFoundException.ThrowIfNull(categoryList, ErrorMessage.CategoryListEmpty);

        var paginatedCategories = categoryList!.Skip((page - 1) * pageSize).Take(pageSize);

        if(!string.IsNullOrEmpty(filter))
        {
            paginatedCategories =
                paginatedCategories.Where(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)
                || c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        return paginatedCategories!;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsyncAsNoTracking(id);
        NotFoundException.ThrowIfNull(category, $"{ErrorMessage.CategoryIdNotFound} {id}");

        return category!;
    }

    public Category AddCategory(CategoryForCreation categoryForCreation)
    {
        var createdCategory = _categoryRepository.AddCategory(categoryForCreation);

        return createdCategory;
    }

    public Category UpdateCategory(int id, CategoryForUpdate categoryForUpdate)
    {
        Category UpdatedCategory = _categoryRepository.UpdateCategory(id, categoryForUpdate);

        return UpdatedCategory;
    }
    public async Task<Category> DeleteCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        NotFoundException.ThrowIfNull(category, $"{ErrorMessage.CategoryIdNotFound} {id}");

        await _categoryRepository.DeleteCategoryByIdAsync(category!);
        return category!;
    }
}

