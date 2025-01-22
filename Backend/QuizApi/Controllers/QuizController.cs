using Microsoft.AspNetCore.Mvc;
using QuizApi.Models.DTOs.Requests;
using QuizApi.Services;

namespace QuizApi.Controllers;

[ApiController]
[Route("api/v1/quizzes")]
public class QuizController(IQuizService quizService) : ControllerBase
{
    private readonly IQuizService quizService = quizService;

    [HttpGet("questions")]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await quizService.GetAllQuestionsAsync();

        return Ok(questions);
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmitRequestDTO submission)
    {
        var result = await quizService.SubmitQuizAsync(submission);

        return Ok(result);
    }

    [HttpGet("highscores")]
    public async Task<IActionResult> GetHighScores()
    {
        var highScores = await quizService.GetHighScoresAsync();

        return Ok(highScores);
    }
}
