﻿using AutoMapper;
using CQRS.Domain.Contracts;
using CQRS.Domain.Core;
using CQRS.Domain.Helpers.V1;

namespace CQRS.Domain.Queries.V1.ListPerson;
public class ListPersonQueryHandler : BaseHandler
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _repository;

    public ListPersonQueryHandler(IMapper mapper, IPersonRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<PersonItemQueryResponse>> HandleAsync(ListPersonQuery command, CancellationToken cancellationToken)
    {

        var people = await _repository.FindAsync(
            person =>
                    (command.Name == null || person.Name.Value.Contains(command.Name.ToUpper()))
                    && (command.Cpf == null || person.Cpf.Value.Contains(command.Cpf.RemoveMaskCpf())),
                    cancellationToken
                );

        return _mapper.Map<List<PersonItemQueryResponse>>(people);
    }
}