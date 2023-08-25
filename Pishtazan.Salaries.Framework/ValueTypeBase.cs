using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Framework
{
    public record ValueTypeBase<T>
    {
        public T Value { get; protected set; }

        public ValueTypeBase(T value)
        {
            this.Value = value;
        }
    }
}
