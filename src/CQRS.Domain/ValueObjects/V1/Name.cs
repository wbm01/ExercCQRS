using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.ValueObjects.V1
{
    public record Name
    {
        public Name(string value)
        {
            Value = value.ToUpperInvariant(); //poderia ser utilizado o ToUpper
        }

        public string Value { get; set; }
    }
}
