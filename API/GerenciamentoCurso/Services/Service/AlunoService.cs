using AutoMapper;
using FluentValidation;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;
using GerenciamentoCurso.Infra.Context;
using GerenciamentoCurso.Infra.Interface;
using GerenciamentoCurso.Infra.Repositories;
using GerenciamentoCurso.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoCurso.Services.Service;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public AlunoService(IAlunoRepository repository, IMapper mapper, AppDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> AtualizarAlunoAsync( Alunos aluno)
    {

        try
        {
            return await _repository.AtualizarAlunoAsync(aluno);
        }
        catch (Exception )
        {

            throw;
        }
       
    }
    public async Task<bool> AdicionaAlunoAsync(Alunos aluno)
    {
        try
        {
            return await _repository.AdicionaAlunoAsync(aluno);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<AlunoComCurso> BuscaAlunoPorIdAsync(int id)
    {
        try
        {
            return await _repository.BuscaAlunoPorIdAsync(id);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<RetornoPaginadoAlunos<Alunos>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscaAlunoPorPagina(pagina, quantidade);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> DeletarAlunoAsync(int id)
    {

        try
        {
            return await _repository.DeletarAlunoAsync(id);
        }
        catch (Exception)
        {

            throw;
        }
        
       
    }

    public async Task<IEnumerable<AlunoComCurso>> RecuperaTodosAlunosAsync()
    {
        try
        {
            return await _repository.RecuperaTodosAlunosAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
}

