using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;
using AutoMapper;

namespace api_gerenciamento_cursos.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<AlunoDto, Aluno>().ReverseMap();
        }
    }
}
