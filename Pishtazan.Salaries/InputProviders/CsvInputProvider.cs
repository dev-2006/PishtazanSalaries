using Newtonsoft.Json;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using Pishtazan.Salaries.Domain.Common.Salaries;
using Pishtazan.Salaries.Domain.Employees;

namespace Pishtazan.Salaries.InputProviders
{
    public class CsvInputProvider : SimpleInputProvider
    {
        public const string NAME = "Csv";
        public override string Name => NAME;

        public CsvInputProvider() { }
        
        protected override Dictionary<string, string> createMapOfProperties(string rawData)
        {
            string[] propertyNames = new string[] { "FirstName", "LastName", "BasicSalary", "Allowance", "Transportation", "Date" };
            string[] propertyValues = rawData.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> map = new Dictionary<string, string>();

            for (int i = 0; i < propertyNames.Length && i < propertyValues.Length; i++)
                map.Add(propertyNames[i], propertyValues[i]);

            return map;
        }
    }
}
