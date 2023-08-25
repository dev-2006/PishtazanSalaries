using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees.Exceptions;
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

            if (salaryInSameMonthExists(date))
                throw new DuplicateSalariesInSameMonthException();

            addIncome(date, salaryDetail, incomeCalculationStrategy, overTimeCalculator);
        }

        private void addIncome(Date date, SalaryDetail salaryDetail, IIncomeCalculationStrategy incomeCalculationStrategy, IOvertimePolicyCalculator overTimeCalculator)
        {
            Income income = incomeCalculationStrategy.Calculate(salaryDetail, overTimeCalculator);

            _incomes.Add(new IncomeDetail(date, salaryDetail, income));
        }

        private bool salaryInSameMonthExists(Date date)
        {
            return _incomes.Any(x => x.Date.IsInSameMonthWith(date));
        }

        public void UpdateIncome(Date date, SalaryDetail salaryDetail, IIncomeCalculationStrategy incomeCalculationStrategy,
            IOvertimePolicyCalculator overTimeCalculator)
        {
            ArgumentNotNull(date, nameof(date));
            ArgumentNotNull(salaryDetail, nameof(salaryDetail));

            IncomeDetail? incomeInSameMonth = findIncomeInSameMonthWith(date);

            if (incomeInSameMonth == null)
                throw new SalaryInSameMonthNotFoundException();

            _incomes.Remove(incomeInSameMonth);

            addIncome(date, salaryDetail, incomeCalculationStrategy, overTimeCalculator);
        }

        private IncomeDetail? findIncomeInSameMonthWith(Date date)
        {
            return _incomes.SingleOrDefault(i => i.Date.IsInSameMonthWith(date));
        }

        public void DeleteIncome(Date date)
        {
            ArgumentNotNull(date, nameof(date));

            IncomeDetail? incomeInSpecifiedDate = findIncomeWithExactDate(date);

            if (incomeInSpecifiedDate == null)
                throw new SalaryNotFoundInSpecifiedDateException();
        }

        private IncomeDetail? findIncomeWithExactDate(Date date)
        {
            return _incomes.SingleOrDefault(i => i.Date == date);
        }
    }
}
