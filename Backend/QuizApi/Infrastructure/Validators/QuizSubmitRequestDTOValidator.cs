using FluentValidation;
using QuizApi.Infrastructure.Constants;
using QuizApi.Models.DTOs.Requests;

namespace QuizApi.Infrastructure.Validators;

public class QuizSubmitRequestDTOValidator : AbstractValidator<QuizSubmitRequestDTO>
{
    public QuizSubmitRequestDTOValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("The Email field is required.")
            .EmailAddress().WithMessage("Please provide a valid email address.");

        RuleFor(x => x.Answers)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("The Answers field is required.")
            .Must(answers => answers.Count > 0).WithMessage("At least one answer must be provided.")
            .ForEach(answer =>
            {
                int minCount = QuizSettings.MinQuestionId;
                int maxCount = QuizSettings.MaxQuestionId;

                answer.Must(pair => pair.Key >= minCount && pair.Key <= maxCount)
                      .WithMessage($"The question ID must be between {minCount} and {maxCount}.");

                answer.Cascade(CascadeMode.Stop)
                      .Must(pair => pair.Value != null).WithMessage("The answer must be provided.")
                      .Must(pair => pair.Value.Length != 0).WithMessage("The answer array must not be empty.")
                      .Must(pair => !string.IsNullOrEmpty(pair.Value[0])).WithMessage("The answer string must not be empty.");
            });
    }
}
