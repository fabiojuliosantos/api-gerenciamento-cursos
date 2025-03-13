using AutoMapper;
using gerenciamento_cursos_api.Data.Dtos;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Profiles;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<AlunoDTO, Aluno>().ReverseMap();
        CreateMap<UpdateAlunoDTO, Aluno>().ReverseMap();

        CreateMap<MatriculaDTO, Matricula>().ReverseMap();

        CreateMap<CursoDTO, Curso>().ReverseMap();
        CreateMap<UpdateCursoDTO, Curso>().ReverseMap();
    }
}
