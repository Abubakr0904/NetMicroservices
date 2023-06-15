using Microsoft.EntityFrameworkCore;
using PlatformService.Api.Attributes;
using PlatformService.Db.Data;
using PlatformService.DependecyInjector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseInMemoryDatabase("InMemoryPlatformsDatabase"));

builder.Services.InitializeDependencies();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidateModelAttribute)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await Seed.SeedData(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
