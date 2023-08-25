using Pishtazan.Salaries.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pishtazan.Salaries.Infrastructure.Validation.Validate;

namespace Pishtazan.Salaries.Domain.Employees
{
    public record Date
    {
        /// <summary>
        /// تعداد کاراکترهای نمایش دهنده ی نوع رشته ای مربوط به زمان 
        /// </summary>
        /// <example>
        /// 14010801
        /// </example>
        public const int DATE_STRING_LENGTH = 8;

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public static Date FromString(string value)
        {
            value = ArgumentNotNull(value, "date").Trim();

            if (stringLengthIsNotCorrect(value))
                throw new ArgumentOutOfRangeException("Date is not valid");

            if (anyNonDigitCharsExistsIn(value))
                throw new ArgumentOutOfRangeException("Date is not valid");

            throw new NotImplementedException();
        }

        private static bool stringLengthIsNotCorrect(string value)
        {
            return value.Length != DATE_STRING_LENGTH;
        }

        private static bool anyNonDigitCharsExistsIn(string value)
        {
            return value.Any(c => !char.IsDigit(c));
        }
    }
}
