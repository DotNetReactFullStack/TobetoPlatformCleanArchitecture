using FluentValidation;

namespace Application.Features.AccountCollageMetadatas.Commands.Delete;

public class DeleteAccountCollageMetadataCommandValidator : AbstractValidator<DeleteAccountCollageMetadataCommand>
{
    public DeleteAccountCollageMetadataCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}