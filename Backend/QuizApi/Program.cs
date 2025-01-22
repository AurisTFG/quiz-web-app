using Microsoft.EntityFrameworkCore;
using QuizApi.Enums;
using QuizApi.Infrastructure.DbContexts;
using QuizApi.Models.Entities;
using QuizApi.Repositories;
using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuizDbContext>(options => options.UseInMemoryDatabase("QuizDB"));
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<QuizDbContext>();
    SeedDatabase(dbContext);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static void SeedDatabase(QuizDbContext dbContext)
{
    if (!dbContext.QuizQuestions.Any())
    {
        dbContext.QuizQuestions.AddRange(new List<QuizQuestion>
        {
            new() {
                Id = 1,
                Question = "What is 2 + 2?",
                QuestionType = QuestionType.Radio,
                Options = ["3", "4", "5"],
                CorrectAnswers = ["4"]
            },
            new() {
                Id = 2,
                Question = "Select the prime numbers.",
                QuestionType = QuestionType.Checkbox,
                Options = ["2", "3", "4", "5"],
                CorrectAnswers = ["2", "3", "5"]
            },
            new() {
                Id = 3,
                Question = "What is the capital of France?",
                QuestionType = QuestionType.Text,
                CorrectAnswers = ["Paris"]
            }
        });

        dbContext.SaveChanges();
    }
}