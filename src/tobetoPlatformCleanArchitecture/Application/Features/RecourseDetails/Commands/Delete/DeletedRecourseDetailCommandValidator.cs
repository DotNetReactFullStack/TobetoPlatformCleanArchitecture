using FluentValidation;

namespace Application.Features.RecourseDetails.Commands.Delete;

public class DeleteRecourseDetailCommandValidator : AbstractValidator<DeleteRecourseDetailCommand>
{
    public DeleteRecourseDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}