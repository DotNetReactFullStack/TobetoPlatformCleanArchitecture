using FluentValidation;

namespace Application.Features.Districts.Commands.Delete;

public class DeleteDistrictCommandValidator : AbstractValidator<DeleteDistrictCommand>
{
    public DeleteDistrictCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}