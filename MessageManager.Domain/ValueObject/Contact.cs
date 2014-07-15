/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

namespace MessageManager.Domain.ValueObject
{
    public class Contact
    {
        public Contact(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
