using FluentValidation;

namespace Application.Features.Classrooms.Commands.Update;

public class UpdateClassroomCommandValidator : AbstractValidator<UpdateClassroomCommand>
{
    public UpdateClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MaximumCapacity).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}