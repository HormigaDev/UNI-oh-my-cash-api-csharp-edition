using App.Application.DTOs;
using FluentValidation;
using System.Linq;

namespace App.Application.Validators;

public class BudgetCreateValidator : AbstractValidator<BudgetCreateDto>
{
    public BudgetCreateValidator()
    {
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId deve ser válido");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Valor deve ser maior que zero");

        RuleFor(x => x.Period)
            .NotEmpty().WithMessage("Período é obrigatório")
            .Must(IsValidPeriod).WithMessage("Período inválido");
    }

    private static bool IsValidPeriod(string period) =>
        new[] { "monthly", "weekly", "yearly" }.Contains(period);
}

public class BudgetUpdateValidator : AbstractValidator<BudgetUpdateDto>
{
    public BudgetUpdateValidator()
    {
        When(x => x.CategoryId != null, () =>
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId deve ser válido"));

        When(x => x.Amount != null, () =>
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero"));

        When(x => x.Period != null, () =>
            RuleFor(x => x.Period)
                .Must(IsValidPeriod!).WithMessage("Período inválido"));
    }

    private static bool IsValidPeriod(string period) =>
        new[] { "monthly", "weekly", "yearly" }.Contains(period);
}
