using FluentValidation;

namespace WTR_Blazor.Models;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Imię jest wymagane")
            .MaximumLength(50).WithMessage("Imię nie może przekraczać 50 znaków");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Nazwisko jest wymagane")
            .MaximumLength(50).WithMessage("Nazwisko nie może przekraczać 50 znaków");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Nieprawidłowy format adresu e-mail");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Firma jest wymagana");
    }
}