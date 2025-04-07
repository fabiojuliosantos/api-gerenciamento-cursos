using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Services.Interfaces;

public interface IMatriculaService
{
    Task<bool> AdicionarMatricula(Matricula matricula);
    Task<List<Matricula>> BuscarTodasMatriculas();
    Task<Matricula> BuscarMatriculaPorID(int id);
    Task<bool> AtualizarMatricula(Matricula matricula);
    Task<bool> DeletarMatricula(int id);
}
