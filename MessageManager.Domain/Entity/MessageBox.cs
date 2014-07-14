/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace MessageManager.Domain.Entity
{
    public abstract class MessageBox
    {
        public MessageBox(IContact contact)
        {
            this.Contact = contact;
        }

        public IContact Contact { get; set; }
        public ICollection<Message> Messages { get; set; }

        public virtual Message GetMessage(string id)
        {
            return this.Messages.First();
            //return this.Messages.First(m => m.ID == id);
        }

        public virtual bool DeleteMessage(Message message)
        {
            //return this.Messages.Remove(message);
            return true;
        }
    }
}
