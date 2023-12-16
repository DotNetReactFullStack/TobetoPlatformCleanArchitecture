using FluentValidation;

namespace Application.Features.ClassroomExams.Commands.Update;

public class UpdateClassroomExamCommandValidator : AbstractValidator<UpdateClassroomExamCommand>
{
    public UpdateClassroomExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}