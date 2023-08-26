using Newtonsoft.Json;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;

namespace Pishtazan.Salaries.InputProviders
{
    public class CsvInputProvider
    {
        public CsvInputProvider() { }

        public EmployeeSalary Convert(string rawData) 
        {
            Dictionary<string, string> map = createMapOfProperties(rawData);
            return createObjectFrom(map);
        }

        private Dictionary<string, string> createMapOfProperties(string rawData)
        {
            string[] propertyNames = new string[] { "FirstName", "LastName", "BasicSalary", "Allowance", "Transportation", "Date" };
            string[] propertyValues = rawData.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> map = new Dictionary<string, string>();

            for (int i = 0; i < propertyNames.Length && i < propertyValues.Length; i++)
                map.Add(propertyNames[i], propertyValues[i]);

            return map;
        }

        private EmployeeSalary createObjectFrom(Dictionary<string, string> map)
        {
            string json = JsonConvert.SerializeObject(map);

            return JsonConvert.DeserializeObject<EmployeeSalary>(json)!;
        }
    }
}
