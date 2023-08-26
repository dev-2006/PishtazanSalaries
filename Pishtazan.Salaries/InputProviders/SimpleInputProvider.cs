using Newtonsoft.Json;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;

namespace Pishtazan.Salaries.InputProviders
{
    public abstract class SimpleInputProvider : IInputProvider
    {
        public abstract string Name { get; }

        public EmployeeSalary Convert(string rawData)
        {
            Dictionary<string, string> map = createMapOfProperties(rawData);
            return createObjectFrom(map);
        }

        protected abstract Dictionary<string, string> createMapOfProperties(string rawData);

        private EmployeeSalary createObjectFrom(Dictionary<string, string> map)
        {
            string json = JsonConvert.SerializeObject(map);

            return JsonConvert.DeserializeObject<EmployeeSalary>(json)!;
        }
    }
}
