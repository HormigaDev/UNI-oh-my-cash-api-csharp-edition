using App.Application.DTOs;
using FluentValidation;
using System.Linq;

namespace App.Application.Validators;

public class AccountCreateValidator : AbstractValidator<AccountCreateDto>
{
    public AccountCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Tipo é obrigatório")
            .Must(IsValidType).WithMessage("Tipo inválido");
    }

    private static bool IsValidType(string type) =>
        new[] { "cash", "bank", "credit_card", "digital_wallet" }.Contains(type);
}

public class AccountUpdateValidator : AbstractValidator<AccountUpdateDto>
{
    public AccountUpdateValidator()
    {
        When(x => x.Name != null, () =>
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório"));

        _ = When(x => x.Type != null, () =>
            RuleFor(x => x.Type)
                .Must(IsValidType!).WithMessage("Tipo inválido"));

        When(x => x.Status != null, () =>
            RuleFor(x => x.Status)
                .Must(s => new[] { "active", "inactive", "deleted" }.Contains(s))
                .WithMessage("Status inválido"));
    }

    private static bool IsValidType(string type) =>
        new[] { "cash", "bank", "credit_card", "digital_wallet" }.Contains(type);
}
