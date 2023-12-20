using FluentValidation;

namespace Application.Features.AccountCourses.Commands.Create;

public class CreateAccountCourseCommandValidator : AbstractValidator<CreateAccountCourseCommand>
{
    public CreateAccountCourseCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}