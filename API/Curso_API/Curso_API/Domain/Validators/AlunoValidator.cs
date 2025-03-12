using Curso_API.Domain.Entities;
using FluentValidation;
namespace Curso_API.Domain.Validators;

public class AlunoValidator : AbstractValidator<Aluno>
{
    public AlunoValidator()  
    {
        RuleFor(x => x.Nome)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
            .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

        RuleFor(x => x.Idade)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");

        RuleFor(x => x.Email)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' deve ser um número positivo")
            .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres."); ;
    }
}
