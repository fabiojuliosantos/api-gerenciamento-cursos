using AutoMapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Dto;

namespace gerenciamentoCursos.Profiles;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<AlunoDto, Aluno>();
    }
}
