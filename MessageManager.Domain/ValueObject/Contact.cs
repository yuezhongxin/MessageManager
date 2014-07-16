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

        public Contact(string name, string loginName, string displayName)
        {
            this.Name = name;
            this.LoginName = loginName;
            this.DisplayName = displayName;
        }

        public string Name { get; private set; }
        public string LoginName { get; private set; }
        public string DisplayName { get; private set; }
    }
}
