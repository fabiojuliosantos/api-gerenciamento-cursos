using AutoMapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Infra.Interface;
using GerenciamentoCurso.Services.Interface;

namespace GerenciamentoCurso.Services.Service
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;
        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> MatricularAluno(Matricula matricula)
        {
            return await _repository.MatricularAluno( matricula);
        }

        public async Task<bool> RemoverMatricula(int id)
        {
            return await _repository.RemoverMatricula(id);
        }

        public async Task<RetornoPaginadoAlunos<Matricula>> RetornoPaginadoMatricula(int pagina, int quantidade)
        {
            return await _repository.RetornoPaginadoMatricula(pagina, quantidade);
        }
    }
}
