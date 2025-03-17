using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GerenciamentoCurso.Domain;

public class Alunos
{
    public int AlunoId { get; set; }
    
    public string Nome { get; set; }


    public int Idade { get; set; }
  
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }
    public List<Cursos> CursoMatriculado { get; set; }

}
