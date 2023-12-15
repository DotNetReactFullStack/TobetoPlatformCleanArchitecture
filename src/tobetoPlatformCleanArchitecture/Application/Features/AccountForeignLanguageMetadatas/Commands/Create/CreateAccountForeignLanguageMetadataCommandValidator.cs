using FluentValidation;

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Create;

public class CreateAccountForeignLanguageMetadataCommandValidator : AbstractValidator<CreateAccountForeignLanguageMetadataCommand>
{
    public CreateAccountForeignLanguageMetadataCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ForeignLanguageId).NotEmpty();
        RuleFor(c => c.ForeignLanguageLevelId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}