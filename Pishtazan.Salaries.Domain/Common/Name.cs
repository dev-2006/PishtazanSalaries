﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Common
{
    public record Name
    {
        public const int MIN_LENGTH = 2;

        public Name(string value)
        {
            ArgumentNullException.ThrowIfNull(value, "value");

            value= value.Trim();

            if (value.Length < MIN_LENGTH)
                throw new ArgumentOutOfRangeException(paramName: "name", message: "name length is too small");
        }
    }
}
