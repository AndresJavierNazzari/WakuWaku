using System.Text.Json;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Integration.Tests;
public class CategoryControllerTests : IClassFixture<WakuWakuApiFactory>
{
    public readonly HttpClient _client;

    public CategoryControllerTests(WakuWakuApiFactory factory)
    {
        factory.ClientOptions.BaseAddress = new Uri("https://localhost:7202/api/v1/category");
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCategories_ShouldReturnCategories()
    {
        // Arrange
        var response = await _client.GetStringAsync("");

        // Act
        var categories = JsonSerializer.Deserialize<IEnumerable<Category>>(response);

        // Assert
        Assert.NotNull(categories);
        Assert.NotEmpty(categories);
    }
}
