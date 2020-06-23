using TimeManager.DataTypes;
using TimeManager.Interfaces;
using TimeManager.Stores;

namespace TimeManager.Handlers
{
    class SettingsHandler: ISettingsHandler
    {
        private ISettingsStore SettingsStore { get; set; }

        public SettingsHandler(ISettingsStore settingsStore)
        {
            SettingsStore = settingsStore;
        }

        public SettingsHandler()
        {
            SettingsStore = StoreFactoryProducer.GetSettingsStore();
        }
        public Settings GetSettings()
        {
            return SettingsStore.GetSettings();
        }
        public void UpdateSettings(Settings settings)
        {
            SettingsStore.UpdateSettings(settings);
        }
    }
}
