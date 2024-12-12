namespace Wpm.Management.SharedKernel.ValueObjects
{
    public record WeightRange
    {
        public decimal From { get; init; }
        public decimal To { get; init; }
        public WeightRange(decimal from, decimal to)
        {
            From = from;
            To = to;
        }
        public bool IsInRange(decimal weight)
        {
            return weight >= From && weight <= To;
        }
    }
}
