using FluentValidation;

namespace Application.Features.AccountClassrooms.Commands.Update;

public class UpdateAccountClassroomCommandValidator : AbstractValidator<UpdateAccountClassroomCommand>
{
    public UpdateAccountClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}