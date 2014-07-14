/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.ValueObject;
using System.Collections.Generic;

namespace MessageManager.Domain.Entity
{
    public class Outbox : MessageBox
    {
        public Outbox(IContact sender)
            : base(sender)
        {
            this.Messages = new List<Message>() { new Message("title", "content", new Sender("sender"), new Recipient("recipient")) };
        }
    }
}
