using AutoMapper;
using CQRS.Domain.Entites.V1;
using CQRS.Domain.Helpers.V1;
using CQRS.Domain.Queries.V1.GetPerson;

namespace CQRS.Domain.Queries.V1.ListPerson;
public class ListPersonQueryProfile : Profile
{
    public ListPersonQueryProfile()
    {
        CreateMap<Person, PersonItemQueryResponse>()
            .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                .MapFrom(input => input.Cpf.Value))
            .ForMember(fieldOutput => fieldOutput.Name, option => option
                .MapFrom(input => input.Name.Value))
            .ForMember(fieldOutput => fieldOutput.Email, option => option
                .MapFrom(input => input.Email.Value));
    }
}