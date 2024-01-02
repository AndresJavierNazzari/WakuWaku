using NSubstitute;
using WakuWakuAPI.Application.Services.Interfaces;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Presentation.Controllers;
using FluentAssertions;
using FluentValidation;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace WakuWakuAPI.Presentation.Tests.Controllers;
public class CategoryControllerTests {
    private readonly IValidator<CategoryForCreation> _validator;
    private readonly ICategoryService _categoryService;

    public CategoryControllerTests() {
        _validator = Substitute.For<IValidator<CategoryForCreation>>();
        _categoryService = Substitute.For<ICategoryService>();
    }

    [Fact]
    public void GetCategories_ShouldReturnOk() {
        //Arrange
        _categoryService.GetCategories(1, 10, "").Returns(new List<Category>());

        var controller = GetControllerInstance();

        //Act
        var result = controller.GetCategories();

        //Assert
        (result.Result as OkObjectResult)!.StatusCode.Should().Be(200);
    }

    private CategoryController GetControllerInstance() =>
    new(_validator, _categoryService);
}

