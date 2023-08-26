using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Framework
{
    public class NotFoundDomainException : DomainException
    {
        protected NotFoundDomainException(string message) : base(message)
        {
        }
    }
}
