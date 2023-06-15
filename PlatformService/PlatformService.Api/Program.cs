using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService.Api.Attributes;
using PlatformService.Db.Data;
using PlatformService.DependecyInjector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.InitializeDependencies();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidateModelAttribute)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Platform Service API", Version = "v1" });
});

var app = builder.Build();

await Seed.SeedData(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform Service API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
