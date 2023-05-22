using AutoMapper;
using CQRS.Domain.Entites.V1;
using CQRS.Domain.Helpers.V1;
using CQRS.Domain.ValueObjects.V1;

namespace CQRS.Domain.Commands.CreatePerson;
public class CreatePersonCommandProfile : Profile
{
    public CreatePersonCommandProfile()
    {
        CreateMap<CreatePersonCommand, Person>()
            .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                .MapFrom(input => new Document(input.Cpf!)))
            .ForMember(fieldOutput => fieldOutput.Name, option => option
                .MapFrom(input => new Name(input.Name!)))
            .ForMember(fieldOutput => fieldOutput.Email, option => option
                .MapFrom(input => new Email(input.Email!)));
    }
}