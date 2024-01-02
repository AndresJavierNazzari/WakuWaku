using FluentValidation;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Application.Validators;
public class CategoryValidator : AbstractValidator<CategoryForCreation> {
    public CategoryValidator() {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(50).WithMessage("The maximum length is 50 characters.");
        RuleFor(c => c.Description).NotEmpty().MaximumLength(200).WithMessage("The maximum length is 200 characters.");
    }
}

