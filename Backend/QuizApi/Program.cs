using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.DbContexts;
using QuizApi.Repositories;
using QuizApi.Seeders;
using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuizDbContext>(options => options.UseInMemoryDatabase("QuizDB"));
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<DatabaseSeeder>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
