using FluentValidation;

namespace WTR_Blazor.Models;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nazwa firmy jest wymagana")
            .MaximumLength(100).WithMessage("Nazwa firmy nie może przekraczać 100 znaków");
        RuleFor(x => x.LogoData).NotEmpty().WithMessage("Logo jest wymagane");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<Company>.CreateWithOptions((Company)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
