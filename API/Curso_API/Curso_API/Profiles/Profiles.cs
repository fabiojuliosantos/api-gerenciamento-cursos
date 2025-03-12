using AutoMapper;
using Curso_API.Domain.Entities;
using Curso_API.Dto;

namespace Curso_API.Profiles;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Aluno,AlunoDto>().ReverseMap();
        CreateMap<Aluno,ReadAlunoDto>().ReverseMap();
        CreateMap<Curso,ReadCursoDto>().ReverseMap();
    }
}
