namespace CQRS.Domain.Queries.V1.GetPerson;
public class GetPersonQuery
{
    public GetPersonQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}