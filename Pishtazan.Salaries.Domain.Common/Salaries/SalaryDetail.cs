﻿using Pishtazan.Salaries.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Domain.Common.Salaries
{
    public class SalaryDetail
    {
        public BasicSalary BasicSalary { get; private set; }
        public Allowance Allowance { get; private set; }
        public Transportation Transportation { get; private set; }

        #pragma warning disable CS8618
        private SalaryDetail() { }

        public SalaryDetail(BasicSalary basicSalary, Allowance allowance, Transportation transportation)
        {
            BasicSalary = Validate.ArgumentNotNull(basicSalary, nameof(basicSalary));
            Allowance = Validate.ArgumentNotNull(allowance, nameof(allowance));
            Transportation = Validate.ArgumentNotNull(transportation, nameof(transportation));
        }
    }
}
