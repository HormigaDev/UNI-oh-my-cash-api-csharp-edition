using App.Application.DTOs;
using FluentValidation;

namespace App.Application.Validators;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório");
    }
}

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateValidator()
    {
        When(x => x.Name != null, () =>
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório"));
    }
}
