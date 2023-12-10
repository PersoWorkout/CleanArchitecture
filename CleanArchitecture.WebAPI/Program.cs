using CleanArchitecture.Application.Repository;
using CleanArchitecture.Application.Service;
using CleanArchitecture.Infrastructure.Business;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("CatalogConnectionString")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductsBusiness>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoriesRepository, CategoriesBusiness>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CatalogDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
