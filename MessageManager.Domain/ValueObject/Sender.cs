/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

namespace MessageManager.Domain.ValueObject
{
    public class Sender : IContact
    {
        public Sender(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }
}
