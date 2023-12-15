using FluentValidation;

namespace Application.Features.Colleges.Commands.Delete;

public class DeleteCollegeCommandValidator : AbstractValidator<DeleteCollegeCommand>
{
    public DeleteCollegeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}