using Pishtazan.Salaries.Domain.Common.Query;
using Pishtazan.Salaries.Domain.Employees;

namespace Pishtazan.Salaries.Application.Employees.Repository
{
    public record DateRange : Range<Date>
    {
        public DateRange(Date inclusiveStart, Date inclusiveEnd) : base(inclusiveStart, inclusiveEnd)
        {
        }
    }
}