using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.DbContexts;
using QuizApi.Models.Entities;

namespace QuizApi.Repositories;

public interface IQuizRepository
{
    Task<List<QuizQuestion>> GetAllQuestionsAsync();
    Task SaveQuizEntryAsync(QuizEntry entry);
    Task<List<QuizEntry>> GetTopHighScoresAsync(int count);
}

public class QuizRepository(QuizDbContext context) : IQuizRepository
{
    private readonly QuizDbContext context = context;

    public async Task<List<QuizQuestion>> GetAllQuestionsAsync()
    {
        return await context.QuizQuestions.ToListAsync();
    }

    public async Task SaveQuizEntryAsync(QuizEntry entry)
    {
        context.QuizEntries.Add(entry);

        await context.SaveChangesAsync();
    }

    public async Task<List<QuizEntry>> GetTopHighScoresAsync(int count)
    {
        return await context.QuizEntries
            .OrderByDescending(e => e.Score)
            .ThenBy(e => e.DateSubmitted)
            .Take(count)
            .ToListAsync();
    }
}