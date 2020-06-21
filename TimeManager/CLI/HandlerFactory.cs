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
    }
}
