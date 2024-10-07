using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Zaptics.Attributes;
using Zaptics.Logging;

namespace Zaptics.Configuration
{
    internal class AppConfig
    {
        public static readonly string AppDataPathBase = $"{Environment.GetEnvironmentVariable("appdata")}/Zaptics";
        public static readonly string ConfigPath = $"{AppDataPathBase}/zaptics-config.yaml";
        public static readonly string LogPath = $"{AppDataPathBase}/logs/";

        private static object _lockObj = new object();
        private static AppConfig _current;
        public static AppConfig Current
        {
            get
            {
                lock (_lockObj)
                {
                    if (_current == null)
                    {
                        Log.Information("Initializing configuration.");
                        _current = new AppConfig();

                        if (!File.Exists(ConfigPath))
                        {
                            Log.Information("No settings file on disk! Saving defaults.");
                            _current.WriteFile();
                        }
                        else
                        {
                            Log.Information("Reading config from disk.");
                            _current.ReadFile();
                        }
                    }
                }
                return _current;
            }
        }

        [UserSetting("VRChat", "Receive Port")]
        public int OscReceivePort { get; set; } = 9000;

        [UserSetting("VRChat", "Send Port")]
        public int OscSendPort { get; set; } = 9001;

        [UserSetting("VRChat", "Bind IP")]
        public string OscBindIp { get; set; } = "127.0.0.1";

        [UserSetting("UI", "UI Scaling")]
        public float UiScaling { get; set; } = 1f;

        [UserSetting("Developer", "Enable Developer Mode")]
        public bool EnableDeveloperMode { get; set; }

        private void WriteFile()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yamlOutput = serializer.Serialize(this);
            Log.Information(yamlOutput);

            if (yamlOutput == null)
            {
                Log.Error("Failed to serialize config to YAML.");
                return;
            }

            File.WriteAllText(ConfigPath, yamlOutput);
        }

        private void ReadFile()
        {
            if (!File.Exists(ConfigPath))
            {
                return;
            }

            try
            {
                var deserializer = new DeserializerBuilder()
                    .IgnoreUnmatchedProperties()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var yamlText = File.ReadAllText(ConfigPath);

                var loadedObject = deserializer.Deserialize<AppConfig>(yamlText);

                _current = loadedObject;

                if (_current == null)
                {
                    Log.Warning("Failed to deserialize config. Settings were reset!");
                    _current = new AppConfig();
                    WriteFile();
                }
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to deserialize config file: {e.Message}");
            }
        }

        public void Save()
        {
            lock (_lockObj)
            {
                WriteFile();
            }
        }
    }
}
