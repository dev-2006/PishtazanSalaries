﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Common
{
    public record FirstName : Name
    {
        public FirstName(string value) : base(value)
        {
        }
    }
}
