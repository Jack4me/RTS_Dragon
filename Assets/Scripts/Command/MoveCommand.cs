using Configuration;
using MessageQueue;
using MessageQueue.Message.UI;
using Unity.VisualScripting;

namespace Command {
    public class MoveCommand : ICommand {
        public void Execute() {
            MessageQueueManager.Instance.SendMessage(new ActionCommandMessage { Action = ActionType.Move });

        }

    }
}