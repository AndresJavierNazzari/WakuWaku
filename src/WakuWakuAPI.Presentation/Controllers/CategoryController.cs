using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using FluentValidation;
using FluentValidation.Results;
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Application.Consts;
using WakuWakuAPI.Application.CrossCutting;
using WakuWakuAPI.Application.Services.Interfaces;

namespace WakuWakuAPI.Presentation.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private IValidator<CategoryForCreation> _validator;

    public CategoryController(IValidator<CategoryForCreation> validator, ICategoryService categoryService)
    {
        _validator = validator;
        _categoryService = categoryService;
    }

    // GET: /Category
    [HttpGet]
    [HttpHead]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "")
    {
        var categories = await _categoryService.GetCategoriesAsync(page, pageSize, filter);
        return Ok(categories);
    }

    // GET: /Category/{categoryId}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Category>> GetCategoryById(int id = 0)
    {
        EmptyIdException.ThrowIfIdZero(id, ErrorMessage.IdZeroOrNegative);
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    // DELETE: /Category/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteCategory(int id = 0)
    {
        EmptyIdException.ThrowIfIdZero(id);
        var deletedCategory = _categoryService.DeleteCategoryByIdAsync(id);

        var response = new
        {
            message = $"Resource deleted: category {id}",
            deletedCategory
        };

        return Ok(response);
    }

    // OPTIONS: /Category
    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult OptionsCategory()
    {
        Response.Headers.Append("Allow", "GET, POST, PUT, DELETE, OPTIONS");
        return Ok();
    }
    /*
    // POST: /Category
    [HttpPost(Name = "CreateCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public ActionResult<Category> CreateCategory([FromBody] CategoryForCreation categoryForCreation)
    {

        ValidationResult result = _validator.Validate(categoryForCreation);

        if(!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var category = _categoryService.AddCategory(categoryForCreation);
        return CreatedAtRoute("CreateCategory", new { id = category.Id }, category);
    }

    //  PUT: /Category/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Category> UpdateCategory([FromBody] CategoryForUpdate categoryForUpdate, int id = 0)
    {
        EmptyIdException.ThrowIfIdZero(id);
        var category = _categoryService.UpdateCategory(id, categoryForUpdate);

        return Ok(category);
    }

    

   
    */
}



