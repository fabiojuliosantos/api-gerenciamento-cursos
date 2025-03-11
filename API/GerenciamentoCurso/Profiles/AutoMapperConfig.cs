using AutoMapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;

namespace GerenciamentoCurso.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Alunos, AlunoDto>().ReverseMap();
            CreateMap<Cursos, CursoDto>().ReverseMap();
            CreateMap<Matricula, MatriculaDto>().ReverseMap();
            



        }
    }
}
