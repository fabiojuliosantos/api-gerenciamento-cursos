using Curso_API.Domain.Entities;
using FluentValidation;

namespace Curso_API.Domain.Validators;

public class CursoValidator : AbstractValidator<Curso>
{
    public CursoValidator()
    {
        RuleFor(x => x.Nome)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
            .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");
        
        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

        RuleFor(x => x.CargaHoraria)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");

    }
}
