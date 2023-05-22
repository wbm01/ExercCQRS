using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.ValueObjects.V1
{
    public record Email
    {
        public Email(string value) 
        {
            Value = value.ToUpperInvariant();
        }

        public string Value { get; set; }
    }
}
