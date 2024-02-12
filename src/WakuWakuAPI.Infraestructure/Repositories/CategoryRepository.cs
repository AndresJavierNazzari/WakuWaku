using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using WakuWakuAPI.Infraestructure.Data;

namespace WakuWakuAPI.Infraestructure.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly WakuWakuContext _context;

    public CategoryRepository(WakuWakuContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }

    public IEnumerable<Category> GetCategories()
    {
        IEnumerable<Category> categoryList = _context.Categories;
        return categoryList;
    }

    public Category GetCategoryById(int id)
    {
        var categoryList = _context.Categories;

        if(categoryList != null)
        {
            Category category = categoryList.FirstOrDefault(c => c.Id == id);
            return category;
        }
        return null;
    }

    public Category AddCategory(CategoryForCreation categoryForCreation)
    {
        var categoryList = _context.Categories;
        return null;
        /*
         if(categoryList != null)
         {
             Category createdCategory = new Category(categoryForCreation.Name, categoryForCreation.Description);
             categoryList.Add(createdCategory);

             return createdCategory;


         };
        */

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

    public Category DeleteCategoryById(int id)
    {
        var categoryList = _context.Categories;
        if(categoryList != null)
        {
            Category? category = categoryList.FirstOrDefault(c => c.Id == id);

            categoryList.Remove(category);

            return category;
        }
        return null;
    }
}
