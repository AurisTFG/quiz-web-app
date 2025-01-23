using AutoMapper;
using QuizApi.Infrastructure.Constants;
using QuizApi.Models.DTOs.Requests;
using QuizApi.Models.DTOs.Responses;
using QuizApi.Models.Entities;
using QuizApi.Models.Enums;
using QuizApi.Repositories;

namespace QuizApi.Services;

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
        var highScores = await quizRepository.GetTopHighScoresAsync(QuizSettings.MaxQuestionId);

        return [.. highScores.Select(mapper.Map<QuizResultResponseDTO>)];
    }

    public static int CalculateScore(List<QuizQuestion> questions, Dictionary<int, string[]> answers)
    {
        int totalScore = 0;
        int scorePerQuestion = QuizSettings.MaxScorePerQuestion;

        foreach (var question in questions)
        {
            if (!answers.TryGetValue(question.Id, out var providedAnswers))
                continue;

            if (question.CorrectAnswers.Length == 0 || providedAnswers.Length == 0)
                throw new InvalidOperationException("This should never happen");

            switch (question.QuestionType)
            {
                case QuestionType.Radio:
                    if (question.CorrectAnswers[0] == providedAnswers[0])
                        totalScore += scorePerQuestion;

                    break;
                case QuestionType.Checkbox:
                    int goodAnswerCount = question.CorrectAnswers.Length;
                    int correctCount = providedAnswers.Intersect(question.CorrectAnswers).Count();
                    int wrongCount = providedAnswers.Length - correctCount;

                    int score = (int)Math.Ceiling(((double)scorePerQuestion / goodAnswerCount * correctCount) - (scorePerQuestion / goodAnswerCount * wrongCount));

                    if (score > 0)
                        totalScore += score;

                    break;
                case QuestionType.Textbox:
                    if (string.Equals(question.CorrectAnswers[0], providedAnswers[0], StringComparison.OrdinalIgnoreCase))
                        totalScore += scorePerQuestion;

                    break;
                default:
                    throw new NotSupportedException($"Question type {question.QuestionType} is not supported.");
            }
        }

        return totalScore;
    }
}
