using FluentValidation;

namespace Application.Features.ClassroomExams.Commands.Create;

public class CreateClassroomExamCommandValidator : AbstractValidator<CreateClassroomExamCommand>
{
    public CreateClassroomExamCommandValidator()
    {
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}