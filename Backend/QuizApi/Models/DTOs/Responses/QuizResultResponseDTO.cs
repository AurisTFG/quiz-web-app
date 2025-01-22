namespace QuizApi.Models.DTOs.Responses;

public record QuizResultResponseDTO
(
    string Email,
    int Score,
    DateTime SubmittedAt
);
