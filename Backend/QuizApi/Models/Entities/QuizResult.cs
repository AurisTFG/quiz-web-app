using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.Entities;

public class QuizResult
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = "";
    public int Score { get; set; }
    public DateTime SubmittedAt { get; set; }
}
