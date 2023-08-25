using Pishtazan.Salaries.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Employees
{
    public record Name : ValueTypeBase<string>
    {
        public const int MIN_LENGTH = 2;
        public const int MAX_LENGTH = 200;

        public Name(string value) : base(value)
        {
            value = ArgumentNotNull(value, "value").Trim();

            if (value.Length < MIN_LENGTH)
                throw new ArgumentOutOfRangeException(paramName: "name", message: "name length is too small");

            if (value.Length > MAX_LENGTH)
                throw new ArgumentOutOfRangeException(paramName: "name", message: "name length is too big");

            Value = value;
        }
    }
}
