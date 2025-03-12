using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;
using api_gerenciamento_cursos.Services.Interface;
using AutoMapper;

namespace api_gerenciamento_cursos.Services.Service
{
    public class CursosService : ICursosService
    {
        private readonly ICursosRepository _cursosRepository;
        private readonly IMapper _mapper;

        public CursosService(ICursosRepository cursosRepository, IMapper mapper)
        {
            _cursosRepository = cursosRepository;
            _mapper = mapper;
        }

        public async Task<bool> AdicionaCursosAsync(Cursos cursos)
        {
            return await _cursosRepository.AdicionaCursosAsync(cursos);
        }

        public async Task<bool> AtualizarCursosAsync(Cursos cursos)
        {
            return await _cursosRepository.AtualizarCursosAsync(cursos);
        }

        public async Task<bool> DeletaCursosAsync(int id)
        {
            return await _cursosRepository.DeletaCursosAsync(id);
        }

        public async Task<IEnumerable<Cursos>> RecuperaCursosAsync()
        {
            return await _cursosRepository.RecuperaCursosAsync();
        }

        public async Task<Cursos> RecuperaCursosPorIdAsync(int id)
        {
            return await _cursosRepository.RecuperaCursosPorIdAsync(id);
        }
    }
}
