

using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface ISettingsStore
    {
        public Settings GetSettings();
        public void UpdateSettings(Settings settings);
    }
}
