using QuizApi.Models.Entities;
using QuizApi.Models.Enums;

namespace QuizApi.Infrastructure.Constants;

public static class QuizSeedData
{
    public static readonly List<QuizQuestion> DefaultQuestions = [
        new() { // 1
            Question = "What is 2 + 2?",
            QuestionType = QuestionType.Radio,
            Options = ["3", "4", "5"],
            CorrectAnswers = ["4"]
        },
        new() { // 2
            Question = "Which planet is known as the Red Planet?",
            QuestionType = QuestionType.Radio,
            Options = ["Earth", "Mars", "Venus"],
            CorrectAnswers = ["Mars"]
        },
        new() { // 3
            Question = "What is the boiling point of water at sea level in degrees Celsius?",
            QuestionType = QuestionType.Radio,
            Options = ["90", "100", "110"],
            CorrectAnswers = ["100"]
        },
        new() { // 4
            Question = "What is the largest mammal on Earth?",
            QuestionType = QuestionType.Radio,
            Options = ["Elephant", "Blue Whale", "Giraffe"],
            CorrectAnswers = ["Blue Whale"]
        },
        new() { // 5
            Question = "Select the prime numbers.",
            QuestionType = QuestionType.Checkbox,
            Options = ["2", "3", "4", "5"],
            CorrectAnswers = ["2", "3", "5"]
        },
        new() { // 6
            Question = "Select all even numbers.",
            QuestionType = QuestionType.Checkbox,
            Options = ["1", "2", "3", "4", "5"],
            CorrectAnswers = ["2", "4"]
        },
        new() { // 7
            Question = "Select all continents in the world.",
            QuestionType = QuestionType.Checkbox,
            Options = ["Asia", "Europe", "Africa", "Pacific"],
            CorrectAnswers = ["Asia", "Europe", "Africa"]
        },
        new() { // 8
            Question = "Select all colors in the rainbow.",
            QuestionType = QuestionType.Checkbox,
            Options = ["Red", "Green", "Black", "Yellow"],
            CorrectAnswers = ["Red", "Green", "Yellow"]
        },
        new() { // 9
            Question = "What is the capital of France?",
            QuestionType = QuestionType.Textbox,
            CorrectAnswers = ["Paris"]
        },
        new() { // 10
            Question = "What is the square root of 64?",
            QuestionType = QuestionType.Textbox,
            CorrectAnswers = ["8"]
        },
    ];

    public static readonly List<QuizResult> DefaultResults = [
        new()
        {
            Email = "alice@example.com",
            Score = 123,
            SubmittedAt = DateTime.UtcNow.AddDays(-1)
        },
        new()
        {
            Email = "bob@example.com",
            Score = 89,
            SubmittedAt = DateTime.UtcNow.AddDays(-2)
        },
        new()
        {
            Email = "charlie@example.com",
            Score = 200,
            SubmittedAt = DateTime.UtcNow.AddDays(-3)
        },
        new()
        {
            Email = "diana@example.com",
            Score = 0,
            SubmittedAt = DateTime.UtcNow.AddDays(-4)
        },
        new()
        {
            Email = "edward@example.com",
            Score = 891,
            SubmittedAt = DateTime.UtcNow.AddDays(-5)
        },
        new()
        {
            Email = "fiona@example.com",
            Score = 0,
            SubmittedAt = DateTime.UtcNow.AddDays(-6)
        },
        new()
        {
            Email = "george@example.com",
            Score = 80,
            SubmittedAt = DateTime.UtcNow.AddDays(-7)
        },
        new()
        {
            Email = "hannah@example.com",
            Score = 0,
            SubmittedAt = DateTime.UtcNow.AddDays(-8)
        },
        new()
        {
            Email = "ian@example.com",
            Score = 789,
            SubmittedAt = DateTime.UtcNow.AddDays(-9)
        },
        new()
        {
            Email = "julia@example.com",
            Score = 1000,
            SubmittedAt = DateTime.UtcNow.AddDays(-10)
        }
    ];
}
