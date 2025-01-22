using QuizApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.Entities;

public class QuizQuestion
{
    [Key]
    public int Id { get; set; }
    public string Question { get; set; } = "";
    public QuestionType QuestionType { get; set; }
    public string[] Options { get; set; } = [];
    public string[] CorrectAnswers { get; set; } = [];
}
