using AutoMapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Infra.Interface;
using GerenciamentoCurso.Services.Interface;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GerenciamentoCurso.Services.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarCurso(Cursos cursos)
        {
            return await _repository.AtualizarCurso(cursos);
        }

        public  async Task<bool> CriarCurso(Cursos cursos)
        {
            return await _repository.CriarCurso(cursos);
        }

        public async Task<bool> DeletarCurso(int id)
        {
            return await _repository.DeletarCurso(id);
        }

        public async Task<IEnumerable<Cursos>> ExibirCursos()
        {
            return await _repository.ExibirCursos();
        }

        public async Task<Cursos> RetornoCursoId(int id)
        {
            return await _repository.RetornoCursoId(id);
        }

        public async Task<RetornoPaginado<Cursos>> RetornoPaginadoCurso(int pagina, int quantidade)
        {
            return await _repository.RetornoPaginadoCurso(pagina,quantidade);
        }
    }
}
