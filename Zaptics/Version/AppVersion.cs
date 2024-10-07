using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Version
{
    internal static class AppVersion
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public static string Current
        {
            get
            {
                var version = Assembly.GetEntryAssembly().GetName().Version;
                return $"{version.Major}.{version.Minor}";
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
