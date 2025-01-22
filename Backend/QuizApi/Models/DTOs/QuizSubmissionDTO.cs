namespace QuizApi.Models.DTOs;

public class QuizSubmissionDTO
{
    public string Email { get; set; } = string.Empty;
    public Dictionary<int, string[]> Answers { get; set; } = [];
}
