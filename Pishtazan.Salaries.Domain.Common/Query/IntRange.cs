using Pishtazan.Salaries.Framework;

namespace Pishtazan.Salaries.Domain.Common.Query
{
    public record IntRange : ValueTypeBase<int>
    {
        public int Min { get; }
        public int Max { get; }

        public IntRange(int value, int min, int max) : base(value)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException("value");
            Min = min;
            Max = max;
        }
    }
}