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

    public async Task<IEnumerable<Category>?> GetCategoriesAsyncAsNoTracking()
    {
        return await _context.Categories
            .Include(c=>c.Skills)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsyncAsNoTracking(int id)
    {
        return await _context.Categories
            .Include(c => c.Skills)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category categoryToUpdate, Category newValuesCategory)
    {
        // Save the value of CreatedAt from the original entity
        var createdAt = categoryToUpdate.CreatedAt;

        // Copy the values from the new entity to the original entity
        _context.Entry(categoryToUpdate).CurrentValues.SetValues(newValuesCategory);

        // Restore the value of CreatedAt
        categoryToUpdate.CreatedAt = createdAt;

        // Set the state of the entity as modified
        _context.Entry(categoryToUpdate).State = EntityState.Modified;

        // Save the changes
        await _context.SaveChangesAsync();

        // Return the updated entity
        return categoryToUpdate;
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
