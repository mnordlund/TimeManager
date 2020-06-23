
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface ISettingsHandler
    {
        public Settings GetSettings();
        public void UpdateSettings(Settings settings);
    }
}
