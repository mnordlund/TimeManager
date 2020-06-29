using System;
using System.Collections.Generic;
using System.Linq;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Stores.EF
{
    class CheckpointStoreEF : ICheckpointStore
    {
        private IDBContext DBContext { get; set; }

        public CheckpointStoreEF(IDBContext dBContext)
        {
            DBContext = dBContext;
        }
        public void AddCheckpoint(Checkpoint checkpoint)
        {
            DBContext.Checkpoints.Add(checkpoint);
            DBContext.SaveChanges();
        }

        public void DeleteCheckpoint(Checkpoint checkpoint)
        {
            DBContext.Checkpoints.Remove(checkpoint);
            DBContext.SaveChanges();
        }

        public IEnumerable<Checkpoint> GetAllCheckpoints()
        {
            return DBContext.Checkpoints;
        }

        public Checkpoint GetLatestCheckpoint(DateTime date)
        {
            return DBContext.Checkpoints.OrderBy(cp => cp.date).Last();
        }

        public void UpdateCheckpoint(Checkpoint checkpoint)
        {
            DBContext.Checkpoints.Update(checkpoint);
        }
    }
}
