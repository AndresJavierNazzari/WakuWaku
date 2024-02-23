using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Testcontainers.PostgreSql;

using WakuWakuAPI.Infraestructure.Data;
using WakuWakuAPI.Presentation;


namespace WakuWakuAPI.Integration.Tests;

public class WakuWakuApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer;

    public WakuWakuApiFactory()
    {
        _postgreSqlContainer = new PostgreSqlBuilder()
            .WithDatabase("WakuWakuApi")
            .WithUsername("test")
            .WithPassword("test")
            .WithCleanUp(true)
            .WithImage("postgres:latest").Build();
    }

    public async Task InitializeAsync()
    {
        if(_postgreSqlContainer is not null)
        {
            await _postgreSqlContainer.StartAsync();
        }
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {

            var descriptorType = typeof(DbContextOptions<WakuWakuContext>);
            var descriptorPostgres = services.SingleOrDefault(sd => sd.ServiceType == descriptorType);


            if(descriptorPostgres is not null)
            {
                services.Remove(descriptorPostgres);
            }

            Console.WriteLine("From testing " + _postgreSqlContainer!.GetConnectionString());

            services.AddDbContext<WakuWakuContext>(options =>
            {
                options
                    .UseNpgsql(_postgreSqlContainer!.GetConnectionString())
                    .EnableSensitiveDataLogging();
            });

            // Aplicar migraciones
            using(var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WakuWakuContext>();
                dbContext.Database.Migrate();
            }

        });
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _postgreSqlContainer!.DisposeAsync();
    }
}
