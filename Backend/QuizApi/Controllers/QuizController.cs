using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Enums;
using QuizApi.Infrastructure.DbContexts;
using QuizApi.Models.DTOs;
using QuizApi.Models.Entities;

namespace QuizApi.Controllers;

[ApiController]
[Route("api/v1/quizzes")]
public class QuizController : ControllerBase
{
    private readonly QuizDbContext _context;

    public QuizController(QuizDbContext context)
    {
        _context = context;
    }

    [HttpGet("questions")]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await _context.QuizQuestions.ToListAsync();
        return Ok(questions);
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitQuiz([FromBody] QuizSubmissionDTO submission)
    {
        if (string.IsNullOrEmpty(submission.Email) || submission.Answers == null)
            return BadRequest("Invalid submission data");

        var questions = await _context.QuizQuestions.ToListAsync();
        int score = CalculateScore(questions, submission.Answers);

        var entry = new QuizEntry
        {
            Email = submission.Email,
            Score = score,
            DateSubmitted = DateTime.UtcNow
        };

        _context.QuizEntries.Add(entry);
        await _context.SaveChangesAsync();

        return Ok(new { score });
    }

    [HttpGet("highscores")]
    public async Task<IActionResult> GetHighScores()
    {
        var highScores = await _context.QuizEntries
            .OrderByDescending(e => e.Score)
            .ThenBy(e => e.DateSubmitted)
            .Take(10)
            .ToListAsync();

        return Ok(highScores);
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
