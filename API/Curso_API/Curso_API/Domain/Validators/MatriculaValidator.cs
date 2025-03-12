using Curso_API.Domain.Entities;
using FluentValidation;

namespace Curso_API.Domain.Validators;

public class MatriculaValidator : AbstractValidator<Matricula>
{
    public MatriculaValidator()
    {
        RuleFor(x => x.AlunoID)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");
        
        RuleFor(x => x.CursoID)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");

    }
}
