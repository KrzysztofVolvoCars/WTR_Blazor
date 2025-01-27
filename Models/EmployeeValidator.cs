using FluentValidation;

namespace WTR_Blazor.Models;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Company is required");
    }
}