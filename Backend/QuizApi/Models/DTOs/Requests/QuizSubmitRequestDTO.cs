namespace QuizApi.Models.DTOs.Requests;

public record QuizSubmitRequestDTO
(
    string Email,
    Dictionary<int, string[]> Answers
);
