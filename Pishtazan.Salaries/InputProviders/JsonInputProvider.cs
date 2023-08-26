using Newtonsoft.Json;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;

namespace Pishtazan.Salaries.InputProviders
{
    public class JsonInputProvider : IInputProvider
    {
        public const string NAME = "Json";
        public string Name => NAME;

        public EmployeeSalary Convert(string rawData)
        {
            return JsonConvert.DeserializeObject<EmployeeSalary>(rawData)!;
        }
    }
}
