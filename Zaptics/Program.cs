using Serilog;
using Zaptics.Configuration;
using Zaptics.Logging;
using Zaptics.Utilities;
using Zaptics.Version;

namespace Zaptics;

class Program
{
    static void Main(string[] args) => new Program().Run();

    public void Run()
    {
        SerilogInitializer.Initialize();
        Log.Information($"Zaptics ({AppVersion.Current})");
        Log.Warning($"Zaptics ({AppVersion.Current})");
        Log.Error($"Zaptics ({AppVersion.Current})");
    }
}