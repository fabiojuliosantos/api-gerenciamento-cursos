using FluentValidation;

namespace api.gerenciamento.cursos.Dto
{
    public class AlunoInsercaoDtoValidacao : AbstractValidator<AlunoInsercaoDto>
    {
        public AlunoInsercaoDtoValidacao()
        {
            RuleFor(aluno => aluno.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(1, 100).WithMessage("O nome não pode ter mais que 100 caracteres.");

            RuleFor(aluno => aluno.Idade)
                .NotEmpty().WithMessage("A idade é obrigatória.")
                .GreaterThan(0).WithMessage("A idade deve ser maior que zero.");

            RuleFor(aluno => aluno.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado é inválido.");

            RuleFor(aluno => aluno.DataMatricula)
                .NotEmpty().WithMessage("A data de matrícula é obrigatória.");
        }
    }
}