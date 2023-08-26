using Pishtazan.Salaries.Application.Employees.Contracts.Command;

namespace Pishtazan.Salaries.InputProviders
{
    public interface IInputProvider
    {
        EmployeeSalary Convert(string rawData);
    }
}