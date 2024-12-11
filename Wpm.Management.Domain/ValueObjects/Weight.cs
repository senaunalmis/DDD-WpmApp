using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Management.Domain.ValueObjects
{
    public record class Weight
    {
        // TO DO: Public record kullaımını araştır
        public decimal Value { get; init; }

        public Weight(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Weight value is not valid.");
            }
            Value = value;

        }
        public static implicit operator Weight(decimal value)
        {
            return new Weight(value);
        }

    }
}
