using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.DbContexts;
using QuizApi.Models.Entities;

namespace QuizApi.Repositories;

public class QuizRepository(QuizDbContext context) : IQuizRepository
{
    private readonly QuizDbContext context = context;

    public async Task<List<QuizQuestion>> GetAllQuestionsAsync()
    {
        return await context.QuizQuestions.ToListAsync();
    }

    public async Task SaveQuizResultAsync(QuizResult entry)
    {
        context.QuizResults.Add(entry);

        await context.SaveChangesAsync();
    }

    public async Task<List<QuizResult>> GetTopHighScoresAsync(int count)
    {
        return await context.QuizResults
            .OrderByDescending(e => e.Score)
            .ThenBy(e => e.SubmittedAt)
            .Take(count)
            .ToListAsync();
    }
}
