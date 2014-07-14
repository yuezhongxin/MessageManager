/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace MessageManager.Domain.Entity
{
    public class Inbox : MessageBox
    {
        public Inbox(IContact recipient)
            : base(recipient)
        {
            this.Messages = new List<Message>() { new Message("title", "content", new Sender("sender"), new Recipient("recipient")) };
        }

        public override Message GetMessage(string id)
        {
            //Message message = this.Messages.First(m => m.ID == id);
            Message message = this.Messages.First();
            if (message.State == MessageState.NoRead)
            {
                message.State = MessageState.Read;
            }
            return message;
        }

        public ICollection<Message> GetNoReadMessage()
        {
            return this.Messages.Where(m => m.State == MessageState.NoRead).ToList();
        }

        public int GetNoReadMessageCount()
        {
            return this.Messages.Where(m => m.State == MessageState.NoRead).Count();
        }
    }
}
