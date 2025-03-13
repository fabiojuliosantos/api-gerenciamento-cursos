using Api.Domain;
using Api.Infra.Dto;

namespace Api.Service.Interfaces;

public interface IAlunoService
{
    Task<RetornoPaginado<Aluno>> ListaAlunosPaginado(int pagina, int quantidade);
    Task<List<Aluno>> ListaTodosAlunos();
    Task<ReadAlunoDto> BuscaAlunoPorId(int id);
    Task<bool> CriaAluno(CreateAlunoDto createAlunoDto);
    Task<bool> AtualizaAluno(UpdateAlunoDto updateAlunoDto);
    Task<bool> DeletaAluno(int id);
}