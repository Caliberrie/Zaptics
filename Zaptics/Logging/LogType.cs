using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Logging
{
    [Flags]
    public enum LogType
    {
        All          = 1 << 0,
        Applications = 1 << 1,
        Interactions = 1 << 2,
        Collar       = 1 << 3,
        Lovense      = 1 << 4,
    }
}
