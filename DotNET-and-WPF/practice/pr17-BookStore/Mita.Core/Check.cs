using System;

namespace Mita.Core
{
    public static class Check
    {
        public static string NotNullOrEmpty(string value, string paramName)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException("String argument must be not null and not empty.", paramName);
            }

            return value;
        }

        public static T NotNull<T>(T value, string paramName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, string paramName) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return value;
        }

        public static T Min<T>(T value, T minValue, string paramName) where T : IComparable<T>
        {
            int res = value.CompareTo(minValue);

            if (res < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Min value for {0} is {1}".FormatWith(paramName, minValue));
            }

            return value;
        }
    }
}
