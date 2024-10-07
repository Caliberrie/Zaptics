using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Utilities
{
    internal class ProcessUtil
    {
        public static bool IsAlreadyOpen() => Process.GetProcesses().Count(p => p.ProcessName == Process.GetCurrentProcess().ProcessName) > 1;
    }
}
