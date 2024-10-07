using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaptics.Configuration;
using Zaptics.Utilities;

namespace Zaptics.Logging
{
    internal static class SerilogInitializer
    {
        public static void Initialize()
        {
            if (!Directory.Exists(AppConfig.LogPath))
            {
                Console.WriteLine("Creating log path.");
                Directory.CreateDirectory(AppConfig.LogPath);
            }

            var template = "[{Timestamp:HH:mm:ss.fff}] {Level:u1} {Message}{NewLine}{Exception}";
            var path = Path.Combine(AppConfig.LogPath, $"zaptics-{DateUtil.Filestamp}.log");

            Console.WriteLine($"Serilog File: {path}");

            using var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: template)
                .WriteTo.File(path, outputTemplate: template)
                .CreateLogger();

            Log.Logger = logger;
        }
    }
}
