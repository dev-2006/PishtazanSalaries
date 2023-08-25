using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;
using Pishtazan.Salaries.Infrastructure.Validation;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Employees
{
    public class Employee
    {
        private ICollection<IncomeDetail> _incomes;
        public IReadOnlyCollection<IncomeDetail> Incomes => _incomes.ToList();

        public FullName FullName { get; private set; }

        public Employee(FullName fullName)
        {
            FullName = ArgumentNotNull(fullName, nameof(fullName));
            _incomes = new HashSet<IncomeDetail>();
        }

        public Employee(FullName fullName, ICollection<IncomeDetail> incomes)
        {           
            FullName = ArgumentNotNull(fullName, nameof(fullName));
            _incomes = ArgumentNotNull(incomes, nameof(incomes));
        }

        public void AddIncome(Date date, SalaryDetail salaryDetail, IIncomeCalculationStrategy incomeCalculationStrategy,
            IOvertimePolicyCalculator overTimeCalculator)
        {
            ArgumentNotNull(date, nameof(date));
            ArgumentNotNull(salaryDetail, nameof(salaryDetail));
            ArgumentNotNull(incomeCalculationStrategy, nameof(incomeCalculationStrategy));
            ArgumentNotNull(overTimeCalculator, nameof(overTimeCalculator));

            Income income = incomeCalculationStrategy.Calculate(salaryDetail, overTimeCalculator);

            _incomes.Add(new IncomeDetail(date, salaryDetail, income));
        }
    }
}
