using System;
using System.Collections.Generic;
using System.Globalization;
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

        public const int YEAR_LENGTH = 4;
        public const int MONTH_LENGTH = 2;
        public const int DAY_LENGTH = 2;

        public const int YAER_OFFSET = 0;
        public const int MONTH_OFFSET = YAER_OFFSET + YEAR_LENGTH;
        public const int DAY_OFFSET = MONTH_OFFSET + MONTH_LENGTH;

        public int Year => getDatePart(pc => pc.GetYear(GregorianDate));

        private int getDatePart(Func<PersianCalendar, int> get) => get(new PersianCalendar());

        public int Month => getDatePart(pc => pc.GetMonth(GregorianDate));
        public int Day => getDatePart(pc => pc.GetDayOfMonth(GregorianDate));
        public DateTime GregorianDate { get; private set; }

        internal Date(DateTime gregorianDate)
        {
            GregorianDate = gregorianDate;
        }

        public static Date FromString(string value)
        {
            value = ArgumentNotNull(value, "date").Trim();

            if (stringLengthIsNotCorrect(value))
                throw new ArgumentOutOfRangeException("Date is not valid");

            if (anyNonDigitCharsExistsIn(value))
                throw new ArgumentOutOfRangeException("Date is not valid");

            try
            {
                int year = int.Parse(value.Substring(YAER_OFFSET, YEAR_LENGTH));
                int month = int.Parse(value.Substring(MONTH_OFFSET, MONTH_LENGTH));
                int day = int.Parse(value.Substring(DAY_OFFSET, DAY_LENGTH));

                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

                return new Date(gregorianDate);
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException("Date is not valid", ex);
            }
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
