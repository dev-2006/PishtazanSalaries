using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Common.Query
{
    public record Range<T>
    {
        public T InclusiveStart { get; }
        public T InclusiveEnd { get; }

        public Range(T inclusiveStart, T inclusiveEnd)
        {
            InclusiveStart = ArgumentNotNull(inclusiveStart, nameof(inclusiveStart));
            InclusiveEnd = ArgumentNotNull(inclusiveEnd, nameof(inclusiveEnd));
        }
    }
}
