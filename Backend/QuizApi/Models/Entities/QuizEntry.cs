using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.Entities;

public class QuizEntry
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int Score { get; set; }
    public DateTime DateSubmitted { get; set; }
}
