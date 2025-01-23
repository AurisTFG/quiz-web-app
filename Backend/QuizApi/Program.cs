using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.DbContexts;
using QuizApi.Infrastructure.Seeders;
using QuizApi.Repositories;
using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());
});

builder.Services.AddDbContext<QuizDbContext>(options => options.UseInMemoryDatabase("QuizDB"));

builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<DatabaseSeeder>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
