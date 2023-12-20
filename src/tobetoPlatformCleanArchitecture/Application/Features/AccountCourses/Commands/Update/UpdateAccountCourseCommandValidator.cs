using FluentValidation;

namespace Application.Features.AccountCourses.Commands.Update;

public class UpdateAccountCourseCommandValidator : AbstractValidator<UpdateAccountCourseCommand>
{
    public UpdateAccountCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}