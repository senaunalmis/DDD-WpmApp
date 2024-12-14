using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public record Text
    {
        public string Value { get; init; }
        public Text(string value)
        {
            Validate(value);
            Value = value;
        }
        private void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value", "Text is not valid.");
            }
            if (value.Length > 500)
            {
                throw new ArgumentNullException("Text too large.");
            }
        }
        public static implicit operator Text(string value)
        {
            return new Text(value);
        }

    }
}
