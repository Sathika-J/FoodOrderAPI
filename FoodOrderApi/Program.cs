using FoodOrderApi.DataProvider;
using FoodOrderApi.Mappings;
using FoodOrderApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//adding food order api
builder.Services.AddFoodOrderApi();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddDbContext<FoodApiDbContext>(options =>
    options.UseSqlite("Data Source = foodorder.db"));

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

public static class FoodOrderApiDependencies
{
    public static void AddFoodOrderApi(this IServiceCollection services)
    {
        services.AddScoped<IDbProvider, FoodApiDbContext>();
        services.AddScoped<IDataProvider, DbDataProvider>();
    }
}