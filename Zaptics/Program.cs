using Serilog;
using Zaptics.CLI;
using Zaptics.Logging;
using Zaptics.Version;
using Zaptics.Win32;

namespace Zaptics;

class Program
{
    static void Main(string[] args) => new Program().Run();

    public void Run()
    {
        SerilogInitializer.Initialize();
        Log.Information($"Zaptics ({AppVersion.Current})");

        var shouldKeepConsole = CommandArgumentUtil.Exists("keepConsole");

        if (shouldKeepConsole)
        { 
            Log.Information("Console is being kept open.");
        }
        else
        {
            Log.Information("Hiding console.");
            Win32ConsoleUtil.Hide();
        }

        Log.Information("Creating SDL2 Window for UI.");

        var mainWindow = new MainWindow();
        mainWindow.Open();

        Log.Information("Application closing.");
        Log.CloseAndFlush();
    }
}