using QuizApi.Infrastructure.DbContexts;
using QuizApi.Infrastructure.Seeders;

namespace QuizApi.Infrastructure.Seeders;

public class DatabaseSeeder(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task SeedAsync()
    {
        using var scope = serviceProvider.CreateScope();
        var quizContext = scope.ServiceProvider.GetRequiredService<QuizDbContext>();

        var quizSeeder = new QuizSeeder(quizContext);
        await quizSeeder.SeedAsync();
    }
}
