using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.Entities;

public class QuizResult
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = "";
    public int Score { get; set; }
    public DateTime SubmittedAt { get; set; }
}
