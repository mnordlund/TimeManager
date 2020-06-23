

using Microsoft.EntityFrameworkCore;
using TimeManager.DataTypes;

namespace TimeManager.Stores
{
    class DBContextSqlite: DbContext
    {
        private string DbFile { get; set; }
        public DBContextSqlite(string dbFile)
        {
            DbFile = dbFile;
            Database.EnsureCreated();
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Day> Days { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbFile}");
    }
}
