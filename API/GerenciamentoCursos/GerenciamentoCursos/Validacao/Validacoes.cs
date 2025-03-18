using System.Text.RegularExpressions;
using GerenciamentoCursos.Domain;

namespace GerenciamentoCursos.Services.Services
{
    /*
        Bom uso das validações, utilizando Regex para validar o campo de email
    */
    public static class Validacoes
    {
        public static List<string> ValidarAluno(Aluno aluno)
        {
            var mensagensDeErro = new List<string>();

            if (string.IsNullOrEmpty(aluno.Nome) || aluno.Nome.Length < 3 || aluno.Nome.Length > 100 || !Regex.IsMatch(aluno.Nome, "^[a-zA-Z\\s]+$"))
            {
                mensagensDeErro.Add("Nome inválido: deve ter entre 3 e 100 caracteres e conter apenas letras e espaços.");
            }

            if (string.IsNullOrEmpty(aluno.Email) || !Regex.IsMatch(aluno.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                mensagensDeErro.Add("E-mail inválido.");
            }

            if (!aluno.Idade.HasValue)
            {
                mensagensDeErro.Add("Idade é obrigatória.");
            }
            else if (aluno.Idade < 16 || aluno.Idade > 110)
            {
                mensagensDeErro.Add("Idade inválida. Você só pode se cadastrar se tiver entre 16 e 110 anos.");
            }

            return mensagensDeErro;
        }

        public static List<string> ValidarCurso(Curso curso)
        {
            var mensagensDeErro = new List<string>();

            if (string.IsNullOrEmpty(curso.Nome) || curso.Nome.Length < 5 || curso.Nome.Length > 100)
            {
                mensagensDeErro.Add("Nome do curso inválido: deve ter entre 5 e 100 caracteres.");
            }

            if (curso.Descricao.Length > 500)
            {
                mensagensDeErro.Add("A descrição deve ser no máximo 500 caracteres.");
            }

            if (curso.CargaHoraria <= 0)
            {
                mensagensDeErro.Add("A carga horária deve ser maior que zero.");
            }

            return mensagensDeErro;
        }
    }
}
