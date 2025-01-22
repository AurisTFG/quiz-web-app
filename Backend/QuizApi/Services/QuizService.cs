using AutoMapper;
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

            if (question.CorrectAnswers.Length == 0 || providedAnswers.Length == 0)
                continue;

            switch (question.QuestionType)
            {
                case QuestionType.Radio:
                    if (question.CorrectAnswers[0] == providedAnswers[0])
                        totalScore += 100;

                    break;
                case QuestionType.Checkbox:
                    int goodAnswerCount = question.CorrectAnswers.Length;
                    int correctCount = providedAnswers.Intersect(question.CorrectAnswers).Count();
                    int wrongCount = providedAnswers.Length - correctCount;

                    int score = (int)Math.Ceiling((100.0 / goodAnswerCount * correctCount) - (100.0 / goodAnswerCount * wrongCount));

                    if (score > 0)
                        totalScore += score;

                    break;
                case QuestionType.Text:
                    if (string.Equals(question.CorrectAnswers[0], providedAnswers[0], StringComparison.OrdinalIgnoreCase))
                        totalScore += 100;

                    break;
            }
        }

        return totalScore;
    }
}
