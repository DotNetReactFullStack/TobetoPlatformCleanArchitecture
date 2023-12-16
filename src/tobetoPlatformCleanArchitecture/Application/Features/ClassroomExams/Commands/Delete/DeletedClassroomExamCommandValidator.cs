using FluentValidation;

namespace Application.Features.ClassroomExams.Commands.Delete;

public class DeleteClassroomExamCommandValidator : AbstractValidator<DeleteClassroomExamCommand>
{
    public DeleteClassroomExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}