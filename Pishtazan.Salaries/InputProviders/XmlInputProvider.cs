using Newtonsoft.Json;
using Pishtazan.Salaries.Application.Employees.Contracts.Command;
using System.Text;
using System.Xml.Serialization;

namespace Pishtazan.Salaries.InputProviders
{
    public class XmlInputProvider : IInputProvider
    {
        public EmployeeSalary Convert(string rawData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EmployeeSalary));
            return (EmployeeSalary)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(rawData)))!;
        }
    }
}
