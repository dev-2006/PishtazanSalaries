namespace Pishtazan.Salaries.Domain.Common.Query
{
    public record PageSize : IntRange
    {
        public const int MIN = 1;
        public const int MAX = 50;

        public PageSize(int value) : base(value, MIN, MAX)
        {
        }
    }
}