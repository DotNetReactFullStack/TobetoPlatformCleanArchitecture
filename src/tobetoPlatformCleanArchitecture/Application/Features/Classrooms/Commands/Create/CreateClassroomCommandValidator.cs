using FluentValidation;

namespace Application.Features.Classrooms.Commands.Create;

public class CreateClassroomCommandValidator : AbstractValidator<CreateClassroomCommand>
{
    public CreateClassroomCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MaximumCapacity).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}