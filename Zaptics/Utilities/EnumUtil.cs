using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Utilities
{
    public static class EnumUtil
    {
        public static void AddFlag<T>(this T target, T flag) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");


        }

        public static void RemoveFlag<T>(this T target, T flag)
        {

        }
    }
}
