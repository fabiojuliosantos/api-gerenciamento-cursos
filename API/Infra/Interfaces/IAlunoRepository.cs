using Api.Domain;
using Api.Infra.Dto;

namespace Api.Infra.Interfaces;

public interface IAlunoRepository
{
    Task<RetornoPaginado<Aluno>> ListaAlunosPaginados(int pagina, int quantidade);
    Task<List<Aluno>> ListaTodosAlunos();
    Task<Aluno> BuscaAlunoPorId(int id);
    Task<bool> CriaAluno(Aluno aluno);
    Task<bool> AtualizaAluno(Aluno aluno);
    Task<bool> DeletaAluno(int id);
}