using QuizApi.Enums;
using QuizApi.Models.DTOs;
using QuizApi.Models.Entities;
using QuizApi.Repositories;

namespace QuizApi.Services;

public interface IQuizService
{
    Task<List<QuizQuestion>> GetAllQuestionsAsync();
    Task<object> SubmitQuizAsync(QuizSubmissionDTO submission);
    Task<List<QuizEntry>> GetHighScoresAsync();
}

public class QuizService(IQuizRepository quizRepository) : IQuizService
{
    private readonly IQuizRepository quizRepository = quizRepository;

    public async Task<List<QuizQuestion>> GetAllQuestionsAsync()
    {
        return await quizRepository.GetAllQuestionsAsync();
    }

    public async Task<object> SubmitQuizAsync(QuizSubmissionDTO submission)
    {
        var questions = await quizRepository.GetAllQuestionsAsync();
        int score = CalculateScore(questions, submission.Answers);

        var entry = new QuizEntry
        {
            Email = submission.Email,
            Score = score,
            DateSubmitted = DateTime.UtcNow
        };

        await quizRepository.SaveQuizEntryAsync(entry);

        return new { score };
    }

    public async Task<List<QuizEntry>> GetHighScoresAsync()
    {
        return await quizRepository.GetTopHighScoresAsync(10);
    }

    private static int CalculateScore(List<QuizQuestion> questions, Dictionary<int, string[]> answers)
    {
        int totalScore = 0;

        foreach (var question in questions)
        {
            if (!answers.TryGetValue(question.Id, out var providedAnswers))
                continue;

            switch (question.QuestionType)
            {
                case QuestionType.Radio:
                case QuestionType.Text:
                    if (providedAnswers.Length == 1 && question.CorrectAnswers.Contains(providedAnswers[0], StringComparer.OrdinalIgnoreCase))
                    {
                        totalScore += 100;
                    }
                    break;

                case QuestionType.Checkbox:
                    int correctCount = question.CorrectAnswers.Length;
                    int matchedCount = providedAnswers.Intersect(question.CorrectAnswers, StringComparer.OrdinalIgnoreCase).Count();
                    totalScore += (int)Math.Ceiling(100.0 / correctCount * matchedCount);
                    break;
            }
        }

        return totalScore;
    }
}
