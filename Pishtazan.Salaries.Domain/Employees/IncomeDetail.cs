using Pishtazan.Salaries.Domain.Common.Salaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Employees
{
    public class IncomeDetail
    {
        public Date Date { get; private set; }
        public SalaryDetail SalaryDetails { get; private set; }
        public Income Income { get; private set; }

#pragma warning disable CS8618
        private IncomeDetail() { }

        public IncomeDetail(Date date, SalaryDetail salaryDetails, Income income)
        {
            Date = ArgumentNotNull(date, nameof(date));
            SalaryDetails = ArgumentNotNull(salaryDetails, nameof(salaryDetails));
            Income = ArgumentNotNull(income, nameof(income));
        }
    }
}
