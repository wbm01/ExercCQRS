using CQRS.Domain.Contracts.V1;
using CQRS.Domain.Entites.V1;
using System.Linq.Expressions;

namespace CQRS.Domain.Contracts;
public interface IPersonRepository: IBaseRepository<Person>
{
    
}