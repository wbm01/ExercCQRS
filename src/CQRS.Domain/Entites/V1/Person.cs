using CQRS.Domain.Contracts.V1;
using CQRS.Domain.ValueObjects.V1;

namespace CQRS.Domain.Entites.V1
{
    public class Person : Entity
    {
        private Person(Name name,
            Document cpf,
            Email email,
            DateTime dateBirth)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            DateBirth = dateBirth;
        }
        public Person(Guid id,
            Name name,
            Document cpf,
            Email email,
            DateTime dateBirth,
            DateTime createdAt)
            : base(id, createdAt, DateTime.Now)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            DateBirth = dateBirth;
        }
        /*public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }*/
        public Name Name { get; set; }
        public Document Cpf { get; set; }
        public Email Email { get; set; }
        public DateTime DateBirth { get; set; }
    }
}