using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;

using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Presentation.Controllers;
using WakuWakuAPI.Application.Services.Interfaces;

namespace WakuWakuAPI.Presentation.Tests.Controllers;

public class CategoryControllerTests
{
    private readonly IValidator<CategoryForCreation> _validator;
    private readonly IValidator<CategoryForUpdate> _updateValidator;
    private readonly ICategoryService _categoryService;

    public CategoryControllerTests()
    {
        _validator = Substitute.For<IValidator<CategoryForCreation>>();
        _updateValidator = Substitute.For<IValidator<CategoryForUpdate>>();
        _categoryService = Substitute.For<ICategoryService>();
    }

    private CategoryController GetControllerInstance() => new(_validator, _categoryService);

    [Fact]
    public async Task GetCategories_ShouldReturnOk()
    {
        // Arrange
        var expectedCategories = new List<Category>();

        _categoryService.GetCategoriesAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<string>())
            .Returns(Task.FromResult<IEnumerable<Category>>(expectedCategories));

        var controller = GetControllerInstance();

        // Act  
        var result = await controller.GetCategoriesAsync();

        // Assert
        result.Should().BeOfType<ActionResult<IEnumerable<Category>>>();
        result.Result.Should().BeOfType<OkObjectResult>();
        (result?.Result as OkObjectResult)?.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetCategoryById_ShouldReturnOk()
    {
        // Arrange
        int categoryId = 1;
        var expectedCategory = new Category { Id = categoryId, Name = "Test Category" };
        _categoryService.GetCategoryByIdAsync(categoryId)
            .Returns(Task.FromResult(expectedCategory));

        var controller = GetControllerInstance();

        // Act  
        var result = await controller.GetCategoryByIdAsync(categoryId);

        // Assert
        result.Should().BeOfType<ActionResult<Category>>();
        result.Result.Should().BeOfType<OkObjectResult>();
        (result?.Result as OkObjectResult)?.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task CreateCategory_ShouldReturnCreated()
    {
        // Arrange
        var categoryForCreation = new CategoryForCreation { Name = "Test Category", Description = "Test description" };
        _validator.Validate(categoryForCreation).Returns(new ValidationResult());

        var controller = GetControllerInstance();

        // Act  
        var result = await controller.CreateCategoryAsync(categoryForCreation);

        // Assert
        result.Should().BeOfType<ActionResult<Category>>();
        result.Result.Should().BeOfType<CreatedAtRouteResult>();
        (result?.Result as CreatedAtRouteResult)?.StatusCode.Should().Be(StatusCodes.Status201Created);
    }

    [Fact]
    public async Task CreateCategory_InvalidModel_ShouldReturnUnprocessableEntity()
    {
        // Arrange
        var invalidCategory = new CategoryForCreation { Name = null }; // Modelo inválido, ya que el campo "Name" es null
        var validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Name", "Name is required") });
        _validator.Validate(invalidCategory).Returns(validationResult);

        var controller = GetControllerInstance();

        // Act y Assert 
        await Assert.ThrowsAsync<ValidationException>(async () => await controller.CreateCategoryAsync(invalidCategory));
    }


    [Fact]
    public async Task UpdateCategory_ShouldReturnOk()
    {
        // Arrange
        var categoryForUpdate = new CategoryForUpdate { Id = 1, Name = "Updated Category", Description = "Updated Test description" };
        _updateValidator.Validate(categoryForUpdate).Returns(new ValidationResult());

        var controller = GetControllerInstance();

        // Act  
        var result = await controller.UpdateCategoryAsync(categoryForUpdate);

        // Assert
        result.Should().BeOfType<ActionResult<Category>>();
        result.Result.Should().BeOfType<OkObjectResult>();
        (result?.Result as OkObjectResult)?.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task DeleteCategory_ShouldReturnOk()
    {
        // Arrange
        int categoryId = 1;
        var deletedCategory = new Category { Id = categoryId, Name = "Deleted Category" };
        _categoryService.DeleteCategoryByIdAsync(categoryId)
            .Returns(Task.FromResult(deletedCategory));

        var controller = GetControllerInstance();

        // Act  
        var result = await controller.DeleteCategoryAsync(categoryId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        (result as OkObjectResult)?.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

}

