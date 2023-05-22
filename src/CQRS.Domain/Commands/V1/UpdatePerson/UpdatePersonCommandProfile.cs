using AutoMapper;
using CQRS.Domain.Commands.CreatePerson;
using CQRS.Domain.Commands.UpdatePerson;
using CQRS.Domain.Entites.V1;
using CQRS.Domain.Helpers;
using CQRS.Domain.Helpers.V1;
using CQRS.Domain.ValueObjects.V1;

namespace CQRS.Domain.Commands.V1.UpdatePerson;

public class UpdatePersonCommandProfile : Profile
{
    public UpdatePersonCommandProfile()
    {
        CreateMap<UpdatePersonCommand, Person>()
            .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                .MapFrom(input => new Document(input.Cpf!)))
            .ForMember(fieldOutput => fieldOutput.Name, option => option
                .MapFrom(input => new Name(input.Name!)))
            .ForMember(fieldOutput => fieldOutput.Email, option => option
                .MapFrom(input => new Email(input.Email!)));
    }
}