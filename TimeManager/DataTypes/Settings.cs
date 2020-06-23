
namespace TimeManager.DataTypes
{
    enum DatabaseTypes
    {
        Sqlite
    }
    class Settings
    {
        public DatabaseTypes DatabaseType { get; set; } = DatabaseTypes.Sqlite;
        public string DatabaseFile { get; set; }
    }
}
