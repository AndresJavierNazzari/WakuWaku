using FluentValidation;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Application.Validators;
public class GoalValidator : AbstractValidator<GoalForCreation> {
    public GoalValidator() {
        RuleFor(g => g.Description).NotEmpty().MaximumLength(200).WithMessage("The maximum length is 200 characters.");
        RuleFor(g => g.Status).NotEmpty().MaximumLength(50).WithMessage("The maximum length is 50 characters.");
        RuleFor(g => g.DateOfCreation).NotEmpty().Must(BeToday).WithMessage("The creation date must be today.");
        RuleFor(g => g.Deadline).Must(BeAValidDeadline).WithMessage("The deadline must be between today and one year from today.");
    }

    private bool BeAValidDeadline(DateTime deadline) {
        DateTime today = DateTime.Today;
        DateTime oneYearFromToday = today.AddYears(1);
        return deadline >= today && deadline <= oneYearFromToday;
    }

    private bool BeToday(DateTime creationDate) {
        return creationDate.Date == DateTime.Today;
    }
}

