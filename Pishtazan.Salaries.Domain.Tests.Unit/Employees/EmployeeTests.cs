using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;
using Pishtazan.Salaries.Domain.Employees.Exceptions;
using Pishtazan.Salaries.Domain.IncomeCalculationStrategies;
using Pishtazan.Salaries.OvertimePolicies.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pishtazan.Salaries.Domain.Tests.Unit.Employees
{
    public class EmployeeTests
    {
        private Employee employee = new Employee(
                fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes: new List<IncomeDetail>());
        private Date date = Date.FromString("14000101");        
        private SalaryDetail salaryDetail = new SalaryDetail(new BasicSalary(1), new Allowance(1), new Transportation(1));
        private IIncomeCalculationStrategy incomeCal = new IncomeCalculationStrategy();
        private IOvertimePolicyCalculator overTimeCal = new CalculatorA();

        [Fact]
        public void Constructor_NullFullName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(fullName: null!, incomes: new List<IncomeDetail>()));
        }

        [Fact]
        public void Constructor_NullIncomes_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes: null!));
        }

        [Fact]
        public void AddIncome_NullData_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => employee.AddIncome(date: null!, salaryDetail, incomeCal, overTimeCal));
        }

        [Fact]
        public void Constructor_NullSalaryDetail_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => employee.AddIncome(date, salaryDetail: null!, incomeCal, overTimeCal));
        }

        [Fact]
        public void Constructor_NullIncomeCalculationStrategy_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => employee.AddIncome(date, salaryDetail, incomeCalculationStrategy: null!,
                overTimeCal));
        }

        [Fact]
        public void AddIncome_NullOvertimePolicyCalculator_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => employee.AddIncome(date, salaryDetail, incomeCal, 
                overTimeCalculator: null!));
        }

        [Fact]
        public void AddIncome_WhenIncomesAreEmpty_AcceptsAnyValidIncomeDetail()
        {
            // Arrange
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")));

            // Act
            employee.AddIncome(date, salaryDetail, incomeCal, overTimeCal);

            // Assert
            Assert.Equal(1, employee.Incomes.Count);
        }

        [Theory]
        [InlineData("14010503", "14010527")]
        [InlineData("14000301", "14000331")]
        [InlineData("13990402", "13990430")]
        [InlineData("14021112", "14021125")]
        public void AddIncome_WhenIncomeInSameMonthExists_ThrowsDuplicateSalariesInSameMonthException(string date1, string date2)
        {
            // Arrange
            List<IncomeDetail> incomes = new List<IncomeDetail>()
            {
                new IncomeDetail(Date.FromString(date1), salaryDetail, new Income(5))
            };
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes);

            // Act
            var e = Record.Exception(() => employee.AddIncome(Date.FromString(date2), salaryDetail, incomeCal, overTimeCal));

            // Assert
            Assert.IsType<DuplicateSalariesInSameMonthException>(e);
        }

        [Theory]
        [InlineData("14010503", "14010601")]
        [InlineData("14000301", "14000231")]
        [InlineData("13990402", "13990530")]
        [InlineData("14021112", "14021201")]
        public void AddIncome_WhenNoIncomeInSameMonthExists_IncomeWillBeAddedToIncomes(string date1, string date2)
        {
            // Arrange
            List<IncomeDetail> incomes = new List<IncomeDetail>()
            {
                new IncomeDetail(Date.FromString(date1), salaryDetail, new Income(5))
            };
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes);

            // Act
            employee.AddIncome(Date.FromString(date2), salaryDetail, incomeCal, overTimeCal);

            // Assert
            Assert.Equal(2, employee.Incomes.Count);
        }

        [Theory]
        [InlineData("14010503", "14010601")]
        [InlineData("14000301", "14000231")]
        [InlineData("13990402", "13990530")]
        [InlineData("14021112", "14021201")]
        public void UpdateIncome_WhenIncomeInSameMonthNotExists_ThrowsSalaryInSameMonthNotFoundException(string date1, string date2)
        {
            // Arrange
            List<IncomeDetail> incomes = new List<IncomeDetail>()
            {
                new IncomeDetail(Date.FromString(date1), salaryDetail, new Income(5))
            };
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes);

            // Act
            var e = Record.Exception(() => employee.UpdateIncome(Date.FromString(date2), salaryDetail, incomeCal, overTimeCal));

            // Assert
            Assert.IsType<SalaryInSameMonthNotFoundException>(e);
        }

        [Theory]
        [InlineData("14010503", "14010527")]
        [InlineData("14000301", "14000331")]
        [InlineData("13990402", "13990430")]
        [InlineData("14021112", "14021125")]
        public void UpdateIncome_WhenIncomeInSameMonthExists_ItWillBeReplaced(string date1, string date2)
        {
            // Arrange
            List<IncomeDetail> incomes = new List<IncomeDetail>()
            {
                new IncomeDetail(Date.FromString(date1), salaryDetail, new Income(5))
            };
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes);

            // Act
            var basicSalary = new BasicSalary(2);
            var allowance = new Allowance(3);
            var transportation = new Transportation(4);
            SalaryDetail salaryDetail2 = new SalaryDetail(basicSalary, allowance, transportation);
            Date d2 = Date.FromString(date2);
            employee.UpdateIncome(d2, salaryDetail2, incomeCal, overTimeCal);

            // Assert
            Income expectedIncome = new Income(2 + 3 + 4 + (2 + 3));
            Assert.Equal(1, employee.Incomes.Count);
            Assert.Equal(d2, employee.Incomes.ToArray()[0].Date);
            Assert.Equal(expectedIncome, employee.Incomes.ToArray()[0].Income);
            Assert.Equal(basicSalary, employee.Incomes.ToArray()[0].SalaryDetails.BasicSalary);
            Assert.Equal(allowance, employee.Incomes.ToArray()[0].SalaryDetails.Allowance);
            Assert.Equal(transportation, employee.Incomes.ToArray()[0].SalaryDetails.Transportation);
        }

        [Theory]
        [InlineData("14010503", "14010504")]
        [InlineData("14000301", "14000310")]
        [InlineData("13990402", "13990502")]
        [InlineData("14021112", "14021111")]
        public void DeleteIncome_WhenIncomeWithExactDateNotExists_ThrowsSalaryNotFoundInSpecifiedDateException(string date1, string date2)
        {
            // Arrange
            List<IncomeDetail> incomes = new List<IncomeDetail>()
            {
                new IncomeDetail(Date.FromString(date1), salaryDetail, new Income(5))
            };
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes);

            // Act
            var e = Record.Exception(() => employee.DeleteIncome(Date.FromString(date2)));

            // Assert
            Assert.IsType<SalaryNotFoundInSpecifiedDateException>(e);
        }

        [Theory]
        [InlineData("14010503", "14010503")]
        [InlineData("14000301", "14000301")]
        public void DeleteIncome_WhenIncomeWithExactDateExists_ItWillBeRemoved(string date1, string date2)
        {
            // Arrange
            List<IncomeDetail> incomes = new List<IncomeDetail>()
            {
                new IncomeDetail(Date.FromString(date1), salaryDetail, new Income(5))
            };
            Employee employee = new Employee(fullName: new FullName(new FirstName("ali"), new LastName("ahmadi")), incomes);

            // Act
            employee.DeleteIncome(Date.FromString(date2));

            // Assert
            Assert.Equal(0, employee.Incomes.Count);
        }
    }
}
