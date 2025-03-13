using Api.Domain;
using Api.Infra.Dto;
using AutoMapper;

namespace Api.AppProfile;

public class AppProfile : Profile
{
    public AppProfile()
    {
        #region Aluno
        CreateMap<Aluno, CreateAlunoDto>().ReverseMap();
        CreateMap<Aluno, UpdateAlunoDto>().ReverseMap();
        CreateMap<Aluno, ReadAlunoDto>()
            .ForMember(alunoDto => alunoDto.Cursos, opt => opt.MapFrom(aluno => aluno.Cursos));
        #endregion

        #region Curso
        CreateMap<Curso, CreateCursoDto>().ReverseMap();
        CreateMap<Curso, UpdateCursoDto>().ReverseMap();
        CreateMap<Curso, ReadCursosDto>().ReverseMap();
        #endregion

        #region Matricula
        CreateMap<Matricula, CreateMatricula>().ReverseMap();
        #endregion
    }
}