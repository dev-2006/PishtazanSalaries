using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Common.Query
{
    public class Page
    {
        public PageIndex Index { get; }
        public PageSize Size { get; }

        public Page(PageIndex index, PageSize size)
        {
            Index = ArgumentNotNull(index, nameof(index));
            Size = ArgumentNotNull(size, nameof(size));
        }
    }
}
