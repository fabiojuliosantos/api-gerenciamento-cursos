using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Domain.Validators;

public class CursoValidator : AbstractValidator<Curso>
{
    public CursoValidator()
    {
        RuleFor(x => x.Nome)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .MaximumLength(150).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres!");
        
        RuleFor(x => x.Descricao)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .MaximumLength(150).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres!");

        RuleFor(x => x.CargaHoraria)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo!");
    }
}
