﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Employees.Salaries
{
    public record Transportation : Salary
    {
        public Transportation(long value) : base(value)
        {
        }
    }
}
