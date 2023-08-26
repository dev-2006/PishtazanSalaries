using Pishtazan.Salaries.Framework;

namespace Pishtazan.Salaries.Domain.Common.Query
{
    public record PageIndex : IntRange
    {
        public const int MIN = 0;
        public const int MAX = 1000;

        public PageIndex(int value) : base(value, MIN, MAX)
        {
        }
    }
}