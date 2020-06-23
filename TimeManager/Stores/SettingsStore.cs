using Newtonsoft.Json;
using System.IO;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class SettingsStore : ISettingsStore
    {
        private const string Filename = @"TMSettings.json";
        private Settings Settings { get; set; }
        public Settings GetSettings()
        {
            if (Settings != null) return Settings;

            if(!File.Exists(Filename))
            {
                Settings = new Settings();
                return Settings;
            }

            // Read file.
            using (StreamReader file = File.OpenText(Filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                Settings = (Settings)serializer.Deserialize(file, typeof(Settings));

                return Settings;
            }
        }

        public void UpdateSettings(Settings settings)
        {
            // Read file.
            using (StreamWriter file = File.CreateText(Filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Settings);
            }

        }
    }
}
