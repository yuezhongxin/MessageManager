/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

namespace MessageManager.Domain.ValueObject
{
    public class Recipient : Contact
    {
        public Recipient(string name)
            : base(name)
        {
        }

        public Recipient(string name, string loginName, string displayName)
            : base(name, loginName, displayName)
        {
        }
    }
}
