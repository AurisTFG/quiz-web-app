using QuizApi.Models.DTOs.Requests;
using QuizApi.Models.DTOs.Responses;

namespace QuizApi.Services;

public interface IQuizService
{
    Task<List<QuizQuestionResponseDTO>> GetAllQuestionsAsync();
    Task<QuizSubmitResponseDTO> SubmitQuizAsync(QuizSubmitRequestDTO submission);
    Task<List<QuizResultResponseDTO>> GetHighScoresAsync();
}
