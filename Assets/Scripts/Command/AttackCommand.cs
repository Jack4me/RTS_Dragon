using Command;
using Configuration;
using MessageQueue;
using MessageQueue.Message.UI;

namespace UI {
    public class AttackCommand : ICommand {
        public void Execute() {
            MessageQueueManager.Instance.SendMessage(new ActionCommandMessage { Action = ActionType.Attack });
        }
    }
}