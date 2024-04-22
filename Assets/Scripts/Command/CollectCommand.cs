using Configuration;
using MessageQueue;
using MessageQueue.Message.UI;

namespace Command {
    public class CollectCommand : ICommand {
        public void Execute() {
            MessageQueueManager.Instance.SendMessage(new ActionCommandMessage { Action = ActionType.Collect });
        }
    }
}