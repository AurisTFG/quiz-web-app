using Microsoft.AspNetCore.Mvc;
using QuizApi.Infrastructure.Constants;
using QuizApi.Models.DTOs.Requests;
using QuizApi.Services;

namespace QuizApi.Controllers;

[ApiController]
[Route(Routes.BaseQuizRoute)]
public class QuizController(IQuizService quizService) : ControllerBase
{
    private readonly IQuizService quizService = quizService;

    [HttpGet(Routes.GetQuizQuestions)]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await quizService.GetAllQuestionsAsync();

        return Ok(questions);
    }

    [HttpGet(Routes.GetQuizHighScores)]
    public async Task<IActionResult> GetHighScores()
    {
        var highScores = await quizService.GetHighScoresAsync();

        return Ok(highScores);
    }

    [HttpPost(Routes.PostQuizAnswers)]
    public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmitRequestDTO submission)
    {
        var result = await quizService.SubmitQuizAsync(submission);

        return Ok(result);
    }
}
