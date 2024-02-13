using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Infraestructure.Data;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;

namespace WakuWakuAPI.Infraestructure.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly WakuWakuContext _context;

    public CategoryRepository(WakuWakuContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }

    public async Task<IEnumerable<Category>?> GetCategoriesAsync()
    {
        return await Task.FromResult(_context.Categories.ToList());
    }

    public async Task<Category?> GetCategoryByIdAsyncAsNoTracking(int id)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Category AddCategory(CategoryForCreation categoryForCreation)
    {
        var categoryList = _context.Categories;
        return null;
    }

    public Category UpdateCategory(int id, CategoryForUpdate categoryForUpdate)
    {
        var categoryList = _context.Categories;

        if(categoryList != null)
        {
            Category? existingCategory = categoryList.FirstOrDefault(c => c.Id == id);

            existingCategory.Name = categoryForUpdate.Name;
            existingCategory.Description = categoryForUpdate.Description;

            return existingCategory;
        }
        return null;
    }

    public async Task<Category> DeleteCategoryByIdAsync(Category category)
    {
        // Temporarily change the state of the entity to Detached
        //_context.Entry(category).State = EntityState.Detached;
        // Remove the entity physically
        //_context.Categories.Remove(category);

        // Mark the entity as deleted
        _context.Entry(category).State = EntityState.Deleted;

        // Save the changes to the database using the overridden method
        await _context.SaveChangesAsync();
        return category;
    }

}
