using UnityEngine;

namespace MessageQueue.Message.Enemy {
    public class BaseEnemySpawnMessage : IMessage
    {
        public Vector3 SpawnPoint;
    }
}
