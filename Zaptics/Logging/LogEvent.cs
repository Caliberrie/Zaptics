using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaptics.Logging
{
    internal struct LogEvent
    {
        public DateTimeOffset Timestamp;
        public string Level;
        public string Message;
    }
}
