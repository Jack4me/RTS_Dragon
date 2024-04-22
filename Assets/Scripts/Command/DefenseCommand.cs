using Configuration;
using MessageQueue;
using MessageQueue.Message.UI;

namespace Command {
    public class DefenseCommand : ICommand {
        public void Execute() {
            MessageQueueManager.Instance.SendMessage(new ActionCommandMessage { Action = ActionType.Defense });
        }
    }
}