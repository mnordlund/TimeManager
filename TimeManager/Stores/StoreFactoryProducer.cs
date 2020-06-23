using System;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class StoreFactoryProducer
    {
        private static SettingsStore SettingsStore {get; set;}
        private static IStoreFactory StoreFactory { get; set; }

        public static SettingsStore GetSettingsStore()
        {
            if(SettingsStore == null)
            {
                SettingsStore = new SettingsStore();
            }

            return SettingsStore;
        }

        public static IStoreFactory GetStoreFactory()
        {
            if (StoreFactory != null) return StoreFactory;

            switch(GetSettingsStore().GetSettings().DatabaseType)
            {
                case DatabaseTypes.Sqlite:
                    StoreFactory = new StoreFactoryEF(GetSettingsStore().GetSettings());
                    break;
                default:
                    throw new NotImplementedException();
            }

            return StoreFactory;
        }
    }
}
