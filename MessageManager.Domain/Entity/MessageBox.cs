/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System.Collections.Generic;

namespace MessageManager.Domain.Entity
{
    public class MessageBox
    {
        public MessageBox()
        {
            Messages = new List<Message>();
        }

        public ICollection<Message> Messages { get; set; }
    }
}
