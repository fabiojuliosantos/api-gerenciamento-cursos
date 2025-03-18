using CURSOS.API.Application.Interfaces;
using CURSOS.API.Domain;
using CURSOS.API.DTOs;
using CURSOS.API.Infra.Interfaces;

namespace CURSOS.API.Application.Services;

public class AlunosServices : IAlunosServices
{
    private readonly IAlunosRepository _repository;

    public AlunosServices(IAlunosRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AdicionarAlunoAsync(AlunosDTO alunosDTO)
    {
        try
        {
            var aluno = new Alunos
            {
                Nome = alunosDTO.Nome,
                Idade = alunosDTO.Idade,
                Email = alunosDTO.Email,
                DataMatricula = alunosDTO.DataMatricula
            };
            return await _repository.AdicionarAlunoAsync(aluno);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarAlunoAsync(AlunosDTO alunosDTO)
    {
        try
        {
            //Nesse caso aqui, deveria receber o id do aluno para atualização, como faz em cursos
            var aluno = new Alunos
            {
                Nome = alunosDTO.Nome,
                Idade = alunosDTO.Idade,
                Email = alunosDTO.Email,
                DataMatricula = alunosDTO.DataMatricula
            };
            return await _repository.AtualizarAlunoAsync(aluno);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Alunos>> BuscarAlunosAsync()
    {
        try
        {
            return await _repository.BuscarAlunosAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RetornoPaginado<Alunos>> BuscarAlunosPaginadosAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarAlunosPaginadosAsync(pagina, quantidade);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Alunos> BuscarAlunosPorIdAsync(int id)
    {
        try
        {
            return await _repository.BuscarAlunosPorIdAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeletarAlunosAsync(int id)
    {
        try
        {
            return await _repository.DeletarAlunosAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
