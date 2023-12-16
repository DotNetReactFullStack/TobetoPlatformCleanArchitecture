using FluentValidation;

namespace Application.Features.AccountClassrooms.Commands.Delete;

public class DeleteAccountClassroomCommandValidator : AbstractValidator<DeleteAccountClassroomCommand>
{
    public DeleteAccountClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}