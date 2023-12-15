using FluentValidation;

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Update;

public class UpdateAccountForeignLanguageMetadataCommandValidator : AbstractValidator<UpdateAccountForeignLanguageMetadataCommand>
{
    public UpdateAccountForeignLanguageMetadataCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ForeignLanguageId).NotEmpty();
        RuleFor(c => c.ForeignLanguageLevelId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}