using FluentValidation;

namespace GerenciamentoCurso.Domain.Validators
{
    public class CursoValidator :  AbstractValidator<Cursos>
    {
        public CursoValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório")
                .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres  ");

            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório")
                .MaximumLength(200).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres  ");
        }
    }
}
