using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;
using GerenciamentoCurso.Infra.Interface;
using GerenciamentoCurso.Services.Interface;

namespace GerenciamentoCurso.Services.Service;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<RespostaDto> AtualizarAluno(AtualizarAlunoDto atualizarAlunoDto)
    {
        try
        {
            if(atualizarAlunoDto.AlunoId < 0)
            {
                return new RespostaDto(false, "Insira um ID válido!");
            }

            if (string.IsNullOrEmpty(atualizarAlunoDto.Nome))
            {
                return new RespostaDto(false, "Nome não pode ser nulo!!");
            }

            var alunoExistente = await _repository.BuscasrAlunosPorId(atualizarAlunoDto.AlunoId);
            if (alunoExistente == null)
                return new RespostaDto(false, "Aluno não encontrada");


            alunoExistente.Nome = atualizarAlunoDto.Nome;

            bool resultado = await _repository.AtualizarAluno(alunoExistente);

            if (!resultado)
                return new RespostaDto(false, "Erro ao atualizar empresa");

            return new RespostaDto(true, "Empresa atualizada com sucesso!");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Alunos> BuscasrAlunosPorId(int id)
    {
        try
        {
            if(id < 0 )
            {
                return await _repository.BuscasrAlunosPorId(id);
            }
        catch (Exception)
        {

            throw;
        }
    }

    public Task<RespostaDto> CriarAluno(CriarAlunoDto criarAlunoDto)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto> DeletarAluno(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alunos>> RecuperarTodosAlunos()
    {
        throw new NotImplementedException();
    }

    public Task<RetornoPaginado<Alunos>> RetornoPaginadoAluno(int pagina, int quantidade)
    {
        throw new NotImplementedException();
    }
}
