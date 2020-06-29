
using System;
using System.Collections.Generic;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface ICheckpointStore
    {
        public IEnumerable<Checkpoint> GetAllCheckpoints();
        public Checkpoint GetLatestCheckpoint(DateTime date);
        public void AddCheckpoint(Checkpoint checkpoint);
        public void UpdateCheckpoint(Checkpoint checkpoint);
        public void DeleteCheckpoint(Checkpoint checkpoint);
    }
}
