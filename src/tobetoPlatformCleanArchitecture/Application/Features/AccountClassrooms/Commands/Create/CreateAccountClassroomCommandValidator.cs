using FluentValidation;

namespace Application.Features.AccountClassrooms.Commands.Create;

public class CreateAccountClassroomCommandValidator : AbstractValidator<CreateAccountClassroomCommand>
{
    public CreateAccountClassroomCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}