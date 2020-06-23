
namespace TimeManager.Interfaces
{
    interface IStoreFactory
    {
        public IDayStore CreateDayStore();

        public IContractStore CreateContractStore();

        public IVacationStore CreateVacationStore();
    }
}
