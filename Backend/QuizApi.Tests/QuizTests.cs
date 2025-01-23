using QuizApi.Infrastructure.Constants;
using QuizApi.Models.Entities;
using QuizApi.Models.Enums;
using QuizApi.Services;

namespace QuizApi.Tests;

public class QuizTests
{
    private const int MaxScorePerQuestion = QuizSettings.MaxScorePerQuestion;

    [Fact]
    public void CalculateScore_RadioQuestion_CorrectAnswer_ReturnsScore()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 1,
                QuestionType = QuestionType.Radio,
                CorrectAnswers = ["A"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 1, [ "A" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(MaxScorePerQuestion, score);
    }

    [Fact]
    public void CalculateScore_RadioQuestion_WrongAnswer_ReturnsZero()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 1,
                QuestionType = QuestionType.Radio,
                CorrectAnswers = ["A"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 1, [ "B" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(0, score);
    }

    [Fact]
    public void CalculateScore_CheckboxQuestion_CorrectAnswers_ReturnsScore()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 2,
                QuestionType = QuestionType.Checkbox,
                CorrectAnswers = ["A", "B"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 2, [ "A", "B" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(MaxScorePerQuestion, score);
    }

    [Fact]
    public void CalculateScore_CheckboxQuestion_WrongAnswers_ReturnsZero()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 2,
                QuestionType = QuestionType.Checkbox,
                CorrectAnswers = ["A", "B"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 2, [ "C" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(0, score);
    }

    [Fact]
    public void CalculateScore_CheckboxQuestion_CorrectAndWrongAnswers_ReturnsZero()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 2,
                QuestionType = QuestionType.Checkbox,
                CorrectAnswers = ["A", "B"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 2, [ "A", "C" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(0, score);
    }

    [Fact]
    public void CalculateScore_TextboxQuestion_CorrectAnswer_ReturnsScore()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 3,
                QuestionType = QuestionType.Textbox,
                CorrectAnswers = ["answer"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 3, [ "answer" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(MaxScorePerQuestion, score);
    }

    [Fact]
    public void CalculateScore_TextboxQuestion_WrongAnswer_ReturnsZero()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 3,
                QuestionType = QuestionType.Textbox,
                CorrectAnswers = ["answer"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 3, [ "wrong answer" ] }
        };

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(0, score);
    }

    [Fact]
    public void CalculateScore_AnswersNotFoundInDictionary_SkipsQuestion()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 5,
                QuestionType = QuestionType.Radio,
                CorrectAnswers = ["A"]
            }
        };
        var answers = new Dictionary<int, string[]>();

        var score = QuizService.CalculateScore(questions, answers);

        Assert.Equal(0, score);
    }

    [Fact]
    public void CalculateScore_EmptyAnswers_ThrowsInvalidOperationException()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 4,
                QuestionType = QuestionType.Radio,
                CorrectAnswers = []
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 4, [ ] }
        };

        Assert.Throws<InvalidOperationException>(() => QuizService.CalculateScore(questions, answers));
    }

    [Fact]
    public void CalculateScore_UnsupportedQuestionType_ThrowsNotSupportedException()
    {
        var questions = new List<QuizQuestion>
        {
            new() {
                Id = 6,
                QuestionType = (QuestionType)999,
                CorrectAnswers = ["A"]
            }
        };
        var answers = new Dictionary<int, string[]>
        {
            { 6, [ "A" ] }
        };

        Assert.Throws<NotSupportedException>(() => QuizService.CalculateScore(questions, answers));
    }
}