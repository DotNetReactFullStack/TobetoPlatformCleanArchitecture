using FluentValidation;

namespace Application.Features.AccountCertificates.Commands.Update;

public class UpdateAccountCertificateCommandValidator : AbstractValidator<UpdateAccountCertificateCommand>
{
    public UpdateAccountCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.CertificateId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}