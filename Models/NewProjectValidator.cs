using FluentValidation;

namespace WTR_Blazor.Models;

public class NewProjectValidator : AbstractValidator<NewProject>
{
    public NewProjectValidator()
    {
        RuleFor(x => x.ECNumber)
            .NotEmpty().WithMessage("EC Number is required")
            .MaximumLength(100).WithMessage("EC Number cannot exceed 100 characters");

        RuleFor(x => x.ProjectName)
            .NotEmpty().WithMessage("Project name is required")
            .MaximumLength(200).WithMessage("Project name cannot exceed 200 characters");

        RuleFor(x => x.PowerBI_URL)
    .MaximumLength(500).WithMessage("PowerBI URL cannot exceed 500 characters")
    .Must(uri => string.IsNullOrEmpty(uri) || Uri.TryCreate(uri, UriKind.Absolute, out _))
    .WithMessage("PowerBI URL must be a valid URL");

        RuleFor(x => x.EngineerId)
            .NotEmpty().WithMessage("Engineer is required");

        RuleFor(x => x.SupplierId)
            .NotEmpty().WithMessage("Supplier is required");

        RuleFor(x => x.RMResponsibleId)
            .NotEmpty().WithMessage("R&M Responsible is required");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start Date is required");

        RuleFor(x => x.Installation)
            .NotEmpty().WithMessage("Installation date is required")
            .GreaterThan(x => x.StartDate)
            .WithMessage("Installation date must be after Start Date");

        RuleFor(x => x.SOP)
            .NotEmpty().WithMessage("SOP date is required")
            .GreaterThan(x => x.Installation)
            .WithMessage("SOP date must be after Installation date");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<NewProject>.CreateWithOptions((NewProject)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

