using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;
using api_gerenciamento_cursos.Services.Interface;
using AutoMapper;

namespace api_gerenciamento_cursos.Services.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunosRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunosRepository, IMapper mapper)
        {
            _alunosRepository = alunosRepository;
            _mapper = mapper;

        }

        public async Task<bool> AtualizarAlunoAsync(Aluno aluno)
        {
            return await _alunosRepository.AtualizarAlunoAsync(aluno);
        }
        public async Task<bool> AdicionaAlunoAsync(Aluno aluno)
        {
            return await _alunosRepository.AdicionaAlunoAsync(aluno);
        }

        public async Task<AlunoComCurso> BuscaAlunoPorIdAsync(int id)
        {
            return await _alunosRepository.BuscaAlunoPorIdAsync(id);
        }

        public async Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade)
        {
            return await _alunosRepository.BuscarAlunoPorPaginaAsync(pagina, quantidade);
        }

        public async Task<bool> DeletarAlunoAsync(int id)
        {
            return await _alunosRepository.DeletarAlunoAsync(id);
        }

        public async Task<IEnumerable<AlunoComCurso>> RecuperaTodosAlunosAsync()
        {
            return await _alunosRepository.RecuperaTodosAlunosAsync();
        }
    }
}
