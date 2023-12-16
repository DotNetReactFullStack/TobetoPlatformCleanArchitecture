using FluentValidation;

namespace Application.Features.Exams.Commands.Delete;

public class DeleteExamCommandValidator : AbstractValidator<DeleteExamCommand>
{
    public DeleteExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}