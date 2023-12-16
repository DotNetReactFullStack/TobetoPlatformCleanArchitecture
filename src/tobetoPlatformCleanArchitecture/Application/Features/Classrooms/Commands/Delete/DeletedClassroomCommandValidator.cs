using FluentValidation;

namespace Application.Features.Classrooms.Commands.Delete;

public class DeleteClassroomCommandValidator : AbstractValidator<DeleteClassroomCommand>
{
    public DeleteClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}