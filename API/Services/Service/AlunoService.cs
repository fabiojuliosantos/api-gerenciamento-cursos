using Api.Domain;
using Api.Infra.Dto;
using Api.Infra.Interfaces;
using Api.Service.Interfaces;
using Api.Utils;
using AutoMapper;

namespace Api.Service.Service;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;

    public AlunoService(IAlunoRepository repository, IMapper mapper, ICursoRepository cursoRepository)
    {
        _alunoRepository = repository;
        _mapper = mapper;
        _cursoRepository = cursoRepository;
    }

    public async Task<List<Aluno>> ListaTodosAlunos()
    {
        return await _alunoRepository.ListaTodosAlunos();
    }

    public async Task<ReadAlunoDto> BuscaAlunoPorId(int id)
    {
        try
        {
            Aluno aluno = await _alunoRepository.BuscaAlunoPorId(id);
        
            if (aluno is null)
                throw new CustomerException($"Aluno não foi encontrado pelo Id {id}.");
    
            var cursos = await _cursoRepository.ListaCursoPorAlunoId(aluno.AlunoID);
            aluno.Cursos = cursos;
            List<ReadCursosDto> readCursosDto = _mapper.Map<List<ReadCursosDto>>(aluno.Cursos);

            ReadAlunoDto readAlunoDto = _mapper.Map<ReadAlunoDto>(aluno);
            readAlunoDto.Cursos = readCursosDto;
            
            return readAlunoDto;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> CriaAluno(CreateAlunoDto createAlunoDto)
    {
        try
        {
            Aluno aluno = _mapper.Map<Aluno>(createAlunoDto);
            return await _alunoRepository.CriaAluno(aluno);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> AtualizaAluno(UpdateAlunoDto updateAlunoDto)
    {
        try
        {
            Aluno aluno = _mapper.Map<Aluno>(updateAlunoDto);
            return await _alunoRepository.AtualizaAluno(aluno);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeletaAluno(int id)
    {
        try
        {
            return await _alunoRepository.DeletaAluno(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<RetornoPaginado<Aluno>> ListaAlunosPaginado(int pagina, int quantidade)
    {
        try
        {
            var listaAlunoPaginado = await _alunoRepository.ListaAlunosPaginados(pagina, quantidade);

            foreach (var aluno in listaAlunoPaginado.ListaDados)
            {
                var cursos = await _cursoRepository.ListaCursoPorAlunoId(aluno.AlunoID);
                aluno.Cursos = cursos;
            }

            return listaAlunoPaginado;

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}