using Asp.Versioning;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;
using FluentValidation.AspNetCore;
using FluentValidation;

using WakuWakuAPI.Infraestructure.Data;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using WakuWakuAPI.Infraestructure.Repositories;
using WakuWakuAPI.Application.Services.Interfaces;
using WakuWakuAPI.Application.Services;
using WakuWakuAPI.Application.Validators;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Presentation.Middlewares;
using System.Reflection;

namespace WakuWakuAPI.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // ***********  BUILDER ************ //
            var builder = WebApplication.CreateBuilder(args);
            builder = ConfigureServicesAndMiddlewares(builder);


            // *********  PIPELINE ************ //
            var app = builder.Build();
            ConfigurePipeline(app);
        }


        public static WebApplicationBuilder ConfigureServicesAndMiddlewares(WebApplicationBuilder builder)
        {
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            // Add services to the container.
            builder.Services.AddControllers(configure =>
            {
                configure.ReturnHttpNotAcceptable = true;
                configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                //configure.Filters.Add(new AuthorizeFilter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ***********  GZIP COMPRESSION ************
            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            // ***********  API VERSIONING ************
            var apiVersioningBuilder = builder.Services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;

            });
            apiVersioningBuilder.AddApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            // ***********  EXCEPTIONS ************
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            // ***********  FLUENT VALIDATION ************
            builder.Services.AddFluentValidationAutoValidation();

            // ***********  DEPENDENCY INJECTION ************
            
            // Mapster configuration, this scans all custom configs
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton(config);

            // Persistance
            //builder.Services.AddSingleton<IInMemoryPersistenceService, InMemoryPersistanceService>();

            // Repositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IGoalRepository, GoalRepository>();

            // Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IGoalService, GoalService>();

            // Validators
            builder.Services.AddScoped<IValidator<GoalForCreation>, GoalValidator>();
            builder.Services.AddScoped<IValidator<CategoryForCreation>, CategoryValidator>();

            //  IMapper
            builder.Services.AddScoped<IMapper, ServiceMapper>();


            // ***********  HEALTHCHECK ************
            builder.Services.AddHealthChecks();

            // ***********  CORS ************
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // ***********  DBCONTEXT ************
            builder.Services.AddDbContext<WakuWakuContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("WakuWakuContext"));
            });

            return builder;
        }


        public static void ConfigurePipeline(WebApplication app)
        {
            app.UseResponseCompression();
            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler();
            app.UseRouting();
            //The call to UseCors must be placed after UseRouting, but before UseAuthorization
            app.UseCors();

            app.MapControllers();
            app.MapHealthChecks("/health");
            app.Run();
        }
    }
}
