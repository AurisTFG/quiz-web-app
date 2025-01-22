using AutoMapper;
using QuizApi.Enums;
using QuizApi.Models.DTOs.Requests;
using QuizApi.Models.DTOs.Responses;
using QuizApi.Models.Entities;
using QuizApi.Repositories;

namespace QuizApi.Services;

public interface IQuizService
{
    Task<List<QuizQuestionResponseDTO>> GetAllQuestionsAsync();
    Task<QuizSubmitResponseDTO> SubmitQuizAsync(QuizSubmitRequestDTO submission);
    Task<List<QuizResultResponseDTO>> GetHighScoresAsync();
}

public class QuizService(IQuizRepository quizRepository, IMapper mapper) : IQuizService
{
    private readonly IQuizRepository quizRepository = quizRepository;
    private readonly IMapper mapper = mapper;

    public async Task<List<QuizQuestionResponseDTO>> GetAllQuestionsAsync()
    {
        var questions = await quizRepository.GetAllQuestionsAsync();

        return [.. questions.Select(mapper.Map<QuizQuestionResponseDTO>)];
    }

    public async Task<QuizSubmitResponseDTO> SubmitQuizAsync(QuizSubmitRequestDTO submission)
    {
        var questions = await quizRepository.GetAllQuestionsAsync();

        var quizResult = mapper.Map<QuizResult>(submission);
        quizResult.Score = CalculateScore(questions, submission.Answers);

        await quizRepository.SaveQuizResultAsync(quizResult);

        return mapper.Map<QuizSubmitResponseDTO>(quizResult);
    }

    public async Task<List<QuizResultResponseDTO>> GetHighScoresAsync()
    {
        var highScores = await quizRepository.GetTopHighScoresAsync(10);

        return [.. highScores.Select(mapper.Map<QuizResultResponseDTO>)];
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
