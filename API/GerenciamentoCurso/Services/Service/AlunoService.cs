using AutoMapper;
using FluentValidation;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;
using GerenciamentoCurso.Infra.Interface;
using GerenciamentoCurso.Infra.Repositories;
using GerenciamentoCurso.Services.Interface;

namespace GerenciamentoCurso.Services.Service;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;
    private readonly IMapper _mapper;

    public AlunoService(IAlunoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> AtualizarAlunoAsync(Alunos aluno)
    {
        return await _repository.AtualizarAlunoAsync(aluno);
    }
    public async Task<bool> AdicionaAlunoAsync(Alunos aluno)
    {
        return await _repository.AdicionaAlunoAsync(aluno);
    }

    public async Task<AlunoComCurso> BuscaAlunoPorIdAsync(int id)
    {
        return await _repository.BuscaAlunoPorIdAsync(id);
    }

    public async Task<RetornoPaginado<Alunos>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade)
    {
        return await _repository.BuscaAlunoPorPagina(pagina, quantidade);
    }

    public async Task<bool> DeletarAlunoAsync(int id)
    {
        return await _repository.DeletarAlunoAsync(id);
    }

    public async Task<IEnumerable<AlunoComCurso>> RecuperaTodosAlunosAsync()
    {
        return await _repository.RecuperaTodosAlunosAsync();
    }
}

