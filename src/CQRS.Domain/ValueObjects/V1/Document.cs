using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Domain.Helpers.V1;

namespace CQRS.Domain.ValueObjects.V1
{
    public record Document
    {
        public Document(string value)
        {
            Value = value.RemoveMaskCpf();
        }

        public string Value { get; set; }
    }
}
