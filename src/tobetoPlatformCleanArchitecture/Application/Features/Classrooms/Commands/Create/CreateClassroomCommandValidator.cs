using FluentValidation;

namespace Application.Features.Classrooms.Commands.Create;

public class CreateClassroomCommandValidator : AbstractValidator<CreateClassroomCommand>
{
    public CreateClassroomCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MaximumCapacity).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();

        RuleFor(c => c.Name).MaximumLength(50);
        RuleFor(c => (int)c.MaximumCapacity).GreaterThanOrEqualTo(0);
        RuleFor(c => (int)c.MaximumCapacity).LessThanOrEqualTo(250);
    }
}