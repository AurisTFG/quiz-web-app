using FluentValidation;
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
                answer.Must(pair => pair.Key is > 0 and <= 10)
                      .WithMessage("The question ID must be between 1 and 10.");

                answer.Cascade(CascadeMode.Stop)
                      .Must(pair => pair.Value != null).WithMessage("The answer must be provided.")
                      .Must(pair => pair.Value.Length != 0).WithMessage("The answer array must not be empty.")
                      .Must(pair => !string.IsNullOrEmpty(pair.Value[0])).WithMessage("The answer string must not be empty.");
            });
    }
}
