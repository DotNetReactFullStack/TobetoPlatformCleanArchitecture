using FluentValidation;

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Delete;

public class DeleteAccountForeignLanguageMetadataCommandValidator : AbstractValidator<DeleteAccountForeignLanguageMetadataCommand>
{
    public DeleteAccountForeignLanguageMetadataCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}