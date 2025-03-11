using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Infra.Interfaces;

public interface IMatriculaRepository
{
    Task<RetornoPaginado<Matricula>> BuscarMatriculaPagina(int pagina, int qtdRegistros);
    Task<bool> MatricularAluno(Matricula matricula);
    Task<bool> CancelarMatricula(int id);
}
