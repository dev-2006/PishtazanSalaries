using Newtonsoft.Json;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;

namespace Pishtazan.Salaries.InputProviders
{
    public class CustomeInputProvider : SimpleInputProvider
    {
        public CustomeInputProvider()
        {

        }

        protected override Dictionary<string, string> createMapOfProperties(string rawData)
        {
            var lines = rawData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length != 2)
                throw new FormatException();

            string[] propertyNames = lines[0].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string[] propertyValues = lines[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> map = new Dictionary<string, string>();

            for (int i = 0; i < propertyNames.Length && i < propertyValues.Length; i++)
                map.Add(propertyNames[i], propertyValues[i]);

            return map;
        }
    }
}
