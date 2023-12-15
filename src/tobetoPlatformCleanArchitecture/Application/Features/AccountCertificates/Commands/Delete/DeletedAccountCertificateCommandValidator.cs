using FluentValidation;

namespace Application.Features.AccountCertificates.Commands.Delete;

public class DeleteAccountCertificateCommandValidator : AbstractValidator<DeleteAccountCertificateCommand>
{
    public DeleteAccountCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}