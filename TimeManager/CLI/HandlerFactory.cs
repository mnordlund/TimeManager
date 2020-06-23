using TimeManager.Handlers;
using TimeManager.Interfaces;

namespace TimeManager.CLI
{
    class HandlerFactory
    {
        public static IContractHandler GetContractHandler()
        {
            var contractHandler = new ContractHandler();

            return contractHandler;
        }

        public static IDayHandler GetDayHandler()
        {
            var dayHandler = new DayHandler();

            return dayHandler;
        }

        public static ISettingsHandler GetSettingsHandler()
        {
            var settingsHandler = new SettingsHandler();

            return settingsHandler;
        }
    }
}
