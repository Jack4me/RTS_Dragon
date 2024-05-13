using Enemy;
using MessageQueue.Message;

namespace Spawner.Enemy {
    public class EnemyKilledMessage : IMessage
    {
        public EnemyType Type;
    }
}
