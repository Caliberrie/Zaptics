using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaptics.Logging;

namespace Zaptics.CLI
{
    public static class CommandArgumentUtil
    {
        private static Dictionary<string, string> _args = null;
        public static Dictionary<string, string> Args
        {
            get 
            {
                if (_args != null)
                    return _args;
                _args = new Dictionary<string, string>();

                var rawArgs = Environment.GetCommandLineArgs();
                foreach (var arg in rawArgs)
                {
                    if (!arg.StartsWith("--"))
                        continue;
                    
                    var splitArg = arg.Substring(2).Split("=");

                    if (_args.ContainsKey(splitArg[0]))
                    {
                        Log.Warning($"Duplicate command-line argument: [{splitArg}]");
                        continue;
                    }

                    var value = "";
                    if (splitArg.Length > 1)
                        value = splitArg[1];

                    _args[splitArg[0]] = value;
                }

                Log.Information($"Loaded {_args.Count} command-line arguments.");

                foreach (var key in _args.Keys)
                {
                    Log.Information($"  - {key}: {_args[key]}");
                }

                return _args;
            } 
        }

        public static T? GetArg<T>(string name, T? defaultValue = default)
        {
            var args = Environment.GetCommandLineArgs();

            return default;
        }
    }
}
