using Microsoft.EntityFrameworkCore;
using TimeManager.DataTypes;

namespace TimeManager.Stores.EF
{
    interface IDBContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
        public DbSet<VacationState> VacationStates { get; set; }
        public int SaveChanges();
    }
}
