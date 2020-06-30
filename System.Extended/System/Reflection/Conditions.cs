using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Reflection
{
    [DebuggerStepThrough]
    internal static class Conditions
    {
        public static T NotNull<T>(T value, string parameterName)
            where T : class
        {
            if (ReferenceEquals(value, null))
            {
                NotEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
        public static IEnumerable<T> NotEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            if (ReferenceEquals(value, null))
            {
                NotEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            if (!value.Any())
            {
                NotEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException("IEnumerable<T> value cannot be empty.", parameterName);
            }
            return value;
        }

        public static string NotEmpty(string value, string parameterName)
        {
            if (ReferenceEquals(value, null))
            {
                NotEmpty(parameterName, nameof(parameterName));

                throw new ArgumentNullException(parameterName);
            }

            if (value.Length == 0)
            {
                NotEmpty(parameterName, nameof(parameterName));

                throw new ArgumentException("String value cannot be null.", parameterName);
            }

            return value;
        }
    }
}
