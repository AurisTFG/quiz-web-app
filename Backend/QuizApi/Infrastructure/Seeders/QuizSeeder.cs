using QuizApi.Infrastructure.Constants;
using QuizApi.Infrastructure.DbContexts;

namespace QuizApi.Infrastructure.Seeders;

public class QuizSeeder(QuizDbContext context)
{
    private readonly QuizDbContext context = context;

    public async Task SeedAsync()
    {
        if (!context.QuizQuestions.Any())
            context.QuizQuestions.AddRange(QuizSeedData.DefaultQuestions);

        if (!context.QuizResults.Any())
            context.QuizResults.AddRange(QuizSeedData.DefaultResults);

        await context.SaveChangesAsync();
    }
}
