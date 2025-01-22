using AutoMapper;
using QuizApi.Models.DTOs.Requests;
using QuizApi.Models.DTOs.Responses;
using QuizApi.Models.Entities;

namespace QuizApi.Infrastructure.Mappings;

public class QuizMappingProfile : Profile
{
    public QuizMappingProfile()
    {
        CreateMap<QuizSubmitRequestDTO, QuizResult>()
            .ForMember(dest => dest.Score, opt => opt.Ignore())
            .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<QuizQuestion, QuizQuestionResponseDTO>();
        CreateMap<QuizResult, QuizResultResponseDTO>();
        CreateMap<QuizResult, QuizSubmitResponseDTO>();
    }
}
