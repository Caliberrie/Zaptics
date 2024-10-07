using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Utilities
{
    public static class StringExtensions
    {
        public static string ClampLength(this string value, int max)
        {
            if (max < 3)
                throw new ArgumentOutOfRangeException(nameof(max), "Must be at least three max characters long.");
            if (value.Length <= max)
                return value;
            var length = max - 3;
            var clamped = value.Substring(0, max);
            return $"{clamped}...";
        }
    }
}
