using QuizApi.Models.Enums;

namespace QuizApi.Models.DTOs.Responses;

public record QuizQuestionResponseDTO
(
    int Id,
    string Question,
    QuestionType QuestionType,
    string[] Options
);
