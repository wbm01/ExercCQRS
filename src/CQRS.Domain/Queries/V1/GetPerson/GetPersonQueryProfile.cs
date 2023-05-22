using AutoMapper;
using CQRS.Domain.Entites.V1;
using CQRS.Domain.Helpers.V1;

namespace CQRS.Domain.Queries.V1.GetPerson;
public class GetPersonQueryProfile : Profile
{
    public GetPersonQueryProfile()
    {
        CreateMap<Person, GetPersonQueryResponse>()
            .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                .MapFrom(input => input.Cpf.Value.FormatCpf()))
            .ForMember(fieldOutput => fieldOutput.Name, option => option
                .MapFrom(input => input.Name.Value.FormatCpf()))
            .ForMember(fieldOutput => fieldOutput.Email, option => option
                .MapFrom(input => input.Email.Value.FormatCpf()));
    }
}