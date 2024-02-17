using FluentValidation;

namespace Application.Features.AccountCollegeMetadatas.Commands.Delete;

public class DeleteAccountCollegeMetadataCommandValidator : AbstractValidator<DeleteAccountCollegeMetadataCommand>
{
    public DeleteAccountCollegeMetadataCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}