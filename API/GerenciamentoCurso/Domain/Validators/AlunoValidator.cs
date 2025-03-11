using FluentValidation;

namespace GerenciamentoCurso.Domain.Validators
{
    public class AlunoValidator : AbstractValidator<Alunos>
    {
        public AlunoValidator()
        {

            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório")
                .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres  ");

            RuleFor(x => x.Idade).NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório").InclusiveBetween(7, 111)
                .WithMessage("O campo '{PropertyName}' deve ter entre 7 e 11 anos de idade ");

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório")
                .MaximumLength(150).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres  ");


        }
    }
}
