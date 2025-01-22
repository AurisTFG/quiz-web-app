using QuizApi.Models.Entities;

namespace QuizApi.Repositories;

public interface IQuizRepository
{
    Task<List<QuizQuestion>> GetAllQuestionsAsync();
    Task SaveQuizResultAsync(QuizResult entry);
    Task<List<QuizResult>> GetTopHighScoresAsync(int count);
}
