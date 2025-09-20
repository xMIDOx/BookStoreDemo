using BookStore.API.Middleware;
using BookStore.Application.Interfaces;
using BookStore.Application.IRepositories;
using BookStore.Application.IServices;
using BookStore.Application.Mappings;
using BookStore.Application.Services;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularClient", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
    services.AddControllers();

    services.AddOpenApi();
    services.AddSwaggerGen();

    services.AddDbContext<BookStoreDBContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

    services.AddAutoMapper(typeof(MappingProfile));

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllBooksQuery).Assembly));

    services.AddScoped<IBookService, BookService>();
    services.AddScoped<IAuthorService, AuthorService>();

    services.AddScoped<IBookRepository, BookRepository>();
    services.AddScoped<IAuthorRepository, AuthoryRepository>();

    services.AddScoped<IDiscountStrategy, SeasonalDiscountStrategy>();

    services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "https://demo.duendesoftware.com";
            options.TokenValidationParameters.ValidateAudience = false;
        });

    services.AddAuthorization();
}

void ConfigureMiddleware(WebApplication app)
{
    app.UseCors("AllowAngularClient");

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API V1");
            c.RoutePrefix = string.Empty;
        });
    }

    app.MapControllers();
}
