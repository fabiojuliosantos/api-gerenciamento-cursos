using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Domain.Validators;

public class MatriculaValidator : AbstractValidator<Matricula>
{
    public MatriculaValidator()
    {
        RuleFor(x => x.AlunoID)
           .NotNull().GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser positivo!");

        RuleFor(x => x.CursoID)
           .NotNull().GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser positivo!");
    }
}
