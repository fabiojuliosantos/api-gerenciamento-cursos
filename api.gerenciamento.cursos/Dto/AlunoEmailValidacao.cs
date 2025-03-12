using api.gerenciamento.cursos.Domain;
using FluentValidation;

namespace api.gerenciamento.cursos.Dto
{
    public class AlunoEmailValidacao : AbstractValidator<Aluno>
    {
        public AlunoEmailValidacao()
        { 
            try
            {
                RuleFor(aluno => aluno.Nome)
               .NotEmpty().WithMessage("O nome é obrigatório.")
               .Length(1, 100).WithMessage("O nome não pode ter mais que 100 caracteres.");

                RuleFor(aluno => aluno.Idade)
                    .NotEmpty().WithMessage("A idade é obrigatória.");

                RuleFor(aluno => aluno.Email)
                    .NotEmpty().WithMessage("O e-mail é obrigatório.")
                    .EmailAddress().WithMessage("O e-mail informado é inválido.");

                //RuleFor(aluno => aluno.MatriculaID)
                //    .NotEmpty().WithMessage("A matrícula é obrigatória.");
                RuleFor(aluno => aluno.MatriculaID)
                    .GreaterThan(0).WithMessage("A matrícula deve ser maior que zero.");

            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
