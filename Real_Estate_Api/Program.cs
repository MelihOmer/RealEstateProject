using Real_Estate_Api.Hubs;
using Real_Estate_Api.Models.DapperContext;
using Real_Estate_Api.Repositories.BottomGridRepositories;
using Real_Estate_Api.Repositories.CategoryRepositories;
using Real_Estate_Api.Repositories.ContactRepositories;
using Real_Estate_Api.Repositories.EmployeeRepositories;
using Real_Estate_Api.Repositories.PopularLocationRepositories;
using Real_Estate_Api.Repositories.ProductRepositoires;
using Real_Estate_Api.Repositories.ServiceRepositories;
using Real_Estate_Api.Repositories.StatisticRepositories;
using Real_Estate_Api.Repositories.TestimonialRepositories;
using Real_Estate_Api.Repositories.TodoRepositories;
using Real_Estate_Api.Repositories.WhoWeAreRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Registration
builder.Services.AddHttpClient();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddTransient<AppDbContext>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository,BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository,PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
