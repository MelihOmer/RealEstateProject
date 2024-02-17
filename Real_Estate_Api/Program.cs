using Real_Estate_Api.Models.DapperContext;
using Real_Estate_Api.Repositories.CategoryRepositories;
using Real_Estate_Api.Repositories.ProductRepositoires;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Registration
builder.Services.AddTransient<AppDbContext>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
