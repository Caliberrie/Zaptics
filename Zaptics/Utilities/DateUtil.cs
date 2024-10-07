using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Utilities
{
    internal class DateUtil
    {
        public static string TimestampNow => DateTimeOffset.Now.ToString("hh:mm:ss.fff");
        public static string DatestampNow => DateTimeOffset.Now.ToString("yyyy-MM-dd");
        public static string FullstampNow => $"{DatestampNow}T{TimestampNow}";
        public static string Filestamp => DateTimeOffset.Now.ToString("yyyy-MM-dd-hh-mm-ss");
    }
}
