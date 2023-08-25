using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Infrastructure.Validation
{
    public static class Validate
    {
        public static T ArgumentNotNull<T>(T? obj, string argumentName)
        {
            ArgumentNullException.ThrowIfNull(obj, argumentName);

            return obj;
        }
    }
}
