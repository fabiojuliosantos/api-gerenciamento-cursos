using AutoMapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Dto;

namespace GerenciamentoCursos.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AlunoDto, Aluno>()
            .ForMember(dest => dest.DataMatricula, opt => opt.Ignore());
            CreateMap<CursoDto, Curso>();
            CreateMap<MatriculaDto, Matricula>();

        }
    }
}
