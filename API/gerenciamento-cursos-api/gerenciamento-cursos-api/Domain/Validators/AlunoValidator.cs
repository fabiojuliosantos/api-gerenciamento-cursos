using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Domain.Validators;

public class AlunoValidator : AbstractValidator<Aluno>
{
    public AlunoValidator()
    {
        RuleFor(x => x.Nome)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .MaximumLength(150).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres!");

        RuleFor(x => x.Idade)
            .NotNull().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .InclusiveBetween(1, 150)
            .WithMessage($"O campo '{{PropertyName}}' deve ser uma idade válida!");

        RuleFor(x => x.Email)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .MaximumLength(150).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres!");
    }
}
