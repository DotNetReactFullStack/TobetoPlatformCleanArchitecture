using FluentValidation;

namespace Application.Features.LearningPaths.Commands.Update;

public class UpdateLearningPathCommandValidator : AbstractValidator<UpdateLearningPathCommand>
{
    public UpdateLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.StartingTime).NotEmpty();
        RuleFor(c => c.EndTime).NotEmpty();
    }
}