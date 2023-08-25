﻿using Pishtazan.Salaries.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishtazan.Salaries.Infrastructure.Tests.Unit.Validation
{
    public class ValidateTest
    {
        [Fact]
        public void ArgumentNotNull_NullArgument_ThrowsArgumentNotNullException()
        {
            object nullObject = null!;
            Assert.Throws<ArgumentNullException>(() => Validate.ArgumentNotNull(nullObject, "argumentName"));
        }
    }
}
