using MapsterMapper;

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
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(categoryRepository);
        ArgumentNullException.ThrowIfNull(mapper);
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync(int page = 1, int pageSize = 10, string filter = "")
    {
        var categoryList = await _categoryRepository.GetCategoriesAsyncAsNoTracking();
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

    public async Task<Category> AddCategoryAsync(CategoryForCreation categoryForCreation)
    {
        var category = _mapper.Map<Category>(categoryForCreation);
        
        await _categoryRepository.AddCategoryAsync(category);

        return category;
    }

    public async Task<Category> UpdateCategoryAsync(CategoryForUpdate categoryForUpdate)
    {
        var newValuescategory = _mapper.Map<Category>(categoryForUpdate);
        var categoryToUpdate = await _categoryRepository.GetCategoryByIdAsync(newValuescategory.Id); 
        var UpdatedCategory = await _categoryRepository.UpdateCategoryAsync(categoryToUpdate!, newValuescategory);

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

