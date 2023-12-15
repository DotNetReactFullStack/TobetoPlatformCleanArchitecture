using FluentValidation;

namespace Application.Features.Cities.Commands.Delete;

public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
{
    public DeleteCityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}