using App.Application.DTOs;
using FluentValidation;
using System.Linq;

namespace App.Application.Validators;

public class TransactionCreateValidator : AbstractValidator<TransactionCreateDto>
{
    public TransactionCreateValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Tipo é obrigatório")
            .Must(IsValidType).WithMessage("Tipo inválido");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Valor deve ser maior que zero");

        RuleFor(x => x.AccountId)
            .GreaterThan(0).WithMessage("AccountId deve ser válido");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId deve ser válido");
    }

    private static bool IsValidType(string type) =>
        new[] { "income", "expense" }.Contains(type);
}

public class TransactionUpdateValidator : AbstractValidator<TransactionUpdateDto>
{
    public TransactionUpdateValidator()
    {
        When(x => x.Type != null, () =>
            RuleFor(x => x.Type)
                .Must(IsValidType!).WithMessage("Tipo inválido"));

        When(x => x.Amount != null, () =>
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero"));

        When(x => x.AccountId != null, () =>
            RuleFor(x => x.AccountId)
                .GreaterThan(0).WithMessage("AccountId deve ser válido"));

        When(x => x.CategoryId != null, () =>
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId deve ser válido"));
    }

    private static bool IsValidType(string type) =>
        new[] { "income", "expense" }.Contains(type);
}
