using FluentValidation;

namespace Application.Features.AccountCertificates.Commands.Create;

public class CreateAccountCertificateCommandValidator : AbstractValidator<CreateAccountCertificateCommand>
{
    public CreateAccountCertificateCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.CertificateId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}