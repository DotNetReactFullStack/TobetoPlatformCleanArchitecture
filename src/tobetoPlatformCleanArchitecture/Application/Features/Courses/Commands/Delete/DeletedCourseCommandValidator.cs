using FluentValidation;

namespace Application.Features.Courses.Commands.Delete;

public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
{
    public DeleteCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}