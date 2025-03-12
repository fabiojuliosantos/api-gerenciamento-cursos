using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;
using AutoMapper;

namespace api_gerenciamento_cursos.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AlunoDto, Aluno>().ReverseMap();
            CreateMap<Cursos, CursoDto>().ReverseMap();
            CreateMap<MatriculaDto, Matriculas>().ReverseMap();
        }
    }
}
