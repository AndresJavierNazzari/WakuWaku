using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Application.Services.Interfaces;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using System;
using WakuWakuAPI.Application.CrossCutting;

namespace WakuWakuAPI.Application.Services;
public class CategoryService : ICategoryService {

    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository) {
        ArgumentNullException.ThrowIfNull(categoryRepository);
        _categoryRepository = categoryRepository;

    }

    public IEnumerable<Category> GetCategories(int page = 1, int pageSize = 10, string filter = "") {
        var categoryList = _categoryRepository.GetCategories();
        NotFoundException.ThrowIfNull(categoryList);

        var paginatedCategories = categoryList.Skip((page - 1) * pageSize).Take(pageSize);

        if(!string.IsNullOrEmpty(filter)) {
            paginatedCategories =
                paginatedCategories.Where(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)
                || c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        return paginatedCategories;
    }

    public Category GetCategoryById(int id) {
        var category = _categoryRepository.GetCategoryById(id);
        NotFoundException.ThrowIfNull(category);

        return category;
    }
    public Category AddCategory(CategoryForCreation categoryForCreation) {
        var createdCategory = _categoryRepository.AddCategory(categoryForCreation);

        return createdCategory;
    }

    public Category UpdateCategory(int id, CategoryForUpdate categoryForUpdate) {
        Category UpdatedCategory = _categoryRepository.UpdateCategory(id, categoryForUpdate);

        return UpdatedCategory;
    }
    public Category DeleteCategoryById(int id) {
        var category = _categoryRepository.DeleteCategoryById(id);

        return category;
    }

}

