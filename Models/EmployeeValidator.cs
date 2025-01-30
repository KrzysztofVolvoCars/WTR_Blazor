using FluentValidation;

namespace WTR_Blazor.Models;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid email format");

 

        // Warunkowa walidacja CompanyId: wymagane tylko dla pracowników zewnętrznych
        RuleFor(x => x.CompanyId)
            .NotEmpty()
            .When(x => !x.IsInternal)
            .WithMessage("Company is required for external employees");

        RuleFor(x => x.CompanyId)
            .Empty()
            .When(x => x.IsInternal)
            .WithMessage("Internal employees should not be assigned to a company");
    }


    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<Employee>.CreateWithOptions((Employee)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };

}