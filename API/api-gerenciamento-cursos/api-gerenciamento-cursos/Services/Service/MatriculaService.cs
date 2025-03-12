using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;
using api_gerenciamento_cursos.Infra.Interfaces;
using api_gerenciamento_cursos.Services.Interface;
using AutoMapper;

namespace api_gerenciamento_cursos.Services.Service
{

    public class MatriculaService : IMatriculaService
    {    
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepository matriculaRepository, IMapper mapper)
        {
            _matriculaRepository = matriculaRepository;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarMatriculaAsync(Matriculas matriculas)
        {
            return await _matriculaRepository.AdicionarMatriculaAsync(matriculas);
        }

        public async Task<bool> DeletarMatriculaAsync(int id)
        {
            return await _matriculaRepository.DeletarMatriculaAsync(id);
        }

        public async Task<RetornoPaginado<Matriculas>> ListarMatriculasPaginadoAsync(int pagina, int qtdPorPagina)
        {
            return await _matriculaRepository.ListarMatriculasPaginadoAsync(pagina, qtdPorPagina);
        }
    }
}
