using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.DTOs.Requests;

public class QuizSubmitRequestDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public Dictionary<int, string[]> Answers { get; set; } = [];
}